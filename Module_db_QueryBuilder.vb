Imports Newtonsoft.Json ' Principal biblioteca de JSON
Imports Newtonsoft.Json.Linq ' Necessário para usar JObject e JToken
'Imports module_db.
Module Module_db_QueryBuilder
    Public Function GenSQL(
        Sp As String,
        Action_Ext As String,
        ByVal PrimaryParametersJson As String
    ) As String

        ' --- 1. PREPARAÇÃO DO JSON BASE ---
        Dim activeUserValue As String = Get_ActiveUser()
        Dim languageIdValue As String = Get_LanguageId()
        Dim jObjectParams As JObject = Nothing

        Try
            ' Tenta fazer o parse da string JSON de filtros usando Newtonsoft.Json.
            If Not String.IsNullOrEmpty(PrimaryParametersJson) Then
                ' Parse a string JSON para um JObject manipulável
                jObjectParams = JObject.Parse(PrimaryParametersJson)
            Else
                ' Se a string for nula/vazia, inicializa um JObject vazio ({})
                jObjectParams = New JObject()
            End If
        Catch ex As Exception
            ' Em caso de JSON inválido, cria um objeto vazio para evitar falha
            jObjectParams = New JObject()
        End Try

        ' --- 2. INJEÇÃO DO LANGUAGE ID ---

        ' Adiciona (ou sobrescreve, se já existir) a propriedade LanguageId_Ext
        jObjectParams("LanguageId_Ext") = languageIdValue

        ' Serializa o JObject COMPLETO (com o LanguageId) para a string final.
        Dim Final_Param_Ext As String = jObjectParams.ToString(Formatting.None)

        ' --- 3. MONTAGEM DO COMANDO CALL ---

        ' Monta a string no formato exato: call Sp('Action_Ext','{...JSON...}','User')
        Dim SQLStr As String = $"call {Sp}('{Action_Ext}','{Final_Param_Ext}','{activeUserValue}')"

        Return SQLStr

    End Function
    Private Function Get_ActiveUser() As String
        'Function to get the active user

        Dim SqlStr As String = "SELECT FieldText from tbl_User WHERE FieldName = 'Local_Username';"

        Dim dt As New DataTable
        dt = QueryTable_SQLite(SqlStr)

        Return dt.Rows(0).Item("FieldText").ToString()
    End Function
    Private Function Get_LanguageId() As String
        ' Function to get the language ID

        Dim SqlStr As String = "SELECT FieldText from tbl_User WHERE FieldName = 'Local_LanguageId';"

        Dim dt As New DataTable
        dt = QueryTable_SQLite(SqlStr)

        Return dt.Rows(0).Item("FieldText").ToString()

    End Function

End Module
