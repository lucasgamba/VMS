Imports System.Reflection

Public Class Frm_00_02_Translations

    ' Tipos que têm a propriedade .Text e devem ser listados para tradução
    Private ReadOnly TranslatableTypes As Type() = {
        GetType(System.Windows.Forms.Label),
        GetType(System.Windows.Forms.Button),
        GetType(System.Windows.Forms.CheckBox),
        GetType(System.Windows.Forms.RadioButton),
        GetType(System.Windows.Forms.GroupBox),
        GetType(System.Windows.Forms.ToolStripButton),
        GetType(System.Windows.Forms.ToolStripDropDownButton),
        GetType(System.Windows.Forms.ToolStripMenuItem),
        GetType(System.Windows.Forms.ToolStripLabel),
        GetType(System.Windows.Forms.ToolStripDropDownItem),
        GetType(System.Windows.Forms.TabControl),
        GetType(System.Windows.Forms.TabPage),
        GetType(System.Windows.Forms.Form), ' Incluir o próprio Form
        GetType(System.Windows.Forms.TextBox),
        GetType(System.Windows.Forms.ComboBox),
        GetType(System.Windows.Forms.LinkLabel),
        GetType(System.Windows.Forms.MenuStrip),
        GetType(System.Windows.Forms.ToolStrip),
        GetType(System.Windows.Forms.StatusStrip),
        GetType(System.Windows.Forms.ColumnHeader),
        GetType(System.Windows.Forms.Panel)
    }

    ' Adicionar variável de classe para armazenar as traduções
    Private _translationsDataTable As DataTable

    Private Sub Frm_00_02_Translations_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = New Icon(".\Pictures\icon.ico")
        With Logo_01
            .Image = My.Resources.ResourcesPic.mainLogo
            .SizeMode = PictureBoxSizeMode.Zoom
        End With

        ' Configura o ListView para exibir a lista de Forms
        LstVw_01_Forms.View = View.Details
        LstVw_01_Forms.Columns.Add("Form Name", 280)
        LstVw_01_Forms.FullRowSelect = True ' Seleciona a linha inteira

        LoadFormsList()

        ' Configura o ListView para exibir os objetos traduzíveis
        LstVw_02_Objects.View = View.Details
        LstVw_02_Objects.Columns.Add("Object Name", 120)
        LstVw_02_Objects.Columns.Add("Type", 80)
        LstVw_02_Objects.Columns.Add("Has Translation", 50)
        LstVw_02_Objects.Columns.Add("Text Value", 100)
        LstVw_02_Objects.FullRowSelect = True

        AdjustListViewColumns()

        'Load Languages List
        LoadLanguagesList()

        ' Configura o ListView para exibir as línguas
        LstVw_03_Languages.View = View.Details
        LstVw_03_Languages.Columns.Add("Language", 100)
        LstVw_03_Languages.Columns.Add("ID", 50)
        LstVw_03_Languages.Columns.Add("Has Translations", 80) ' Add new column
        LstVw_03_Languages.FullRowSelect = True
    End Sub

    Private Sub LoadFormsList()
        LstVw_01_Forms.Items.Clear()

        ' Obtém o assembly atual (o projeto onde o código está rodando)
        Dim currentAssembly As Assembly = Assembly.GetExecutingAssembly()

        ' Filtra todos os tipos (classes) que herdam de System.Windows.Forms.Form
        Dim formTypes = currentAssembly.GetTypes() _
            .Where(Function(t) t.IsSubclassOf(GetType(System.Windows.Forms.Form))) _
            .OrderBy(Function(t) t.Name) ' Opcional: ordenar por nome

        For Each formType In formTypes
            Dim item As New ListViewItem(formType.Name)
            ' Armazena o objeto Type real na propriedade Tag para uso posterior
            item.Tag = formType
            LstVw_01_Forms.Items.Add(item)
        Next
    End Sub

    Private Sub LstVw_01_Forms_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LstVw_01_Forms.SelectedIndexChanged
        If LstVw_01_Forms.SelectedItems.Count = 0 Then
            Return
        End If

        LstVw_02_Objects.Items.Clear()

        ' Obtém o objeto Type que foi armazenado no Tag
        Dim selectedFormType As Type = CType(LstVw_01_Forms.SelectedItems(0).Tag, Type)

        ' Chama a função de inspeção
        LoadTranslatableObjects(selectedFormType)

        'Marcar primeira linha da lista de objetos
        If LstVw_02_Objects.Items.Count > 0 Then
            LstVw_02_Objects.Items(0).Selected = True
        End If
    End Sub

    Private Sub LoadTranslatableObjects(formType As Type)
        LstVw_02_Objects.Items.Clear()

        Dim formInstance As System.Windows.Forms.Form = Nothing

        Try
            ' Cria uma instância do formulário selecionado
            formInstance = CType(Activator.CreateInstance(formType), System.Windows.Forms.Form)

            ' Adiciona o próprio formulário
            AddObjectToListView(formInstance, formInstance.Text)

            ' Encontra todos os ToolStrips no formulário (incluindo os aninhados)
            Dim toolStrips = FindAllToolStrips(formInstance)

            ' Para cada ToolStrip, processa seus itens
            For Each ts As ToolStrip In toolStrips
                ProcessToolStripItems(ts)
            Next

            ' Processa os controles regulares
            For Each ctrl As Control In GetAllControls(formInstance)
                If IsTranslatableType(ctrl.GetType()) AndAlso Not String.IsNullOrEmpty(ctrl.Text) Then
                    AddObjectToListView(ctrl, ctrl.Text)
                End If
            Next

        Catch ex As Exception
            MessageBox.Show($"Erro ao instanciar ou inspecionar o formulário '{formType.Name}': {ex.Message}",
                           "Erro de Reflection", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If formInstance IsNot Nothing Then
                formInstance.Dispose()
            End If
        End Try

        UpdateTranslationStatus()
    End Sub

    ' Nova função para encontrar todos os ToolStrips recursivamente
    Private Function FindAllToolStrips(control As Control) As List(Of ToolStrip)
        Dim toolStrips As New List(Of ToolStrip)

        ' Se o controle atual é um ToolStrip, adiciona-o à lista
        If TypeOf control Is ToolStrip Then
            toolStrips.Add(DirectCast(control, ToolStrip))
        End If

        ' Procura recursivamente em todos os controles filhos
        For Each childControl As Control In control.Controls
            toolStrips.AddRange(FindAllToolStrips(childControl))
        Next

        Return toolStrips
    End Function

    ' Modificar o ProcessToolStripItems para incluir mais informações de debug
    Private Sub ProcessToolStripItems(toolStrip As ToolStrip)
        ' Primeiro adiciona o próprio ToolStrip se tiver texto
        If Not String.IsNullOrEmpty(toolStrip.Text) Then
            AddObjectToListView(toolStrip, toolStrip.Text)
        End If

        ' Processa cada item do ToolStrip
        For Each item As ToolStripItem In toolStrip.Items
            ' Cria um proxy para o item
            Dim proxy As New ControlProxy(item)
            AddObjectToListView(proxy, item.Text)

            ' Se for um item dropdown, processa seus subitens
            If TypeOf item Is ToolStripDropDownItem Then
                Dim dropDownItem = DirectCast(item, ToolStripDropDownItem)
                For Each subItem As ToolStripItem In dropDownItem.DropDownItems
                    Dim subProxy As New ControlProxy(subItem)
                    AddObjectToListView(subProxy, subItem.Text)
                Next
            End If
        Next
    End Sub

    Private Function IsTranslatableType(type As Type) As Boolean
        Return TranslatableTypes.Any(Function(t) t.IsAssignableFrom(type))
    End Function

    ' Função auxiliar para adicionar itens ao ListView de Objetos
    Private Sub AddObjectToListView(ctrl As Control, defaultText As String)
        Dim item As New ListViewItem(ctrl.Name)

        ' Verifica se é um ControlProxy
        If TypeOf ctrl Is ControlProxy Then
            Dim proxy As ControlProxy = DirectCast(ctrl, ControlProxy)
            item.SubItems.Add(proxy.GetToolStripItemType().Name)
        Else
            item.SubItems.Add(ctrl.GetType().Name)
        End If

        ' Adiciona coluna Has Translation vazia (será preenchida pelo UpdateTranslationStatus)
        item.SubItems.Add("")

        ' Adiciona o Text Value
        item.SubItems.Add(defaultText)

        ' Armazena a referência do controle (ou o nome do Form) para a tradução futura
        item.Tag = ctrl.Name

        LstVw_02_Objects.Items.Add(item)
    End Sub

    ' Função recursiva para obter todos os controles, incluindo os dentro de GroupBox/Panel
    Private Function GetAllControls(root As Control) As List(Of Control)
        Dim controlsList As New List(Of Control)()

        ' Add the control itself if it's not a ToolStrip (já processado anteriormente)
        If Not TypeOf root Is ToolStrip Then
            controlsList.Add(root)
        End If

        ' Recursively add child controls
        For Each c As Control In root.Controls
            controlsList.AddRange(GetAllControls(c))
        Next

        Return controlsList
    End Function

    Private Function GetToolStripItems(toolStrip As ToolStrip) As List(Of Control)
        Dim itemsList As New List(Of Control)()

        For Each item As ToolStripItem In toolStrip.Items
            ' Create proxy control for the ToolStripItem
            Dim proxy As New ControlProxy(item)
            itemsList.Add(proxy)

            ' Handle dropdown items if present
            If TypeOf item Is ToolStripDropDownItem Then
                Dim dropDownItem As ToolStripDropDownItem = DirectCast(item, ToolStripDropDownItem)
                For Each dropDownSubItem As ToolStripItem In dropDownItem.DropDownItems
                    itemsList.Add(New ControlProxy(dropDownSubItem))
                Next
            End If
        Next

        Return itemsList
    End Function

    ' Updated ControlProxy class
    Private Class ControlProxy
        Inherits Control
        Private ReadOnly _toolStripItem As ToolStripItem

        Public Sub New(toolStripItem As ToolStripItem)
            _toolStripItem = toolStripItem
            ' Usa o Name do ToolStripItem se disponível, caso contrário cria um nome único
            Me.Name = If(Not String.IsNullOrEmpty(toolStripItem.Name),
                        toolStripItem.Name,
                        $"TSI_{toolStripItem.GetType().Name}_{toolStripItem.Text.Replace(" ", "_")}")
            Me.Text = toolStripItem.Text
        End Sub

        Public Overrides Property Text As String
            Get
                Return _toolStripItem.Text
            End Get
            Set(value As String)
                _toolStripItem.Text = value
            End Set
        End Property

        Public Function GetToolStripItemType() As Type
            Return _toolStripItem.GetType()
        End Function

        Public ReadOnly Property ToolStripItem As ToolStripItem
            Get
                Return _toolStripItem
            End Get
        End Property
    End Class

    Private Sub Frm_00_02_Translations_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ' Chama a rotina de ajuste de coluna
        AdjustListViewColumns()
    End Sub

    Private Sub AdjustListViewColumns()
        ' Verifica se o ListView tem as 4 colunas esperadas
        If LstVw_02_Objects.Columns.Count < 4 OrElse LstVw_02_Objects.Width <= 0 Then
            Return
        End If

        ' Define a largura total disponível do ListView
        Dim availableWidth As Integer = LstVw_02_Objects.ClientSize.Width - 4

        ' --- Definição dos Pesos Proporcionais (Total = 100) ---
        Const WeightName As Integer = 30        ' Coluna 0: Nome do Objeto (30%)
        Const WeightType As Integer = 20        ' Coluna 1: Tipo (20%)
        Const WeightHasTranslation As Integer = 15  ' Coluna 2: Has Translation (15%)
        Const WeightText As Integer = 35        ' Coluna 3: Text Value (35%)

        Const TotalWeight As Integer = WeightName + WeightType + WeightHasTranslation + WeightText

        ' Calcula a largura de cada coluna
        Dim colWidth0 As Integer = CInt(availableWidth * WeightName / TotalWeight)
        Dim colWidth1 As Integer = CInt(availableWidth * WeightType / TotalWeight)
        Dim colWidth2 As Integer = CInt(availableWidth * WeightHasTranslation / TotalWeight)
        Dim colWidth3 As Integer = availableWidth - colWidth0 - colWidth1 - colWidth2

        ' Aplica as novas larguras
        LstVw_02_Objects.Columns(0).Width = colWidth0     ' Object Name
        LstVw_02_Objects.Columns(1).Width = colWidth1     ' Type
        LstVw_02_Objects.Columns(2).Width = colWidth2     ' Has Translation
        LstVw_02_Objects.Columns(3).Width = colWidth3     ' Text Value
    End Sub

    Private Sub Btn_02_Exit_Click(sender As Object, e As EventArgs) Handles Btn_02_Exit.Click
        Me.Close()
    End Sub

    Private Sub LstVw_02_Objects_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LstVw_02_Objects.SelectedIndexChanged
        If LstVw_02_Objects.SelectedItems.Count > 0 Then
            LoadTranslatedValue()
            UpdateLanguageTranslationStatus() ' Atualiza o status dos idiomas com base no objeto selecionado
        End If
    End Sub
    Private Sub LstVw_03_Languages_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LstVw_03_Languages.SelectedIndexChanged
        If LstVw_03_Languages.SelectedItems.Count > 0 And LstVw_02_Objects.SelectedItems.Count > 0 Then
            LoadTranslatedValue()
        End If
    End Sub
    'Retrive languages from database
    Private Sub LoadLanguagesList()
        LstVw_03_Languages.Items.Clear()
        Dim sp_ext As String = "VMS_cfg_Translation"
        Dim action_ext As String = "List_Languages"
        Dim param_ext As New Dictionary(Of String, String) From
            {
            {"LanguageId_Ext", "0"}
        }
        Dim sqlStr As String = GenSQL(sp_ext, action_ext, GenJson(param_ext))

        Dim dt As DataTable = QueryTable_MySQL(sqlStr, 1)

        'Populate ListView
        For Each row As DataRow In dt.Rows
            Dim item As New ListViewItem(row("LanguageName").ToString())
            ' Add SubItems explicitly
            item.SubItems.Add(row("LanguageID").ToString())
            item.SubItems.Add("No") ' Add the "Has Translations" column
            LstVw_03_Languages.Items.Add(item)
        Next

        'Select first language by default
        If LstVw_03_Languages.Items.Count > 0 Then
            LstVw_03_Languages.Items(0).Selected = True
        End If

        ' Update translation status if a form is selected
        If LstVw_01_Forms.SelectedItems.Count > 0 Then
            UpdateTranslationStatus()
        End If
    End Sub

    'Save translation to database
    Private Sub Btn_01_Save_Click(sender As Object, e As EventArgs) Handles Btn_01_Save.Click
        Dim formName As String
        Dim objectName As String
        Dim languageSelect As String
        Dim translationText As String
        'Return
        Dim selectedItem As ListViewItem = LstVw_02_Objects.SelectedItems(0)
        formName = LstVw_01_Forms.SelectedItems(0).Text
        objectName = selectedItem.Tag.ToString()
        languageSelect = LstVw_03_Languages.SelectedItems(0).SubItems(1).Text
        translationText = Txt_03_NewValue.Text.ToString()

        'Save translation info to database
        Dim sp_ext As String = "VMS_cfg_Translation"
        Dim action_ext As String = "AddEdit_Translation"
        Dim param_ext As New Dictionary(Of String, String) From
            {
            {"FormName_Ext", formName},
            {"ObjectName_Ext", objectName},
            {"LanguageID_Ext", languageSelect},
            {"TranslationText_Ext", translationText}
        }
        Dim sqlStr As String = GenSQL(sp_ext, action_ext, GenJson(param_ext))
        ExecuteMySql(sqlStr, 1)

        'Inform text saved
        Txt_02_CurrentTranslation.Text = translationText

        'Clear new translation box
        Txt_03_NewValue.Text = ""

        ' Atualiza o status das traduções após salvar
        UpdateTranslationStatus()
    End Sub

    'List translation languages selection
    Private Sub LoadTranslatedValue()
        Dim formName As String
        Dim objectName As String
        Dim languageSelect As String

        'Return
        Dim selectedItem As ListViewItem = LstVw_02_Objects.SelectedItems(0)
        formName = LstVw_01_Forms.SelectedItems(0).Text
        objectName = selectedItem.Tag.ToString()
        languageSelect = LstVw_03_Languages.SelectedItems(0).SubItems(1).Text

        'Retrive translation info from database
        Dim sp_ext As String = "VMS_cfg_Translation"
        Dim action_ext As String = "Get_Translation_Info"
        Dim param_ext As New Dictionary(Of String, String) From
            {
            {"FormName_Ext", formName},
            {"ObjectName_Ext", objectName},
            {"LanguageID_Ext", languageSelect}
        }

        Dim sqlStr As String = GenSQL(sp_ext, action_ext, GenJson(param_ext))
        Dim dt As DataTable = QueryTable_MySQL(sqlStr, 1)

        If dt.Rows.Count > 0 Then
            Dim row As DataRow = dt.Rows(0)
            Dim translationText As String = row("TranslationText").ToString()
            Me.Txt_02_CurrentTranslation.Text = translationText
        Else
            Me.Txt_02_CurrentTranslation.Text = ""
        End If
        Me.Txt_01_CurrentValue.Text = LstVw_02_Objects.SelectedItems(0).SubItems(3).Text ' Ajustado para o novo índice

        ' Atualiza o status das traduções após carregar
        UpdateTranslationStatus()
    End Sub

    ' Add new method to update translation status
    Private Sub UpdateTranslationStatus()
        If LstVw_01_Forms.SelectedItems.Count = 0 Then Return

        Dim formName As String = LstVw_01_Forms.SelectedItems(0).Text

        ' Call stored procedure to get all translations
        Dim sp_ext As String = "VMS_cfg_Translation"
        Dim action_ext As String = "Get_AllTranslations_Form"
        Dim param_ext As New Dictionary(Of String, String) From {
            {"FormName_Ext", formName}
        }

        Dim sqlStr As String = GenSQL(sp_ext, action_ext, GenJson(param_ext))
        _translationsDataTable = QueryTable_MySQL(sqlStr, 1) ' Armazena o DataTable

        UpdateObjectTranslationStatus()
        UpdateLanguageTranslationStatus()
    End Sub

    ' Novo método para atualizar status dos objetos
    Private Sub UpdateObjectTranslationStatus()
        If LstVw_02_Objects.Items.Count = 0 Then Return

        ' Update LstVw_02_Objects status
        For Each item As ListViewItem In LstVw_02_Objects.Items
            Dim objectName As String = item.Tag.ToString()
            Dim hasTranslation As Boolean = False

            ' Verifica se o objeto tem tradução no idioma selecionado
            If LstVw_03_Languages.SelectedItems.Count > 0 Then
                Dim currentLanguageId As String = LstVw_03_Languages.SelectedItems(0).SubItems(1).Text
                hasTranslation = _translationsDataTable.AsEnumerable() _
                    .Any(Function(row) row("ObjectName").ToString() = objectName AndAlso
                                      row("LanguageID").ToString() = currentLanguageId AndAlso
                                      Not String.IsNullOrWhiteSpace(row("TranslationText").ToString()))
            End If

            ' Atualiza o status de tradução
            item.SubItems(2).Text = If(hasTranslation, "Yes", "")
        Next
    End Sub

    ' Novo método para atualizar status dos idiomas com base no objeto selecionado
    Private Sub UpdateLanguageTranslationStatus()
        If LstVw_02_Objects.SelectedItems.Count = 0 Then
            ' Se nenhum objeto estiver selecionado, mostra todos os idiomas que têm qualquer tradução
            For Each langItem As ListViewItem In LstVw_03_Languages.Items
                Dim languageId As String = langItem.SubItems(1).Text
                Dim hasAnyTranslation As Boolean = _translationsDataTable.AsEnumerable() _
                    .Any(Function(row) row("LanguageID").ToString() = languageId AndAlso
                                      Not String.IsNullOrWhiteSpace(row("TranslationText").ToString()))

                langItem.SubItems(2).Text = If(hasAnyTranslation, "Yes", "")
            Next
        Else
            ' Se um objeto estiver selecionado, mostra apenas os idiomas que têm tradução para este objeto
            Dim selectedObjectName As String = LstVw_02_Objects.SelectedItems(0).Tag.ToString()

            For Each langItem As ListViewItem In LstVw_03_Languages.Items
                Dim languageId As String = langItem.SubItems(1).Text
                Dim hasTranslation As Boolean = _translationsDataTable.AsEnumerable() _
                    .Any(Function(row) row("ObjectName").ToString() = selectedObjectName AndAlso
                                      row("LanguageID").ToString() = languageId AndAlso
                                      Not String.IsNullOrWhiteSpace(row("TranslationText").ToString()))

                langItem.SubItems(2).Text = If(hasTranslation, "Yes", "")
            Next
        End If
    End Sub
End Class