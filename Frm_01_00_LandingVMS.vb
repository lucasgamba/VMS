Imports VMS.VMS

Public Class Frm_01_00_LandingVMS
    Private Sub Frm_01_00_LandingVMS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With Me.Logo_01
            .Image = My.Resources.ResourcesPic.VivantLogo
            .SizeMode = PictureBoxSizeMode.Zoom
        End With
    End Sub

    Private Sub Frm_01_00_LandingVMS_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        'Show main landing form when this form is closed
        Frm_00_01_Landing.Show()
    End Sub
End Class