<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class Frm_00_00_Login
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents UsernameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        LogoPictureBox = New PictureBox()
        UsernameLabel = New Label()
        PasswordLabel = New Label()
        UsernameTextBox = New TextBox()
        PasswordTextBox = New TextBox()
        OK = New Button()
        Cancel = New Button()
        CType(LogoPictureBox, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LogoPictureBox
        ' 
        LogoPictureBox.Location = New Point(0, 0)
        LogoPictureBox.Margin = New Padding(3, 4, 3, 4)
        LogoPictureBox.Name = "LogoPictureBox"
        LogoPictureBox.Size = New Size(189, 231)
        LogoPictureBox.SizeMode = PictureBoxSizeMode.Zoom
        LogoPictureBox.TabIndex = 0
        LogoPictureBox.TabStop = False
        ' 
        ' UsernameLabel
        ' 
        UsernameLabel.Location = New Point(197, 29)
        UsernameLabel.Name = "UsernameLabel"
        UsernameLabel.Size = New Size(251, 28)
        UsernameLabel.TabIndex = 0
        UsernameLabel.Text = "&User name"
        UsernameLabel.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' PasswordLabel
        ' 
        PasswordLabel.Location = New Point(197, 97)
        PasswordLabel.Name = "PasswordLabel"
        PasswordLabel.Size = New Size(251, 28)
        PasswordLabel.TabIndex = 2
        PasswordLabel.Text = "&Password"
        PasswordLabel.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' UsernameTextBox
        ' 
        UsernameTextBox.Location = New Point(199, 53)
        UsernameTextBox.Margin = New Padding(3, 4, 3, 4)
        UsernameTextBox.Name = "UsernameTextBox"
        UsernameTextBox.Size = New Size(251, 26)
        UsernameTextBox.TabIndex = 1
        ' 
        ' PasswordTextBox
        ' 
        PasswordTextBox.Location = New Point(199, 122)
        PasswordTextBox.Margin = New Padding(3, 4, 3, 4)
        PasswordTextBox.Name = "PasswordTextBox"
        PasswordTextBox.PasswordChar = "*"c
        PasswordTextBox.Size = New Size(251, 26)
        PasswordTextBox.TabIndex = 3
        ' 
        ' OK
        ' 
        OK.Location = New Point(225, 194)
        OK.Margin = New Padding(3, 4, 3, 4)
        OK.Name = "OK"
        OK.Size = New Size(107, 28)
        OK.TabIndex = 4
        OK.Text = "&OK"
        ' 
        ' Cancel
        ' 
        Cancel.DialogResult = DialogResult.Cancel
        Cancel.Location = New Point(343, 194)
        Cancel.Margin = New Padding(3, 4, 3, 4)
        Cancel.Name = "Cancel"
        Cancel.Size = New Size(107, 28)
        Cancel.TabIndex = 5
        Cancel.Text = "&Cancel"
        ' 
        ' Frm_00_00_Login
        ' 
        AcceptButton = OK
        AutoScaleDimensions = New SizeF(8F, 18F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = Cancel
        ClientSize = New Size(458, 230)
        Controls.Add(Cancel)
        Controls.Add(OK)
        Controls.Add(PasswordTextBox)
        Controls.Add(UsernameTextBox)
        Controls.Add(PasswordLabel)
        Controls.Add(UsernameLabel)
        Controls.Add(LogoPictureBox)
        Font = New Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(3, 4, 3, 4)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Frm_00_00_Login"
        SizeGripStyle = SizeGripStyle.Hide
        StartPosition = FormStartPosition.CenterParent
        Text = "VMS Login"
        CType(LogoPictureBox, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub

End Class
