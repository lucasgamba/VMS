Public Class Frm_00_01_FileDbSetup
    Private Sub DatabaseSettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = New Icon(".\Pictures\icon.ico")

        'Load DB Engines options
        Dim availableEngines = Module_db.LoadDbEngine()

        With Me.Cbox_01_DbService
            .DataSource = availableEngines
            .DisplayMember = "Description"
            .ValueMember = "Key"
        End With

        With Me
            .Txt_01_serverAddr.Enabled = False
            .Txt_02_serverPort.Enabled = False
            .Txt_03_username.Enabled = False
            .Txt_04_password.Enabled = False
            .Txt_05_dbName.Enabled = False
            '.Cbox_01_DbService.Enabled = False
            '.Btn_02_Test.Enabled = False
        End With

        ' Apply translations to all form components
        Module_fun.ApplyTranslations(Me)
    End Sub
    Private Sub SaveSettingsFromForm()
        Dim settings As New DatabaseSettings With {
            .EngineId = Me.Cbox_01_DbService.SelectedValue,
            .ServerName = Txt_01_serverAddr.Text,
            .DatabaseName = Txt_05_dbName.Text,
            .UserID = Txt_03_username.Text,
            .Password = Txt_04_password.Text,
            .Port = Txt_02_serverPort.Text
        }
        Module_db.SaveSettings(settings)
        'MessageBox.Show("Settings saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'MessageBox.Show(Module_fun.EncryptString(Txt_01_serverAddr.Text))
    End Sub

    Private Sub LoadSettingsToForm()
        Dim selectedItem As Module_db.DbEngineInfo = CType(Me.Cbox_01_DbService.SelectedItem, Module_db.DbEngineInfo)
        Dim dbEngId As Integer = selectedItem.Key

        Dim settings = Module_db.LoadSettings(dbEngId)
        Txt_01_serverAddr.Text = settings.ServerName
        Txt_05_dbName.Text = settings.DatabaseName
        Txt_03_username.Text = settings.UserID
        Txt_04_password.Text = settings.Password
        Txt_02_serverPort.Text = settings.Port
    End Sub

    Private Sub Btn_02_Test_Click(sender As Object, e As EventArgs) Handles Btn_02_Test.Click
        'Test DB Connection MySQL
        If Me.Cbox_01_DbService.SelectedValue = 1 Then
            If Module_db.TestConnection_MySQL(1) Then
                MessageBox.Show("Connection successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

        'Test DB Connection Oracle
        If Me.Cbox_01_DbService.SelectedValue = 2 Then
            If Module_db.TestConnection_Oracle(2) Then
                MessageBox.Show("Connection successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub Btn_03_save_Click(sender As Object, e As EventArgs) Handles Btn_03_save.Click
        SaveSettingsFromForm()
        Me.Btn_02_Test.Enabled = True
        MessageBox.Show("Settings saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Btn_01_Close_Click(sender As Object, e As EventArgs) Handles Btn_01_Close.Click
        Me.Close()
    End Sub

    Private Sub Txt_01_serverAddr_ModifiedChanged(sender As Object, e As EventArgs) Handles Txt_01_serverAddr.Leave
        'Me.Btn_02_Test.Enabled = False
        Me.SaveSettingsFromForm()
    End Sub

    Private Sub Txt_02_serverPort_ModifiedChanged(sender As Object, e As EventArgs) Handles Txt_02_serverPort.Leave
        'Me.Btn_02_Test.Enabled = False
        Me.SaveSettingsFromForm()
    End Sub

    Private Sub Txt_03_username_ModifiedChanged(sender As Object, e As EventArgs) Handles Txt_03_username.Leave
        'Me.Btn_02_Test.Enabled = False
        Me.SaveSettingsFromForm()
    End Sub

    Private Sub Txt_04_password_ModifiedChanged(sender As Object, e As EventArgs) Handles Txt_04_password.Leave
        'Me.Btn_02_Test.Enabled = False
        Me.SaveSettingsFromForm()
    End Sub

    Private Sub Txt_05_dbName_ModifiedChanged(sender As Object, e As EventArgs) Handles Txt_05_dbName.Leave
        'Me.Btn_02_Test.Enabled = False
        Me.SaveSettingsFromForm()
    End Sub

    Private Sub ChkBox_01_enableEdit_CheckedChanged(sender As Object, e As EventArgs) Handles ChkBox_01_enableEdit.CheckedChanged
        With Me
            If .ChkBox_01_enableEdit.Checked = True Then
                .Txt_01_serverAddr.Enabled = True
                .Txt_02_serverPort.Enabled = True
                .Txt_03_username.Enabled = True
                .Txt_04_password.Enabled = True
                .Txt_05_dbName.Enabled = True
                .Cbox_01_DbService.Enabled = True
            Else
                .Txt_01_serverAddr.Enabled = False
                .Txt_02_serverPort.Enabled = False
                .Txt_03_username.Enabled = False
                .Txt_04_password.Enabled = False
                .Txt_05_dbName.Enabled = False
                .Cbox_01_DbService.Enabled = False
            End If
        End With
    End Sub

    Private Sub Cbox_01_DbService_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cbox_01_DbService.SelectedIndexChanged
        Me.LoadSettingsToForm()
    End Sub

End Class