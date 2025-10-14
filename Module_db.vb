Imports System.Text.Json
Imports System.IO
'Imports MySqlConnector
Imports MySql.Data.MySqlClient
Imports System.Threading.Tasks
'Imports System.Security.Cryptography
'Imports System.Text

Public Class DatabaseSettings
    Public Property ServerName As String
    Public Property DatabaseName As String
    Public Property UserID As String
    Public Property Password As String
    Public Property Port As String
End Class

Module Module_db
    Private ReadOnly SettingsFile As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dbsettings.dat")
    Private Sub EnsureDirectoryExists()

        Dim dir As String = Path.GetDirectoryName(SettingsFile)

        If Not String.IsNullOrEmpty(dir) AndAlso Not Directory.Exists(dir) Then
            Directory.CreateDirectory(dir)
        End If

    End Sub
    Public Sub SaveSettings(settings As DatabaseSettings)
        Try
            EnsureDirectoryExists()
            Dim jsonString = JsonSerializer.Serialize(settings)
            Dim encryptedData = EncryptString(jsonString)
            File.WriteAllText(SettingsFile, encryptedData)
        Catch ex As Exception
            MessageBox.Show($"Error saving settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Function LoadSettings() As DatabaseSettings
        Try
            EnsureDirectoryExists()
            If File.Exists(SettingsFile) Then
                Dim encryptedData = File.ReadAllText(SettingsFile)
                Dim jsonString = DecryptString(encryptedData)
                Return JsonSerializer.Deserialize(Of DatabaseSettings)(jsonString)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error loading settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return New DatabaseSettings()
    End Function
    Public Function DbOpen() As MySqlConnection
        Dim settings = LoadSettings()
        Dim connectionString As String =
               $"Server={settings.ServerName}
               ;Port={settings.Port}
               ;Database={settings.DatabaseName}
               ;Uid={settings.UserID}
               ;Pwd={settings.Password};"
        Return New MySqlConnection(connectionString)
    End Function

    Public Function TestConnection() As Boolean
        Using connection As MySqlConnection = DbOpen()
            Try
                connection.Open()
                Return True
            Catch ex As Exception
                MessageBox.Show($"Connection failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End Using
    End Function
    Public Function QueryTable(SqlStr As String) As DataTable
        Dim dt As New DataTable()
        Dim connectionAttempted As Boolean = False

        Do
            Try
                ' Open the connection 
                Using cnn As MySqlConnection = Module_db.DbOpen()
                    If cnn.State <> ConnectionState.Open Then
                        cnn.Open()
                    End If

                    ' Execute the SQL command
                    Using command As New MySqlCommand(SqlStr, cnn)
                        Using adapter As New MySqlDataAdapter(command)
                            adapter.Fill(dt)
                        End Using
                    End Using

                    ' If we reach here, the query was successful and we can exit the loop
                    Exit Do
                End Using
            Catch ex As MySqlException
                ' Handle MySQL-specific exceptions
                MessageBox.Show("MySQL error: " & ex.Message & vbCrLf & "Please review or update the connection setup...", "MySQL error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                Dim frmSetup As New Frm_00_01_FileDbSetup()
                frmSetup.ShowDialog()

                ' After user closes the form, attempt to reconnect
                connectionAttempted = True
            Catch ex As Exception
                ' General exception handling for other exceptions
                MessageBox.Show("Error executing query: " & ex.Message, "Query Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Do
            End Try
        Loop While connectionAttempted

        Return dt
    End Function

    Public Sub ExecuteSql(SqlStr As String)
        ' Open the connection 
        Using cnn As MySqlConnection = Module_db.DbOpen()
            Try
                If cnn.State <> ConnectionState.Open Then
                    cnn.Open()
                End If

                ' Execute the SQL command
                Using command As New MySqlCommand(SqlStr, cnn)
                    command.ExecuteNonQuery()
                End Using
            Catch ex As MySqlException
                ' Handle MySQL-specific exceptions separately if needed
                MessageBox.Show("MySQL error: " & ex.Message, "Query Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                ' General exception handling for other exceptions
                MessageBox.Show("Error executing query: " & ex.Message, "Query Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

End Module