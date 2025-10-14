Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports Newtonsoft.Json

Module Module_fun
    Private Const EncryptionKey As String = "LucasLukano0606!"
    Function EncryptString(plainText As String) As String
        Using aes As Aes = Aes.Create()
            aes.Key = Encoding.UTF8.GetBytes(EncryptionKey).Take(32).ToArray()
            aes.IV = New Byte(15) {}

            Using encryptor As ICryptoTransform = aes.CreateEncryptor(aes.Key, aes.IV)
                Using msEncrypt As New MemoryStream()
                    Using csEncrypt As New CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)
                        Using swEncrypt As New StreamWriter(csEncrypt)
                            swEncrypt.Write(plainText)
                        End Using
                        Return Convert.ToBase64String(msEncrypt.ToArray())
                    End Using
                End Using
            End Using
        End Using
    End Function

    Function DecryptString(cipherText As String) As String
        Using aes As Aes = Aes.Create()
            aes.Key = Encoding.UTF8.GetBytes(EncryptionKey).Take(32).ToArray()
            aes.IV = New Byte(15) {}

            Using decryptor As ICryptoTransform = aes.CreateDecryptor(aes.Key, aes.IV)
                Using msDecrypt As New MemoryStream(Convert.FromBase64String(cipherText))
                    Using csDecrypt As New CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)
                        Using srDecrypt As New StreamReader(csDecrypt)
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