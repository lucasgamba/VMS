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

        ' Apply translations to all form components
        Module_fun.ApplyTranslations(Me)
    End Sub
    Private Sub Frm_02_00_LandingResto_Closed(sender As Object, e As EventArgs) Handles Me.FormClosed
        ' Show main landing form when this form is closed
        Frm_00_01_Landing.Show()
    End Sub
    Private Sub Frm_02_00_LandingResto_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ' Recalculate logo size when the form is resized (covers monitor changes and maximize)
        ResizeLogo()
    End Sub
    Private Sub ResizeLogo()
        If Me.Logo_01.Image Is Nothing OrElse Me.ClientSize.Width = 0 Then
            Return
        End If

        ' A largura desejada é uma fração da largura interna do formulário.
        Dim desiredWidth As Integer = CInt(Me.ClientSize.Width * LogoFormFraction)

        ' Preservar a proporção original da imagem (Aspect Ratio)
        Dim img As Image = Me.Logo_01.Image
        Dim aspect As Single = img.Height / CSng(img.Width)
        Dim desiredHeight As Integer = CInt(desiredWidth * aspect)

        ' Aplicar o novo tamanho
        Me.Logo_01.Size = New Size(desiredWidth, desiredHeight)

        ' Centralizar Horizontalmente o logo na parte superior da janela
        Me.Logo_01.Left = Math.Max(0, (Me.ClientSize.Width - Me.Logo_01.Width) \ 2)

        ' O Topo pode ser mantido fixo ou com uma margem pequena
        Me.Logo_01.Top = 280

    End Sub
    'Adicionar evento para mostrar o logo quando todos os forms forem fechados**
    Private Sub Frm_02_00_LandingResto_MdiChildActivate(sender As Object, e As EventArgs) Handles Me.MdiChildActivate
        ' Se não há nenhum formulário filho ativo, mostra o logo
        If Me.ActiveMdiChild Is Nothing Then
            Me.Logo_01.Visible = True
            Me.Logo_01.BringToFront()
        Else
            'Esconde o logo quando há um form aberto**
            Me.Logo_01.Visible = False
        End If
    End Sub

    Private Sub Main_Btn_01_Cashier_OpenClose_Click(sender As Object, e As EventArgs) Handles Main_Btn_01_Cashier_OpenClose.Click
        'Call form CashFlow Movements
        Dim cashFlow As New Frm_02_01_MainCashFlow()
        OpenChildForm(cashFlow)
    End Sub
    Private Sub OpenChildForm(childForm As Form)
        ' Close any existing child form
        'For Each frm As Form In Me.MdiChildren
        '    frm.Close()
        'Next
        ' Set the new child form's properties and show it
        With childForm
            .MdiParent = Me
            '.WindowState = FormWindowState.Maximized
            .Show()
        End With

        'Garantee logo is at the back0000000
        Me.Logo_01.SendToBack()

    End Sub
End Class