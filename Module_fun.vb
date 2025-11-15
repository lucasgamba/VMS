Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports Newtonsoft.Json
Imports System.Reflection
'Imports System.Text.Json
'Imports System.Text.Json.Nodes

Module Module_fun
    Private Const EncryptionKey As String = "LucasLukano0606!"

    ' Tipos que têm a propriedade .Text e devem ser traduzidos
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
        GetType(System.Windows.Forms.Form),
        GetType(System.Windows.Forms.TextBox),
        GetType(System.Windows.Forms.ComboBox),
        GetType(System.Windows.Forms.LinkLabel),
        GetType(System.Windows.Forms.MenuStrip),
        GetType(System.Windows.Forms.ToolStrip),
        GetType(System.Windows.Forms.StatusStrip),
        GetType(System.Windows.Forms.ColumnHeader),
        GetType(System.Windows.Forms.Panel)
    }

    ''' <summary>
    ''' Aplica traduções do banco de dados local a todos os componentes de um formulário
    ''' </summary>
    ''' <param name="form">O formulário a ser traduzido</param>
    Public Sub ApplyTranslations(form As System.Windows.Forms.Form)
        Try
            ' Obtém o ID do idioma atual
            Dim languageId As String = GetCurrentLanguageId()

            ' Se não houver idioma configurado, não aplica traduções
            If String.IsNullOrEmpty(languageId) OrElse languageId = "0" Then
                Return
            End If

            ' Nome do formulário
            Dim formName As String = form.GetType().Name

            ' Carrega todas as traduções do formulário do banco local
            Dim translations As DataTable = GetFormTranslations(formName, languageId)

            ' Se não houver traduções, retorna
            If translations Is Nothing OrElse translations.Rows.Count = 0 Then
                Return
            End If

            ' Traduz o próprio formulário
            ApplyTranslationToControl(form, formName, translations)

            ' Encontra e traduz todos os ToolStrips
            Dim toolStrips = FindAllToolStrips(form)
            For Each ts As ToolStrip In toolStrips
                TranslateToolStripItems(ts, translations)
            Next

            ' Traduz todos os controles regulares
            For Each ctrl As Control In GetAllControls(form)
                If IsTranslatableType(ctrl.GetType()) Then
                    ApplyTranslationToControl(ctrl, ctrl.Name, translations)
                End If
            Next

        Catch ex As Exception
            ' Em caso de erro, apenas registra mas não bloqueia a abertura do formulário
            Debug.WriteLine($"Erro ao aplicar traduções: {ex.Message}")
        End Try
    End Sub

    ''' <summary>
    ''' Obtém o ID do idioma atual do banco de dados local
    ''' </summary>
    Private Function GetCurrentLanguageId() As String
        Try
            Dim sqlStr As String = "SELECT FieldText FROM tbl_User WHERE FieldName = 'Local_LanguageId';"
            Dim dt As DataTable = Module_db.QueryTable_SQLite(sqlStr)
            
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)("FieldText").ToString()
            End If
        Catch ex As Exception
            Debug.WriteLine($"Erro ao obter ID do idioma: {ex.Message}")
        End Try
        
        Return "0"
    End Function

    ''' <summary>
    ''' Carrega todas as traduções de um formulário do banco de dados local
    ''' </summary>
    Private Function GetFormTranslations(formName As String, languageId As String) As DataTable
        Try
            Dim sqlStr As String = $"SELECT ObjectName, TranslationText " &
                                  $"FROM cfg_Translation " &
                                  $"WHERE FormName = '{formName.Replace("'", "''")}' " &
                                  $"AND LanguageID = {languageId} " &
                                  $"AND TranslationText IS NOT NULL " &
                                  $"AND TranslationText <> '';"
            
            Return Module_db.QueryTable_SQLite(sqlStr)
        Catch ex As Exception
            Debug.WriteLine($"Erro ao carregar traduções: {ex.Message}")
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Aplica a tradução a um controle específico
    ''' </summary>
    Private Sub ApplyTranslationToControl(ctrl As Control, objectName As String, translations As DataTable)
        Try
            ' Busca a tradução para este objeto
            Dim rows = translations.Select($"ObjectName = '{objectName.Replace("'", "''")}'")
            
            If rows.Length > 0 Then
                Dim translationText As String = rows(0)("TranslationText").ToString()
                If Not String.IsNullOrEmpty(translationText) Then
                    ctrl.Text = translationText
                End If
            End If
            ' Se não houver tradução, mantém o Text original
        Catch ex As Exception
            Debug.WriteLine($"Erro ao aplicar tradução ao controle {objectName}: {ex.Message}")
        End Try
    End Sub

    ''' <summary>
    ''' Traduz itens de ToolStrip
    ''' </summary>
    Private Sub TranslateToolStripItems(toolStrip As ToolStrip, translations As DataTable)
        Try
            ' Traduz o próprio ToolStrip se tiver nome
            If Not String.IsNullOrEmpty(toolStrip.Name) Then
                Dim rows = translations.Select($"ObjectName = '{toolStrip.Name.Replace("'", "''")}'")
                If rows.Length > 0 Then
                    Dim translationText As String = rows(0)("TranslationText").ToString()
                    If Not String.IsNullOrEmpty(translationText) Then
                        toolStrip.Text = translationText
                    End If
                End If
            End If

            ' Traduz cada item do ToolStrip
            For Each item As ToolStripItem In toolStrip.Items
                If Not String.IsNullOrEmpty(item.Name) Then
                    Dim rows = translations.Select($"ObjectName = '{item.Name.Replace("'", "''")}'")
                    If rows.Length > 0 Then
                        Dim translationText As String = rows(0)("TranslationText").ToString()
                        If Not String.IsNullOrEmpty(translationText) Then
                            item.Text = translationText
                        End If
                    End If
                End If

                ' Se for um item dropdown, processa seus subitens
                If TypeOf item Is ToolStripDropDownItem Then
                    Dim dropDownItem = DirectCast(item, ToolStripDropDownItem)
                    For Each subItem As ToolStripItem In dropDownItem.DropDownItems
                        If Not String.IsNullOrEmpty(subItem.Name) Then
                            Dim rows = translations.Select($"ObjectName = '{subItem.Name.Replace("'", "''")}'")
                            If rows.Length > 0 Then
                                Dim translationText As String = rows(0)("TranslationText").ToString()
                                If Not String.IsNullOrEmpty(translationText) Then
                                    subItem.Text = translationText
                                End If
                            End If
                        End If
                    Next
                End If
            Next
        Catch ex As Exception
            Debug.WriteLine($"Erro ao traduzir ToolStrip: {ex.Message}")
        End Try
    End Sub

    ''' <summary>
    ''' Encontra todos os ToolStrips recursivamente
    ''' </summary>
    Private Function FindAllToolStrips(control As Control) As List(Of ToolStrip)
        Dim toolStrips As New List(Of ToolStrip)

        If TypeOf control Is ToolStrip Then
            toolStrips.Add(DirectCast(control, ToolStrip))
        End If

        For Each childControl As Control In control.Controls
            toolStrips.AddRange(FindAllToolStrips(childControl))
        Next

        Return toolStrips
    End Function

    ''' <summary>
    ''' Obtém todos os controles recursivamente, incluindo os dentro de GroupBox/Panel
    ''' </summary>
    Private Function GetAllControls(root As Control) As List(Of Control)
        Dim controlsList As New List(Of Control)()

        If Not TypeOf root Is ToolStrip Then
            controlsList.Add(root)
        End If

        For Each c As Control In root.Controls
            controlsList.AddRange(GetAllControls(c))
        Next

        Return controlsList
    End Function

    ''' <summary>
    ''' Verifica se o tipo do controle é traduzível
    ''' </summary>
    Private Function IsTranslatableType(type As Type) As Boolean
        Return TranslatableTypes.Any(Function(t) t.IsAssignableFrom(type))
    End Function
    Function EncryptString(plainText As String) As String
        ' Converte o texto simples para bytes
        Dim plainBytes As Byte() = Encoding.UTF8.GetBytes(plainText)

        Using aes As Aes = Aes.Create()
            ' Chave (16 bytes = AES-128. Se precisar de 256 bits, a chave deve ser maior)
            aes.Key = Encoding.UTF8.GetBytes(EncryptionKey).Take(32).ToArray()
            ' IV (16 bytes de zeros - Estático, o que é necessário para decriptação consistente)
            aes.IV = New Byte(15) {}

            Using encryptor As ICryptoTransform = aes.CreateEncryptor(aes.Key, aes.IV)
                Using msEncrypt As New MemoryStream()
                    ' Escreve os bytes diretamente no CryptoStream, sem StreamWriter
                    Using csEncrypt As New CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)
                        csEncrypt.Write(plainBytes, 0, plainBytes.Length)
                    End Using ' csEncrypt.Dispose() lida com o padding e finaliza o bloco

                    ' Converte o resultado final (ciphertext) para Base64
                    Return Convert.ToBase64String(msEncrypt.ToArray())
                End Using
            End Using
        End Using
    End Function
    Function DecryptString(cipherText As String) As String
        ' Converte a string Base64 de volta para bytes
        Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)

        Using aes As Aes = Aes.Create()
            aes.Key = Encoding.UTF8.GetBytes(EncryptionKey).Take(32).ToArray()
            aes.IV = New Byte(15) {}

            Using decryptor As ICryptoTransform = aes.CreateDecryptor(aes.Key, aes.IV)
                Using msDecrypt As New MemoryStream(cipherBytes)
                    Using csDecrypt As New CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)

                        ' Usa um StreamReader interno com Encoding.UTF8 para ler os bytes decriptados
                        ' diretamente do CryptoStream. Isso lida com o processo de decriptação byte a byte.
                        Using srDecrypt As New StreamReader(csDecrypt, Encoding.UTF8)
                            Return srDecrypt.ReadToEnd()
                        End Using

                    End Using
                End Using
            End Using
        End Using
    End Function
    Public Function FormatFileSize(sizeInBytes As Long) As String
        'Helper to set the file sizes
        Dim sizeInKb As Double = sizeInBytes / 1024
        If sizeInKb < 1024 Then
            Dim sizeInKbRounded As Double = Math.Round(sizeInKb, 0)
            'Return sizeInKbRounded.ToString("F2") & " KB"
            Return sizeInKbRounded.ToString() & " KB"
        End If

        Dim sizeInMb As Double = sizeInKb / 1024
        Dim sizeInMbRounded As Double = Math.Round(sizeInMb, 0)
        'Return sizeInMbRounded.ToString("F2") & " MB"
        Return sizeInMbRounded.ToString() & " MB"
    End Function
    Function GenJson(ByVal parameters As Dictionary(Of String, String)) As String
        'Generate Json strings
        Return JsonConvert.SerializeObject(parameters)
    End Function
    Public Function ExtractValue(input As String) As String
        ' Check if the input string contains curly braces
        Dim startIdx As Integer = input.IndexOf("{") + 1
        Dim endIdx As Integer = input.IndexOf("}")

        ' Only return the substring if both braces are found
        If startIdx > 0 AndAlso endIdx > startIdx Then
            Return input.Substring(startIdx, endIdx - startIdx).Trim()
        End If

        ' Return original input or empty string if braces are not found
        Return String.Empty
    End Function
End Module