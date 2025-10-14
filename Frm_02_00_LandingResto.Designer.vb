<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_02_00_LandingResto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_02_00_LandingResto))
        Logo_01 = New PictureBox()
        CType(Logo_01, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Logo_01
        ' 
        Logo_01.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Logo_01.Location = New Point(688, 208)
        Logo_01.Name = "Logo_01"
        Logo_01.Size = New Size(100, 137)
        Logo_01.TabIndex = 0
        Logo_01.TabStop = False
        ' 
        ' Frm_02_00_LandingResto
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Logo_01)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Frm_02_00_LandingResto"
        Text = "PlayBar"
        CType(Logo_01, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Logo_01 As PictureBox
End Class
