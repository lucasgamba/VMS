Public Class Frm_00_02_Translations
    Private Sub Frm_00_02_Translations_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = New Icon(".\icon.ico")
        With Logo_01
            .Image = My.Resources.ResourcesPic.mainLogo
            .SizeMode = PictureBoxSizeMode.Zoom
        End With
    End Sub
End Class