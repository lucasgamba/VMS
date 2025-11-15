Imports System.IO
Imports System.Data ' Para ConnectionState, DataTable, IDbConnection
Imports Microsoft.Data.Sqlite
Imports MySql.Data.MySqlClient
Imports Oracle.ManagedDataAccess.Client ' Assumindo o uso deste driver

' Classe para armazenar as credenciais, lidas do SQLite
Public Class DatabaseSettings
    Public Property EngineId As Integer ' Novo: Chave de identificação (e.g., "MYSQL_MAIN", "ORACLE_HR")
    Public Property EngineType As String ' Novo: Tipo de banco de dados (e.g., "MySQL", "Oracle")
    Public Property ServerName As String
    Public Property DatabaseName As String ' Usado como SID/Service Name/Database Name
    Public Property UserID As String
    Public Property Password As String
    Public Property Port As String
End Class

Module Module_db
    Private ReadOnly DB_FILE As String = "VMS_Local.db"
    Private ReadOnly SQLITE_CONNECTION_STRING As String = $"Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DB_FILE)}"

    ' ================================================
    ' === A: PERSISTÊNCIA DE CONFIGURAÇÃO (SQLITE) ===
    ' ================================================
    'Carregar todos os DB Engines disponiveis
    Public Class DbEngineInfo
        Public Property Key As Integer
        Public Property Description As String
    End Class
    Public Function LoadDbEngine() As List(Of DbEngineInfo)

        Dim engines As New List(Of DbEngineInfo)()
        Dim sql As String = "SELECT ID, DatabaseEngine FROM cfg_DbEngine;"

        Try
            Using connection As SqliteConnection = DbOpen_SQLite()
                connection.Open()

                Using command As New SqliteCommand(sql, connection)
                    Using reader As SqliteDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim info As New DbEngineInfo() With {
                                .Key = Convert.ToInt32(reader("ID")),
                                .Description = reader("DatabaseEngine").ToString()
                            }
                            engines.Add(info)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Erro ao carregar DB Engines: {ex.Message}", "Erro de Inicialização do SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return engines
    End Function
    Public Function LoadSettings(engineID As Integer) As DatabaseSettings
        ' Carrega as configurações de conexão (MySQL, Oracle, etc.) do SQLite
        Dim settings As New DatabaseSettings() With {.EngineId = engineID}

        Dim sql As String = "SELECT ServerAddress, DbName, UserName, Password, ServerPort " &
                            "FROM cfg_DbSettings WHERE EngineId = @key;"

        Try
            Using connection As New SqliteConnection(SQLITE_CONNECTION_STRING)
                connection.Open()
                Using command As New SqliteCommand(sql, connection)
                    command.Parameters.AddWithValue("@key", engineID)
                    Using reader As SqliteDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            settings.ServerName = Module_fun.DecryptString(reader("ServerAddress").ToString())
                            settings.DatabaseName = Module_fun.DecryptString(reader("DbName").ToString())
                            settings.UserID = Module_fun.DecryptString(reader("UserName").ToString())
                            settings.Port = Module_fun.DecryptString(reader("ServerPort").ToString())
                            settings.Password = Module_fun.DecryptString(reader("Password").ToString())
                            Return settings
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ' Em caso de erro (DB local não existe), retorna objeto vazio, pronto para ser configurado.
            MessageBox.Show($"Erro ao carregar DB Engines: {ex.Message}", "Erro de Inicialização do SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return settings
    End Function

    Public Sub SaveSettings(settings As DatabaseSettings)
        ' Salva as configurações de conexão no SQLite
        Dim SqlStr As String =
            "UPDATE cfg_DbSettings " &
            "SET ServerAddress = @ServerAddress, " &
            "DbName = @DbName, " &
            "UserName = @UserName, " &
            "Password = @Password, " &
            "ServerPort = @ServerPort " &
            "WHERE EngineId = @EngineId; "

        Try
            Using connection As New SqliteConnection(SQLITE_CONNECTION_STRING)
                connection.Open()
                Using command As New SqliteCommand(SqlStr, connection)
                    command.Parameters.AddWithValue("@EngineId", settings.EngineId)
                    command.Parameters.AddWithValue("@ServerAddress", Module_fun.EncryptString(settings.ServerName))
                    command.Parameters.AddWithValue("@DbName", Module_fun.EncryptString(settings.DatabaseName))
                    command.Parameters.AddWithValue("@UserName", Module_fun.EncryptString(settings.UserID))
                    command.Parameters.AddWithValue("@Password", Module_fun.EncryptString(settings.Password))
                    command.Parameters.AddWithValue("@ServerPort", Module_fun.EncryptString(settings.Port))
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Erro ao salvar configurações: {ex.Message}", "Erro de Salvamento do SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =============================
    ' === B: CONEXÕES DINÂMICAS ===
    ' =============================

    Public Function DbOpen_SQLite() As SqliteConnection
        ' 1. Conexão SQLITE Local
        Return New SqliteConnection(SQLITE_CONNECTION_STRING)
    End Function

    Public Function DbOpen_MySQL(engineKey As String) As MySqlConnection
        ' 2. Conexão MySQL (Carrega a partir da chave)
        Dim settings = LoadSettings(engineKey)
        Dim connectionString As String =
                $"Server={settings.ServerName}" &
                $";Port={settings.Port}" &
                $";Database={settings.DatabaseName}" &
                $";Uid={settings.UserID}" &
                $";Pwd={settings.Password};"
        Return New MySqlConnection(connectionString)
    End Function

    Public Function DbOpen_Oracle(engineKey As String) As OracleConnection
        ' 3. Conexão ORACLE (Carrega a partir da chave)
        Dim settings = LoadSettings(engineKey)
        ' ATENÇÃO: A string de conexão Oracle varia (SID, Service Name, Easy Connect). 
        Dim connectionString As String =
                $"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={settings.ServerName})(PORT={settings.Port}))" &
                $"(CONNECT_DATA=(SERVICE_NAME={settings.DatabaseName})));" &
                $"User Id={settings.UserID};Password={settings.Password};"

        Return New OracleConnection(connectionString)
    End Function

    ' =========================================================
    ' === C: EXECUÇÃO DE QUERIES GENERALIZADAS (por ENGINE) ===
    ' =========================================================
    Public Function QueryTable_MySQL(SqlStr As String, engineKey As String) As DataTable
        ' --- Execução MySQL ---
        Dim dt As New DataTable()
        ' Tenta abrir e executar a query
        Using cnn As MySqlConnection = DbOpen_MySQL(engineKey)
            Try
                cnn.Open()
                Using command As New MySqlCommand(SqlStr, cnn)
                    Using adapter As New MySqlDataAdapter(command)
                        adapter.Fill(dt)
                    End Using
                End Using
            Catch ex As MySqlException
                ' Lógica de tratamento de erro e reconfiguração (como no seu código)
                MessageBox.Show($"MySQL error: {ex.Message}", "MySQL Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ' Retorna dt vazio
            End Try
        End Using
        Return dt
    End Function
    Public Sub ExecuteMySql(SqlStr As String, EngineId As Integer)
        ' ExecuteSql_MySQL
        ' Open the connection 
        Using cnn As MySqlConnection = Module_db.DbOpen_MySQL(EngineId)
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
    ' --- Execução SQLITE (Novo) ---
    Public Function QueryTable_SQLite(SqlStr As String) As DataTable
        Dim dt As New DataTable()

        Using cnn As SqliteConnection = DbOpen_SQLite()
            Try
                cnn.Open()
                Using command As New SqliteCommand(SqlStr, cnn)
                    Using reader As SqliteDataReader = command.ExecuteReader()

                        ' 1. Cria as colunas do DataTable (Obrigatório para o DataReader)
                        For i As Integer = 0 To reader.FieldCount - 1
                            ' Cria a coluna usando o nome do campo e o tipo de dado
                            dt.Columns.Add(reader.GetName(i), reader.GetFieldType(i))
                        Next

                        ' 2. Preenche as linhas do DataTable
                        While reader.Read()
                            Dim rowValues As Object() = New Object(reader.FieldCount - 1) {}
                            ' Copia todos os valores da linha do reader para o array de objetos
                            reader.GetValues(rowValues)
                            ' Adiciona uma nova linha ao DataTable com os valores
                            dt.Rows.Add(rowValues)
                        End While

                    End Using ' Fecha o DataReader
                End Using ' Fecha o Command
            Catch ex As Exception
                MessageBox.Show($"SQLite error: {ex.Message}", "SQLite Query Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using ' Fecha a Connection

        Return dt
    End Function
    Public Sub ExecuteSQLite(SqlStr As String)
        ' ExecuteSql_SQLite
        ' Open the connection 
        Using cnn As SqliteConnection = Module_db.DbOpen_SQLite()
            Try
                If cnn.State <> ConnectionState.Open Then
                    cnn.Open()
                End If
                ' Execute the SQL command
                Using command As New SqliteCommand(SqlStr, cnn)
                    command.ExecuteNonQuery()
                End Using
            Catch ex As Exception
                ' General exception handling for other exceptions
                MessageBox.Show("Error executing query: " & ex.Message, "Query Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub
    Public Function QueryTable_Oracle(SqlStr As String, engineKey As String) As DataTable
        ' --- Execução ORACLE ---
        Dim dt As New DataTable()
        Using cnn As OracleConnection = DbOpen_Oracle(engineKey)
            Try
                cnn.Open()
                Using command As New OracleCommand(SqlStr, cnn)
                    Using adapter As New OracleDataAdapter(command) ' Usa OracleDataAdapter
                        adapter.Fill(dt)
                    End Using
                End Using
            Catch ex As OracleException
                MessageBox.Show($"Oracle error: {ex.Message}", "Oracle Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End Using
        Return dt
    End Function

    Public Function TestConnection_MySQL(EngineId As Integer) As Boolean
        'Test DB Connection MySQL
        Using connection As MySqlConnection = DbOpen_MySQL(EngineId)
            Try
                connection.Open()
                Return True
            Catch ex As Exception
                MessageBox.Show($"Connection failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End Using

    End Function
    Public Function TestConnection_Oracle(EngineId As Integer) As Boolean
        'Test DB Connection Oracle
        Using connection As OracleConnection = DbOpen_Oracle(EngineId)
            Try
                connection.Open()
                Return True
            Catch ex As Exception
                MessageBox.Show($"Connection failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End Using

    End Function
    'Public Function QueryTable(SqlStr As String) As DataTable
    '    Dim dt As New DataTable()
    '    Dim connectionAttempted As Boolean = False

    '    Do
    '        Try
    '            ' Open the connection 
    '            Using cnn As MySqlConnection = Module_db.DbOpen()
    '                If cnn.State <> ConnectionState.Open Then
    '                    cnn.Open()
    '                End If

    '                ' Execute the SQL command
    '                Using command As New MySqlCommand(SqlStr, cnn)
    '                    Using adapter As New MySqlDataAdapter(command)
    '                        adapter.Fill(dt)
    '                    End Using
    '                End Using

    '                ' If we reach here, the query was successful and we can exit the loop
    '                Exit Do
    '            End Using
    '        Catch ex As MySqlException
    '            ' Handle MySQL-specific exceptions
    '            MessageBox.Show("MySQL error: " & ex.Message & vbCrLf & "Please review or update the connection setup...", "MySQL error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

    '            Dim frmSetup As New Frm_00_01_FileDbSetup()
    '            frmSetup.ShowDialog()

    '            ' After user closes the form, attempt to reconnect
    '            connectionAttempted = True
    '        Catch ex As Exception
    '            ' General exception handling for other exceptions
    '            MessageBox.Show("Error executing query: " & ex.Message, "Query Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            Exit Do
    '        End Try
    '    Loop While connectionAttempted

    '    Return dt
    'End Function



End Module