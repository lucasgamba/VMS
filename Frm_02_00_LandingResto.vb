Public Class Frm_02_00_LandingResto

    ' Fraction of the FORM's width the logo should occupy (tune as needed)
    Private ReadOnly LogoFormFraction As Double = 0.23 ' 23% da largura da janela
    Private Sub Frm_02_00_LandingResto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set Logo image and preserve aspect ratio
        With Me.Logo_01
            .Image = My.Resources.ResourcesPic.PlayBarLogoLarge
            .SizeMode = PictureBoxSizeMode.Zoom
        End With

        ' Set window to be maximized
        Me.WindowState = FormWindowState.Maximized

        ' Initial sizing/position of logo
        ResizeLogo()
    End Sub

    Private Sub Frm_02_00_LandingResto_Closed(sender As Object, e As EventArgs) Handles Me.FormClosed
        ' Show main landing form when this form is closed
        Frm_00_01_Landing.Show()
    End Sub

    Private Sub ToolStripButton33_Click(sender As Object, e As EventArgs) Handles ToolStripButton33.Click
        MsgBox("This feature is not yet implemented.", MsgBoxStyle.Information, "Info")
    End Sub

    Private Sub Frm_02_00_LandingResto_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ' Recalculate logo size when the form is resized (covers monitor changes and maximize)
        ResizeLogo()
    End Sub

    Private Sub ResizeLogo()
        If Me.Logo_01.Image Is Nothing OrElse Me.ClientSize.Width = 0 Then
            Return
        End If

        ' **** MUDANÇA CHAVE: Usar Me.ClientSize (Área Interna do Formulário) ****
        ' A largura desejada é uma fração da largura interna do formulário.
        Dim desiredWidth As Integer = CInt(Me.ClientSize.Width * LogoFormFraction)

        ' Preservar a proporção original da imagem (Aspect Ratio)
        Dim img As Image = Me.Logo_01.Image
        Dim aspect As Single = img.Height / CSng(img.Width)
        Dim desiredHeight As Integer = CInt(desiredWidth * aspect)

        ' Aplicar o novo tamanho
        Me.Logo_01.Size = New Size(desiredWidth, desiredHeight)

        ' Opcional: Centralizar Horizontalmente o logo na parte superior da janela
        Me.Logo_01.Left = Math.Max(0, (Me.ClientSize.Width - Me.Logo_01.Width) \ 2)

        ' (O Topo pode ser mantido fixo ou com uma margem pequena, dependendo do seu layout)
        ' Exemplo para fixar a 30 pixels do topo:
        Me.Logo_01.Top = 280
    End Sub

End Class