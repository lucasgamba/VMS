Public Class Frm_02_00_LandingResto
    Private Sub Frm_02_00_LandingResto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Set Logo
        With Me.Logo_01
            .Image = My.Resources.ResourcesPic.PlayBarLogo
            .SizeMode = PictureBoxSizeMode.Zoom
        End With

        'Set windows to be maximized
        Me.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub Frm_02_00_LandingResto_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        ' Show main landing form when this form is closed
        Frm_00_01_Landing.Show()
    End Sub
End Class