Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

<ToolboxItem(True)>
Public Class RibbonLikeControlAdv
    Inherits UserControl

    ' Design-time tab descriptor
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Class RibbonDesignTab
        Public Sub New()
            Me.Name = String.Empty
            Me.DisplayName = String.Empty
        End Sub

        <Category("Data")>
        <Description("Unique name for the tab")>
        Public Property Name As String

        <Category("Appearance")>
        <Description("Text displayed on the tab header")>
        Public Property DisplayName As String

        Public Overrides Function ToString() As String
            If String.IsNullOrEmpty(DisplayName) Then
                Return Name
            End If
            Return DisplayName
        End Function
    End Class

    Private tabsHeader As FlowLayoutPanel
    Private tabsContent As Panel

    ' runtime mapping tabName -> groupsFlow (FlowLayoutPanel containing groups for that tab)
    Private tabs As New Dictionary(Of String, FlowLayoutPanel)(StringComparer.OrdinalIgnoreCase)

    ' mapping tabName -> (groupName -> FlowLayoutPanel) per tab
    Private tabGroups As New Dictionary(Of String, Dictionary(Of String, FlowLayoutPanel))(StringComparer.OrdinalIgnoreCase)

    Private _selectedTab As String = String.Empty

    ' Collection exposed to designer so user can add tabs in Properties window
    Private _designTabs As List(Of RibbonDesignTab)

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        _designTabs = New List(Of RibbonDesignTab)()
        If Not Me.DesignMode Then
            ' create default runtime tab if none provided
            If _designTabs.Count = 0 Then
                AddTab("Home")
                SelectTab("Home")
            End If
        End If
    End Sub

    Private Sub InitializeComponent()
        Me.Height = 110
        Me.Dock = DockStyle.Top

        tabsHeader = New FlowLayoutPanel() With {
            .Dock = DockStyle.Top,
            .Height = 28,
            .FlowDirection = FlowDirection.LeftToRight,
            .WrapContents = False,
            .Padding = New Padding(4, 4, 4, 0),
            .BackColor = Color.Transparent
        }

        tabsContent = New Panel() With {
            .Dock = DockStyle.Fill,
            .BackColor = Color.WhiteSmoke
        }

        Me.Controls.Add(tabsContent)
        Me.Controls.Add(tabsHeader)
    End Sub

    ' Expose design-time tabs collection
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
    <Category("Tabs")>
    <Description("Tabs displayed in the ribbon. Add tabs at design-time to create tab panels where you can place controls.")>
    Public ReadOnly Property DesignTabs As List(Of RibbonDesignTab)
        Get
            Return _designTabs
        End Get
    End Property

    Protected Overrides Sub OnHandleCreated(e As EventArgs)
        MyBase.OnHandleCreated(e)
        ' Ensure panels exist for design-time tabs and for runtime tabs
        EnsureTabsFromDesign()
    End Sub

    Private Sub EnsureTabsFromDesign()
        ' If designer provided tabs, create their panels and headers
        If _designTabs IsNot Nothing AndAlso _designTabs.Count > 0 Then
            For Each dt In _designTabs
                Dim tname = If(String.IsNullOrWhiteSpace(dt.Name), dt.DisplayName, dt.Name)
                If String.IsNullOrWhiteSpace(tname) Then Continue For
                If Not tabs.ContainsKey(tname) Then
                    ' create header button if not exist
                    Dim existsHeader = tabsHeader.Controls.Cast(Of Control)().Any(Function(c) String.Equals(c.Tag?.ToString(), tname, StringComparison.OrdinalIgnoreCase) OrElse String.Equals(c.Text, tname, StringComparison.OrdinalIgnoreCase) OrElse String.Equals(c.Text, dt.DisplayName, StringComparison.OrdinalIgnoreCase))
                    If Not existsHeader Then
                        Dim btn As New Button() With {
                            .Text = If(String.IsNullOrEmpty(dt.DisplayName), tname, dt.DisplayName),
                            .AutoSize = True,
                            .Padding = New Padding(8, 2, 8, 2),
                            .BackColor = Color.Transparent,
                            .FlatStyle = FlatStyle.Flat,
                            .Tag = tname
                        }
                        btn.FlatAppearance.BorderSize = 0
                        AddHandler btn.Click, Sub(s, ev) SelectTab(tname)
                        tabsHeader.Controls.Add(btn)
                    End If

                    ' create or find content panel for this tab
                    Dim panelName = PanelNameForTab(tname)
                    Dim existingPanel = tabsContent.Controls.OfType(Of Panel)().FirstOrDefault(Function(p) String.Equals(p.Name, panelName, StringComparison.OrdinalIgnoreCase))
                    Dim groupsPanel As FlowLayoutPanel = Nothing
                    If existingPanel Is Nothing Then
                        Dim gp As New FlowLayoutPanel() With {
                            .Name = panelName,
                            .Dock = DockStyle.Fill,
                            .FlowDirection = FlowDirection.LeftToRight,
                            .WrapContents = False,
                            .AutoScroll = True,
                            .Padding = New Padding(4)
                        }
                        tabsContent.Controls.Add(gp)
                        groupsPanel = gp
                    Else
                        groupsPanel = TryCast(existingPanel, FlowLayoutPanel)
                    End If

                    groupsPanel.Visible = False
                    tabs(tname) = groupsPanel
                    If Not tabGroups.ContainsKey(tname) Then tabGroups(tname) = New Dictionary(Of String, FlowLayoutPanel)(StringComparer.OrdinalIgnoreCase)
                End If
            Next

            ' select first design tab by default
            Dim first = _designTabs.Select(Function(x) If(String.IsNullOrWhiteSpace(x.Name), x.DisplayName, x.Name)).FirstOrDefault()
            If first IsNot Nothing Then
                SelectTab(first)
            End If
        Else
            ' no design tabs specified: ensure at least one runtime tab exists
            If tabs.Count = 0 Then
                AddTab("Home")
                SelectTab("Home")
            End If
        End If
    End Sub

    Private Function PanelNameForTab(tabName As String) As String
        Return "tabPanel_" & tabName.Replace(" ", "_")
    End Function

    ' Create a new tab with a header button (runtime)
    Public Function AddTab(tabName As String, Optional displayName As String = Nothing) As Boolean
        If String.IsNullOrWhiteSpace(tabName) Then Throw New ArgumentException("tabName is required")
        If tabs.ContainsKey(tabName) Then Return False

        Dim btn As New Button() With {
            .Text = If(String.IsNullOrEmpty(displayName), tabName, displayName),
            .AutoSize = True,
            .Padding = New Padding(8, 2, 8, 2),
            .BackColor = Color.Transparent,
            .FlatStyle = FlatStyle.Flat,
            .Tag = tabName
        }
        btn.FlatAppearance.BorderSize = 0
        AddHandler btn.Click, Sub(s, e) SelectTab(tabName)

        tabsHeader.Controls.Add(btn)

        Dim groupsPanel As New FlowLayoutPanel() With {
            .Dock = DockStyle.Fill,
            .FlowDirection = FlowDirection.LeftToRight,
            .WrapContents = False,
            .AutoScroll = True,
            .Padding = New Padding(4)
        }

        groupsPanel.Visible = False
        tabsContent.Controls.Add(groupsPanel)

        tabs(tabName) = groupsPanel
        tabGroups(tabName) = New Dictionary(Of String, FlowLayoutPanel)(StringComparer.OrdinalIgnoreCase)

        Return True
    End Function

    Public Function GetTabNames() As String()
        Return tabs.Keys.ToArray()
    End Function

    Public Function RemoveTab(tabName As String) As Boolean
        If Not tabs.ContainsKey(tabName) Then Return False
        ' remove header button
        For Each ctl As Control In tabsHeader.Controls
            If String.Equals(CStr(ctl.Tag), tabName, StringComparison.OrdinalIgnoreCase) OrElse String.Equals(ctl.Text, tabName, StringComparison.OrdinalIgnoreCase) Then
                tabsHeader.Controls.Remove(ctl)
                Exit For
            End If
        Next
        ' remove content
        Dim gp = tabs(tabName)
        If gp IsNot Nothing Then
            tabsContent.Controls.Remove(gp)
            gp.Dispose()
        End If
        tabs.Remove(tabName)
        tabGroups.Remove(tabName)

        If String.Equals(_selectedTab, tabName, StringComparison.OrdinalIgnoreCase) Then
            If tabs.Count > 0 Then
                SelectTab(tabs.Keys.First())
            Else
                _selectedTab = String.Empty
            End If
        End If

        Return True
    End Function

    Public Sub SelectTab(tabName As String)
        If String.IsNullOrWhiteSpace(tabName) Then Return
        If Not tabs.ContainsKey(tabName) Then Return

        For Each kvp In tabs
            kvp.Value.Visible = False
        Next

        Dim selectedPanel = tabs(tabName)
        selectedPanel.Visible = True
        selectedPanel.BringToFront()
        _selectedTab = tabName

        ' update header button appearance
        For Each c As Control In tabsHeader.Controls
            If TypeOf c Is Button Then
                Dim b = CType(c, Button)
                If String.Equals(CStr(b.Tag), tabName, StringComparison.OrdinalIgnoreCase) OrElse String.Equals(b.Text, tabName, StringComparison.OrdinalIgnoreCase) Then
                    b.Font = New Font(b.Font, FontStyle.Bold)
                Else
                    b.Font = New Font(b.Font, FontStyle.Regular)
                End If
            End If
        Next
    End Sub

    Public ReadOnly Property SelectedTab As String
        Get
            Return _selectedTab
        End Get
    End Property

    ' Add a group to the specified tab (creates tab if missing)
    Public Function AddGroup(tabName As String, groupName As String, Optional headerText As String = Nothing) As FlowLayoutPanel
        If String.IsNullOrWhiteSpace(tabName) Then tabName = If(String.IsNullOrEmpty(_selectedTab), "Home", _selectedTab)
        If Not tabs.ContainsKey(tabName) Then AddTab(tabName)

        Dim groupsPanel = tabs(tabName)
        Dim groupsDict = tabGroups(tabName)
        If groupsDict.ContainsKey(groupName) Then
            Return groupsDict(groupName)
        End If

        Dim gp As New Panel() With {
            .AutoSize = True,
            .AutoSizeMode = AutoSizeMode.GrowOnly,
            .Padding = New Padding(4),
            .Margin = New Padding(6, 4, 6, 4),
            .BackColor = Color.Transparent
        }

        Dim header As New Label() With {
            .Text = If(headerText, groupName),
            .AutoSize = False,
            .Height = 18,
            .Dock = DockStyle.Top,
            .TextAlign = ContentAlignment.MiddleCenter,
            .ForeColor = Color.Black,
            .Font = New Font(Me.Font.FontFamily, 8.25F, FontStyle.Bold)
        }

        Dim buttonsFlow As New FlowLayoutPanel() With {
            .FlowDirection = FlowDirection.TopDown,
            .WrapContents = False,
            .AutoSize = True,
            .AutoSizeMode = AutoSizeMode.GrowOnly,
            .Padding = New Padding(2),
            .Margin = New Padding(0),
            .Dock = DockStyle.Fill
        }

        gp.Controls.Add(buttonsFlow)
        gp.Controls.Add(header)

        groupsPanel.Controls.Add(gp)
        groupsDict(groupName) = buttonsFlow

        Return buttonsFlow
    End Function

    ' Overload: AddGroup to current selected tab
    Public Function AddGroup(groupName As String, Optional headerText As String = Nothing) As FlowLayoutPanel
        Return AddGroup(_selectedTab, groupName, headerText)
    End Function

    ' Add an ImageLabelButton to a named group on a specific tab (creates tab/group if missing)
    Public Function AddButtonToGroup(tabName As String, groupName As String, text As String, Optional image As Image = Nothing, Optional clickHandler As EventHandler = Nothing) As ImageLabelButton
        If String.IsNullOrWhiteSpace(tabName) Then tabName = _selectedTab
        Dim flow As FlowLayoutPanel = Nothing
        If Not tabGroups.ContainsKey(tabName) OrElse Not tabGroups(tabName).TryGetValue(groupName, flow) Then
            flow = AddGroup(tabName, groupName)
        End If

        Dim btn As New ImageLabelButton() With {
            .Width = 72,
            .Height = 72,
            .Text = text,
            .Image = image
        }

        If clickHandler IsNot Nothing Then
            AddHandler btn.Click, clickHandler
        End If

        flow.Controls.Add(btn)
        Return btn
    End Function

    ' Overload: AddButtonToGroup to selected tab
    Public Function AddButtonToGroup(groupName As String, text As String, Optional image As Image = Nothing, Optional clickHandler As EventHandler = Nothing) As ImageLabelButton
        Return AddButtonToGroup(_selectedTab, groupName, text, image, clickHandler)
    End Function

    ' Add any control to a group on a specific tab
    Public Sub AddControlToGroup(tabName As String, groupName As String, ctrl As Control)
        If String.IsNullOrWhiteSpace(tabName) Then tabName = _selectedTab
        If ctrl Is Nothing Then Throw New ArgumentNullException(NameOf(ctrl))
        Dim flow As FlowLayoutPanel = Nothing
        If Not tabGroups.ContainsKey(tabName) OrElse Not tabGroups(tabName).TryGetValue(groupName, flow) Then
            flow = AddGroup(tabName, groupName)
        End If
        flow.Controls.Add(ctrl)
    End Sub

    ' Overload: AddControlToGroup to selected tab
    Public Sub AddControlToGroup(groupName As String, ctrl As Control)
        AddControlToGroup(_selectedTab, groupName, ctrl)
    End Sub

    Public Sub ClearTabs()
        For Each kvp In tabs
            kvp.Value.Dispose()
        Next
        tabs.Clear()
        tabGroups.Clear()
        tabsHeader.Controls.Clear()
        tabsContent.Controls.Clear()
        _selectedTab = String.Empty
    End Sub

End Class
