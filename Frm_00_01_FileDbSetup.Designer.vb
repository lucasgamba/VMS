<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_00_01_FileDbSetup
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Label1 = New Label()
        Label2 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label7 = New Label()
        ChkBox_01_enableEdit = New CheckBox()
        Txt_01_serverAddr = New TextBox()
        Txt_02_serverPort = New TextBox()
        Txt_03_username = New TextBox()
        Txt_04_password = New TextBox()
        Btn_01_Close = New Button()
        Btn_02_Test = New Button()
        Btn_03_save = New Button()
        Txt_05_dbName = New TextBox()
        Label8 = New Label()
        Cbox_01_DbService = New ComboBox()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Calibri", 11.25F)
        Label1.Location = New Point(17, 95)
        Label1.Name = "Label1"
        Label1.Size = New Size(121, 28)
        Label1.TabIndex = 0
        Label1.Text = "Server Address:"
        ' 
        ' Label2
        ' 
        Label2.Font = New Font("Calibri", 11.25F)
        Label2.Location = New Point(17, 129)
        Label2.Name = "Label2"
        Label2.Size = New Size(114, 28)
        Label2.TabIndex = 0
        Label2.Text = "Port:"
        ' 
        ' Label4
        ' 
        Label4.Font = New Font("Calibri", 11.25F)
        Label4.Location = New Point(17, 158)
        Label4.Name = "Label4"
        Label4.Size = New Size(114, 28)
        Label4.TabIndex = 1
        Label4.Text = "Username:"
        ' 
        ' Label5
        ' 
        Label5.Font = New Font("Calibri", 11.25F)
        Label5.Location = New Point(17, 191)
        Label5.Name = "Label5"
        Label5.Size = New Size(114, 28)
        Label5.TabIndex = 2
        Label5.Text = "Password:"
        ' 
        ' Label7
        ' 
        Label7.Font = New Font("Calibri", 11.25F)
        Label7.Location = New Point(17, 223)
        Label7.Name = "Label7"
        Label7.Size = New Size(114, 28)
        Label7.TabIndex = 4
        Label7.Text = "DB name:"
        ' 
        ' ChkBox_01_enableEdit
        ' 
        ChkBox_01_enableEdit.AutoSize = True
        ChkBox_01_enableEdit.Font = New Font("Calibri", 11.25F)
        ChkBox_01_enableEdit.Location = New Point(11, 17)
        ChkBox_01_enableEdit.Margin = New Padding(3, 4, 3, 4)
        ChkBox_01_enableEdit.Name = "ChkBox_01_enableEdit"
        ChkBox_01_enableEdit.Size = New Size(216, 22)
        ChkBox_01_enableEdit.TabIndex = 0
        ChkBox_01_enableEdit.Text = "I am sure what I am doing here"
        ChkBox_01_enableEdit.UseVisualStyleBackColor = True
        ' 
        ' Txt_01_serverAddr
        ' 
        Txt_01_serverAddr.BorderStyle = BorderStyle.FixedSingle
        Txt_01_serverAddr.Font = New Font("Calibri", 11.25F)
        Txt_01_serverAddr.Location = New Point(145, 92)
        Txt_01_serverAddr.Margin = New Padding(3, 4, 3, 4)
        Txt_01_serverAddr.Name = "Txt_01_serverAddr"
        Txt_01_serverAddr.Size = New Size(250, 26)
        Txt_01_serverAddr.TabIndex = 1
        ' 
        ' Txt_02_serverPort
        ' 
        Txt_02_serverPort.BorderStyle = BorderStyle.FixedSingle
        Txt_02_serverPort.Font = New Font("Calibri", 11.25F)
        Txt_02_serverPort.Location = New Point(145, 125)
        Txt_02_serverPort.Margin = New Padding(3, 4, 3, 4)
        Txt_02_serverPort.Name = "Txt_02_serverPort"
        Txt_02_serverPort.Size = New Size(250, 26)
        Txt_02_serverPort.TabIndex = 2
        ' 
        ' Txt_03_username
        ' 
        Txt_03_username.BorderStyle = BorderStyle.FixedSingle
        Txt_03_username.Font = New Font("Calibri", 11.25F)
        Txt_03_username.Location = New Point(145, 158)
        Txt_03_username.Margin = New Padding(3, 4, 3, 4)
        Txt_03_username.Name = "Txt_03_username"
        Txt_03_username.Size = New Size(250, 26)
        Txt_03_username.TabIndex = 4
        ' 
        ' Txt_04_password
        ' 
        Txt_04_password.BorderStyle = BorderStyle.FixedSingle
        Txt_04_password.Font = New Font("Calibri", 11.25F)
        Txt_04_password.Location = New Point(145, 191)
        Txt_04_password.Margin = New Padding(3, 4, 3, 4)
        Txt_04_password.Name = "Txt_04_password"
        Txt_04_password.PasswordChar = "*"c
        Txt_04_password.Size = New Size(250, 26)
        Txt_04_password.TabIndex = 5
        ' 
        ' Btn_01_Close
        ' 
        Btn_01_Close.Font = New Font("Calibri", 11.25F)
        Btn_01_Close.Location = New Point(309, 265)
        Btn_01_Close.Margin = New Padding(3, 4, 3, 4)
        Btn_01_Close.Name = "Btn_01_Close"
        Btn_01_Close.Size = New Size(86, 28)
        Btn_01_Close.TabIndex = 10
        Btn_01_Close.Text = "Close"
        Btn_01_Close.UseVisualStyleBackColor = True
        ' 
        ' Btn_02_Test
        ' 
        Btn_02_Test.Font = New Font("Calibri", 11.25F)
        Btn_02_Test.Location = New Point(11, 265)
        Btn_02_Test.Margin = New Padding(3, 4, 3, 4)
        Btn_02_Test.Name = "Btn_02_Test"
        Btn_02_Test.Size = New Size(86, 28)
        Btn_02_Test.TabIndex = 8
        Btn_02_Test.Text = "Test"
        Btn_02_Test.UseVisualStyleBackColor = True
        ' 
        ' Btn_03_save
        ' 
        Btn_03_save.Font = New Font("Calibri", 11.25F)
        Btn_03_save.Location = New Point(216, 265)
        Btn_03_save.Margin = New Padding(3, 4, 3, 4)
        Btn_03_save.Name = "Btn_03_save"
        Btn_03_save.Size = New Size(86, 28)
        Btn_03_save.TabIndex = 9
        Btn_03_save.Text = "Save"
        Btn_03_save.UseVisualStyleBackColor = True
        ' 
        ' Txt_05_dbName
        ' 
        Txt_05_dbName.BorderStyle = BorderStyle.FixedSingle
        Txt_05_dbName.Font = New Font("Calibri", 11.25F)
        Txt_05_dbName.Location = New Point(145, 224)
        Txt_05_dbName.Margin = New Padding(3, 4, 3, 4)
        Txt_05_dbName.Name = "Txt_05_dbName"
        Txt_05_dbName.Size = New Size(250, 26)
        Txt_05_dbName.TabIndex = 6
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Calibri", 11.25F)
        Label8.Location = New Point(17, 62)
        Label8.Name = "Label8"
        Label8.Size = New Size(57, 18)
        Label8.TabIndex = 11
        Label8.Text = "Service:"
        ' 
        ' Cbox_01_DbService
        ' 
        Cbox_01_DbService.FormattingEnabled = True
        Cbox_01_DbService.Location = New Point(145, 59)
        Cbox_01_DbService.Name = "Cbox_01_DbService"
        Cbox_01_DbService.Size = New Size(250, 26)
        Cbox_01_DbService.TabIndex = 12
        ' 
        ' Frm_00_01_FileDbSetup
        ' 
        AutoScaleDimensions = New SizeF(8F, 18F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(408, 301)
        Controls.Add(Cbox_01_DbService)
        Controls.Add(Label8)
        Controls.Add(Btn_02_Test)
        Controls.Add(Btn_03_save)
        Controls.Add(Btn_01_Close)
        Controls.Add(Txt_05_dbName)
        Controls.Add(Txt_04_password)
        Controls.Add(Txt_03_username)
        Controls.Add(Txt_02_serverPort)
        Controls.Add(Txt_01_serverAddr)
        Controls.Add(ChkBox_01_enableEdit)
        Controls.Add(Label7)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Font = New Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Margin = New Padding(3, 4, 3, 4)
        Name = "Frm_00_01_FileDbSetup"
        Text = "Connection Setup"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents ChkBox_01_enableEdit As CheckBox
    Friend WithEvents Txt_01_serverAddr As TextBox
    Friend WithEvents Txt_02_serverPort As TextBox
    Friend WithEvents Txt_03_username As TextBox
    Friend WithEvents Txt_04_password As TextBox
    Friend WithEvents Btn_01_Close As Button
    Friend WithEvents Btn_02_Test As Button
    Friend WithEvents Cbox_01_dbEngine As ComboBox
    Friend WithEvents Cbox_02_dbName As ComboBox
    Friend WithEvents Btn_03_save As Button
    Friend WithEvents Txt_05_dbName As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Cbox_01_DbService As ComboBox
End Class
