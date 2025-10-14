<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_01_00_LandingVMS
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_01_00_LandingVMS))
        Logo_01 = New PictureBox()
        CType(Logo_01, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Logo_01
        ' 
        Logo_01.Location = New Point(307, 193)
        Logo_01.Name = "Logo_01"
        Logo_01.Size = New Size(300, 300)
        Logo_01.TabIndex = 2
        Logo_01.TabStop = False
        ' 
        ' Frm_01_00_LandingVMS
        ' 
        AutoScaleDimensions = New SizeF(8F, 18F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(914, 540)
        Controls.Add(Logo_01)
        Font = New Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        IsMdiContainer = True
        Margin = New Padding(3, 4, 3, 4)
        Name = "Frm_01_00_LandingVMS"
        Text = "VMS"
        CType(Logo_01, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents Logo_01 As PictureBox
End Class
