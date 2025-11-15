Imports Syncfusion.Licensing

Public Class Frm_00_01_Landing
    Public Sub New()
        InitializeComponent()
        'Me.Text = String.Format("Login - {0}", My.Application.Info.AssemblyName)

        'SyncFusion License
        SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1JFaF5cXGRCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdmWH9ednVWQmVfWEV/WkpWYEg=")

        Me.Text = String.Format("Login - VMS")
    End Sub
    Private Sub Frm_00_0_Landing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Logo.Image = My.Resources.ResourcesPic.logo

        'Load Translation database
        Call Frm_00_02_Translations.LoadLocalTranslationDb()

        With Btn_01_VMS
            .BackgroundImage = My.Resources.ResourcesPic.VivantLogo
            .BackgroundImageLayout = ImageLayout.Stretch
            .Text = ""
        End With
        With Btn_02_Resto
            .BackgroundImage = My.Resources.ResourcesPic.PlayBarLogoBTN
            .BackgroundImageLayout = ImageLayout.Stretch
            .Text = ""
        End With

        'Apply translations to all form components
        Module_fun.ApplyTranslations(Me)

        'Me.WindowState = FormWindowState.Maximized

    End Sub
    Private Sub BaseDeDatosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BaseDeDatosToolStripMenuItem.Click
        'Call form setup database
        Frm_00_01_FileDbSetup.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        'Close form and exit application
        Close()
    End Sub

    Private Sub TranslationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TranslationsToolStripMenuItem.Click
        'Call form translations
        Frm_00_02_Translations.Show()
    End Sub

    Private Sub Btn_01_VMS_Click(sender As Object, e As EventArgs) Handles Btn_01_VMS.Click
        Me.Hide()
        Frm_01_00_LandingVMS.Show()
    End Sub

    Private Sub Btn_02_Resto_Click(sender As Object, e As EventArgs) Handles Btn_02_Resto.Click
        Me.Hide()
        Frm_02_00_LandingResto.Show()
    End Sub

    Private Sub Frm_00_01_Landing_Closed(sender As Object, e As EventArgs) Handles Me.FormClosed
        'Close all forms and exit application
        End
    End Sub
End Class
