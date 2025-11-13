'Imports Syncfusion.Licensing

Public Class Frm_00_00_Login

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See https://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_01_OK.Click
        Dim landingForm As New Frm_00_01_Landing
        landingForm.Show()
        Me.Hide()
        'Me.Close()

        'Handle when the landing form is closed
        AddHandler landingForm.FormClosed, AddressOf LandingForm_FormClosed
    End Sub
    Private Sub LandingForm_FormClosed(sender As Object, e As FormClosedEventArgs)
        'Close the application when the landing form is closed
        Me.Close()
    End Sub
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_02_Cancel.Click
        Me.Close()
    End Sub

    Private Sub LoginForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.LogoPictureBox.Image = Image.FromFile(".\logo.png")
        Me.LogoPictureBox.Image = My.Resources.ResourcesPic.logo
    End Sub
End Class
