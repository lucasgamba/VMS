<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_00_01_Landing
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_00_01_Landing))
        Logo = New PictureBox()
        MenuStrip1 = New MenuStrip()
        FileToolStripMenuItem = New ToolStripMenuItem()
        VersionControlToolStripMenuItem = New ToolStripMenuItem()
        TablesToolStripMenuItem = New ToolStripMenuItem()
        ExitToolStripMenuItem = New ToolStripMenuItem()
        ConfigToolStripMenuItem = New ToolStripMenuItem()
        BaseDeDatosToolStripMenuItem = New ToolStripMenuItem()
        SelectLanguageToolStripMenuItem = New ToolStripMenuItem()
        TranslationsToolStripMenuItem = New ToolStripMenuItem()
        AdminToolStripMenuItem = New ToolStripMenuItem()
        NewUserToolStripMenuItem = New ToolStripMenuItem()
        ChanngeUserToolStripMenuItem = New ToolStripMenuItem()
        UsersRightsToolStripMenuItem = New ToolStripMenuItem()
        Btn_01_VMS = New Button()
        Btn_02_Resto = New Button()
        Lbl_01_WelcomeText = New Label()
        CType(Logo, ComponentModel.ISupportInitialize).BeginInit()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Logo
        ' 
        Logo.Location = New Point(107, 43)
        Logo.Margin = New Padding(3, 4, 3, 4)
        Logo.Name = "Logo"
        Logo.Size = New Size(145, 151)
        Logo.SizeMode = PictureBoxSizeMode.Zoom
        Logo.TabIndex = 0
        Logo.TabStop = False
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Items.AddRange(New ToolStripItem() {FileToolStripMenuItem, ConfigToolStripMenuItem, AdminToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(359, 24)
        MenuStrip1.TabIndex = 1
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' FileToolStripMenuItem
        ' 
        FileToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {VersionControlToolStripMenuItem, TablesToolStripMenuItem, ExitToolStripMenuItem})
        FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        FileToolStripMenuItem.Size = New Size(37, 20)
        FileToolStripMenuItem.Text = "File"
        ' 
        ' VersionControlToolStripMenuItem
        ' 
        VersionControlToolStripMenuItem.Name = "VersionControlToolStripMenuItem"
        VersionControlToolStripMenuItem.Size = New Size(155, 22)
        VersionControlToolStripMenuItem.Text = "Version Control"
        ' 
        ' TablesToolStripMenuItem
        ' 
        TablesToolStripMenuItem.Name = "TablesToolStripMenuItem"
        TablesToolStripMenuItem.Size = New Size(155, 22)
        TablesToolStripMenuItem.Text = "Tables"
        ' 
        ' ExitToolStripMenuItem
        ' 
        ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        ExitToolStripMenuItem.Size = New Size(155, 22)
        ExitToolStripMenuItem.Text = "Exit"
        ' 
        ' ConfigToolStripMenuItem
        ' 
        ConfigToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {BaseDeDatosToolStripMenuItem, SelectLanguageToolStripMenuItem, TranslationsToolStripMenuItem})
        ConfigToolStripMenuItem.Name = "ConfigToolStripMenuItem"
        ConfigToolStripMenuItem.Size = New Size(55, 20)
        ConfigToolStripMenuItem.Text = "Config"
        ' 
        ' BaseDeDatosToolStripMenuItem
        ' 
        BaseDeDatosToolStripMenuItem.Name = "BaseDeDatosToolStripMenuItem"
        BaseDeDatosToolStripMenuItem.Size = New Size(160, 22)
        BaseDeDatosToolStripMenuItem.Text = "Database"
        ' 
        ' SelectLanguageToolStripMenuItem
        ' 
        SelectLanguageToolStripMenuItem.Name = "SelectLanguageToolStripMenuItem"
        SelectLanguageToolStripMenuItem.Size = New Size(160, 22)
        SelectLanguageToolStripMenuItem.Text = "Select Language"
        ' 
        ' TranslationsToolStripMenuItem
        ' 
        TranslationsToolStripMenuItem.Name = "TranslationsToolStripMenuItem"
        TranslationsToolStripMenuItem.Size = New Size(160, 22)
        TranslationsToolStripMenuItem.Text = "Translations"
        ' 
        ' AdminToolStripMenuItem
        ' 
        AdminToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {NewUserToolStripMenuItem, ChanngeUserToolStripMenuItem, UsersRightsToolStripMenuItem})
        AdminToolStripMenuItem.Name = "AdminToolStripMenuItem"
        AdminToolStripMenuItem.Size = New Size(47, 20)
        AdminToolStripMenuItem.Text = "Users"
        ' 
        ' NewUserToolStripMenuItem
        ' 
        NewUserToolStripMenuItem.Name = "NewUserToolStripMenuItem"
        NewUserToolStripMenuItem.Size = New Size(148, 22)
        NewUserToolStripMenuItem.Text = "New User"
        ' 
        ' ChanngeUserToolStripMenuItem
        ' 
        ChanngeUserToolStripMenuItem.Name = "ChanngeUserToolStripMenuItem"
        ChanngeUserToolStripMenuItem.Size = New Size(148, 22)
        ChanngeUserToolStripMenuItem.Text = "Channge User"
        ' 
        ' UsersRightsToolStripMenuItem
        ' 
        UsersRightsToolStripMenuItem.Name = "UsersRightsToolStripMenuItem"
        UsersRightsToolStripMenuItem.Size = New Size(148, 22)
        UsersRightsToolStripMenuItem.Text = "Users Rights"
        ' 
        ' Btn_01_VMS
        ' 
        Btn_01_VMS.BackgroundImageLayout = ImageLayout.Zoom
        Btn_01_VMS.FlatAppearance.BorderSize = 2
        Btn_01_VMS.Location = New Point(55, 261)
        Btn_01_VMS.Name = "Btn_01_VMS"
        Btn_01_VMS.Size = New Size(90, 90)
        Btn_01_VMS.TabIndex = 2
        Btn_01_VMS.Text = "Btn_01_VMS"
        Btn_01_VMS.UseVisualStyleBackColor = True
        ' 
        ' Btn_02_Resto
        ' 
        Btn_02_Resto.BackgroundImageLayout = ImageLayout.Zoom
        Btn_02_Resto.Location = New Point(214, 261)
        Btn_02_Resto.Name = "Btn_02_Resto"
        Btn_02_Resto.Size = New Size(90, 90)
        Btn_02_Resto.TabIndex = 2
        Btn_02_Resto.Text = "Btn_02_Resto"
        Btn_02_Resto.UseVisualStyleBackColor = True
        ' 
        ' Lbl_01_WelcomeText
        ' 
        Lbl_01_WelcomeText.Location = New Point(12, 207)
        Lbl_01_WelcomeText.Name = "Lbl_01_WelcomeText"
        Lbl_01_WelcomeText.Size = New Size(335, 40)
        Lbl_01_WelcomeText.TabIndex = 3
        Lbl_01_WelcomeText.Text = "Lbl_01_WelcomeText"
        Lbl_01_WelcomeText.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Frm_00_01_Landing
        ' 
        AutoScaleDimensions = New SizeF(8F, 18F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(359, 356)
        Controls.Add(Lbl_01_WelcomeText)
        Controls.Add(Btn_02_Resto)
        Controls.Add(Btn_01_VMS)
        Controls.Add(Logo)
        Controls.Add(MenuStrip1)
        Font = New Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MainMenuStrip = MenuStrip1
        Margin = New Padding(3, 4, 3, 4)
        Name = "Frm_00_01_Landing"
        Text = "VMS"
        CType(Logo, ComponentModel.ISupportInitialize).EndInit()
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Logo As PictureBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConfigToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BaseDeDatosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectLanguageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TranslationsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Btn_01_VMS As Button
    Friend WithEvents Btn_02_Resto As Button
    Friend WithEvents Lbl_01_WelcomeText As Label
    Friend WithEvents VersionControlToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AdminToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewUserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChanngeUserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UsersRightsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TablesToolStripMenuItem As ToolStripMenuItem

End Class
