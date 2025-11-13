Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports Newtonsoft.Json
'Imports System.Text.Json
'Imports System.Text.Json.Nodes

Module Module_fun
    Private Const EncryptionKey As String = "LucasLukano0606!"
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