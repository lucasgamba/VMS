<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Mesas_exemplo
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Mesas_exemplo))
        Me.tsRainbow = New System.Windows.Forms.ToolStrip()
        Me.tsbRed = New System.Windows.Forms.ToolStripButton()
        Me.tsbOrange = New System.Windows.Forms.ToolStripButton()
        Me.tsbYellow = New System.Windows.Forms.ToolStripButton()
        Me.tsbGreen = New System.Windows.Forms.ToolStripButton()
        Me.tsbBlue = New System.Windows.Forms.ToolStripButton()
        Me.tsbIndigo = New System.Windows.Forms.ToolStripButton()
        Me.tsbViolet = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbAddOne = New System.Windows.Forms.ToolStripButton()
        Me.tsbAddFive = New System.Windows.Forms.ToolStripButton()
        Me.tsbClear = New System.Windows.Forms.ToolStripButton()
        Me.Logo_01 = New System.Windows.Forms.PictureBox()
        Me.tsRainbow.SuspendLayout()
        CType(Me.Logo_01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        ' tsRainbow
        '
        Me.tsRainbow.AutoSize = False
        Me.tsRainbow.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsRainbow.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRed, Me.tsbOrange, Me.tsbYellow, Me.tsbGreen, Me.tsbBlue, Me.tsbIndigo, Me.tsbViolet, Me.ToolStripSeparator1, Me.tsbAddOne, Me.tsbAddFive, Me.tsbClear})
        Me.tsRainbow.Location = New System.Drawing.Point(0, 0)
        Me.tsRainbow.Name = "tsRainbow"
        Me.tsRainbow.Padding = New System.Windows.Forms.Padding(8)
        Me.tsRainbow.Size = New System.Drawing.Size(914, 74)
        Me.tsRainbow.TabIndex = 0
        '
        ' tsbRed
        '
        Me.tsbRed.BackColor = System.Drawing.Color.FromArgb(CType(220, Byte), CType(57, Byte), CType(18, Byte))
        Me.tsbRed.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbRed.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRed.Name = "tsbRed"
        Me.tsbRed.Size = New System.Drawing.Size(23, 55)
        Me.tsbRed.Text = "Red"
        '
        ' tsbOrange
        '
        Me.tsbOrange.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(153, Byte), CType(0, Byte))
        Me.tsbOrange.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbOrange.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbOrange.Name = "tsbOrange"
        Me.tsbOrange.Size = New System.Drawing.Size(23, 55)
        Me.tsbOrange.Text = "Orange"
        '
        ' tsbYellow
        '
        Me.tsbYellow.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(153, Byte), CType(51, Byte))
        Me.tsbYellow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbYellow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbYellow.Name = "tsbYellow"
        Me.tsbYellow.Size = New System.Drawing.Size(23, 55)
        Me.tsbYellow.Text = "Yellow"
        '
        ' tsbGreen
        '
        Me.tsbGreen.BackColor = System.Drawing.Color.FromArgb(CType(16, Byte), CType(150, Byte), CType(24, Byte))
        Me.tsbGreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbGreen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGreen.Name = "tsbGreen"
        Me.tsbGreen.Size = New System.Drawing.Size(23, 55)
        Me.tsbGreen.Text = "Green"
        '
        ' tsbBlue
        '
        Me.tsbBlue.BackColor = System.Drawing.Color.FromArgb(CType(50, Byte), CType(115, Byte), CType(220, Byte))
        Me.tsbBlue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbBlue.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbBlue.Name = "tsbBlue"
        Me.tsbBlue.Size = New System.Drawing.Size(23, 55)
        Me.tsbBlue.Text = "Blue"
        '
        ' tsbIndigo
        '
        Me.tsbIndigo.BackColor = System.Drawing.Color.FromArgb(CType(126, Byte), CType(47, Byte), CType(142, Byte))
        Me.tsbIndigo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbIndigo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbIndigo.Name = "tsbIndigo"
        Me.tsbIndigo.Size = New System.Drawing.Size(23, 55)
        Me.tsbIndigo.Text = "Indigo"
        '
        ' tsbViolet
        '
        Me.tsbViolet.BackColor = System.Drawing.Color.FromArgb(CType(153, Byte), CType(51, Byte), CType(153, Byte))
        Me.tsbViolet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbViolet.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbViolet.Name = "tsbViolet"
        Me.tsbViolet.Size = New System.Drawing.Size(23, 55)
        Me.tsbViolet.Text = "Violet"
        '
        ' ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 58)
        '
        ' tsbAddOne
        '
        Me.tsbAddOne.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbAddOne.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAddOne.Name = "tsbAddOne"
        Me.tsbAddOne.Size = New System.Drawing.Size(64, 55)
        Me.tsbAddOne.Text = "Add Table"
        '
        ' tsbAddFive
        '
        Me.tsbAddFive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbAddFive.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAddFive.Name = "tsbAddFive"
        Me.tsbAddFive.Size = New System.Drawing.Size(42, 55)
        Me.tsbAddFive.Text = "Add 5"
        '
        ' tsbClear
        '
        Me.tsbClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbClear.Name = "tsbClear"
        Me.tsbClear.Size = New System.Drawing.Size(38, 55)
        Me.tsbClear.Text = "Clear"
        '
        ' Logo_01
        '
        Me.Logo_01.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Logo_01.Location = New System.Drawing.Point(768, 77)
        Me.Logo_01.Name = "Logo_01"
        Me.Logo_01.Size = New System.Drawing.Size(134, 166)
        Me.Logo_01.TabIndex = 1
        Me.Logo_01.TabStop = False
        '
        ' Mesas_exemplo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(914, 540)
        Me.Controls.Add(Me.Logo_01)
        Me.Controls.Add(Me.tsRainbow)
        Me.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Mesas_exemplo"
        Me.Text = "PlayBar"
        Me.tsRainbow.ResumeLayout(False)
        Me.tsRainbow.PerformLayout()
        CType(Me.Logo_01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Friend WithEvents tsRainbow As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbRed As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbOrange As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbYellow As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGreen As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbBlue As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbIndigo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbViolet As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbAddOne As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAddFive As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbClear As System.Windows.Forms.ToolStripButton
    Friend WithEvents Logo_01 As System.Windows.Forms.PictureBox
End Class