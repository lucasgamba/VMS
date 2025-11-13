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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Mesas_exemplo))
        tsRainbow = New ToolStrip()
        tsbRed = New ToolStripButton()
        tsbOrange = New ToolStripButton()
        tsbYellow = New ToolStripButton()
        tsbGreen = New ToolStripButton()
        tsbBlue = New ToolStripButton()
        tsbIndigo = New ToolStripButton()
        tsbViolet = New ToolStripButton()
        ToolStripSeparator1 = New ToolStripSeparator()
        tsbAddOne = New ToolStripButton()
        tsbAddFive = New ToolStripButton()
        tsbClear = New ToolStripButton()
        Logo_01 = New PictureBox()
        ToolStripButton1 = New ToolStripButton()
        ToolStripSeparator2 = New ToolStripSeparator()
        TableLayoutPanel1 = New TableLayoutPanel()
        tsRainbow.SuspendLayout()
        CType(Logo_01, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' tsRainbow
        ' 
        tsRainbow.AutoSize = False
        tsRainbow.GripStyle = ToolStripGripStyle.Hidden
        tsRainbow.Items.AddRange(New ToolStripItem() {tsbRed, tsbOrange, tsbYellow, tsbGreen, tsbBlue, tsbIndigo, tsbViolet, ToolStripSeparator1, tsbAddOne, tsbAddFive, tsbClear, ToolStripButton1, ToolStripSeparator2})
        tsRainbow.Location = New Point(0, 0)
        tsRainbow.Name = "tsRainbow"
        tsRainbow.Padding = New Padding(8)
        tsRainbow.Size = New Size(914, 74)
        tsRainbow.TabIndex = 0
        ' 
        ' tsbRed
        ' 
        tsbRed.BackColor = Color.FromArgb(CByte(220), CByte(57), CByte(18))
        tsbRed.DisplayStyle = ToolStripItemDisplayStyle.Image
        tsbRed.ImageTransparentColor = Color.Magenta
        tsbRed.Name = "tsbRed"
        tsbRed.Size = New Size(23, 55)
        tsbRed.Text = "Red"
        ' 
        ' tsbOrange
        ' 
        tsbOrange.BackColor = Color.FromArgb(CByte(255), CByte(153), CByte(0))
        tsbOrange.DisplayStyle = ToolStripItemDisplayStyle.Image
        tsbOrange.ImageTransparentColor = Color.Magenta
        tsbOrange.Name = "tsbOrange"
        tsbOrange.Size = New Size(23, 55)
        tsbOrange.Text = "Orange"
        ' 
        ' tsbYellow
        ' 
        tsbYellow.BackColor = Color.FromArgb(CByte(255), CByte(153), CByte(51))
        tsbYellow.DisplayStyle = ToolStripItemDisplayStyle.Image
        tsbYellow.ImageTransparentColor = Color.Magenta
        tsbYellow.Name = "tsbYellow"
        tsbYellow.Size = New Size(23, 55)
        tsbYellow.Text = "Yellow"
        ' 
        ' tsbGreen
        ' 
        tsbGreen.BackColor = Color.FromArgb(CByte(16), CByte(150), CByte(24))
        tsbGreen.DisplayStyle = ToolStripItemDisplayStyle.Image
        tsbGreen.ImageTransparentColor = Color.Magenta
        tsbGreen.Name = "tsbGreen"
        tsbGreen.Size = New Size(23, 55)
        tsbGreen.Text = "Green"
        ' 
        ' tsbBlue
        ' 
        tsbBlue.BackColor = Color.FromArgb(CByte(50), CByte(115), CByte(220))
        tsbBlue.DisplayStyle = ToolStripItemDisplayStyle.Image
        tsbBlue.ImageTransparentColor = Color.Magenta
        tsbBlue.Name = "tsbBlue"
        tsbBlue.Size = New Size(23, 55)
        tsbBlue.Text = "Blue"
        ' 
        ' tsbIndigo
        ' 
        tsbIndigo.BackColor = Color.FromArgb(CByte(126), CByte(47), CByte(142))
        tsbIndigo.DisplayStyle = ToolStripItemDisplayStyle.Image
        tsbIndigo.ImageTransparentColor = Color.Magenta
        tsbIndigo.Name = "tsbIndigo"
        tsbIndigo.Size = New Size(23, 55)
        tsbIndigo.Text = "Indigo"
        ' 
        ' tsbViolet
        ' 
        tsbViolet.BackColor = Color.FromArgb(CByte(153), CByte(51), CByte(153))
        tsbViolet.DisplayStyle = ToolStripItemDisplayStyle.Image
        tsbViolet.ImageTransparentColor = Color.Magenta
        tsbViolet.Name = "tsbViolet"
        tsbViolet.Size = New Size(23, 55)
        tsbViolet.Text = "Violet"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(6, 58)
        ' 
        ' tsbAddOne
        ' 
        tsbAddOne.DisplayStyle = ToolStripItemDisplayStyle.Text
        tsbAddOne.ImageTransparentColor = Color.Magenta
        tsbAddOne.Name = "tsbAddOne"
        tsbAddOne.Size = New Size(64, 55)
        tsbAddOne.Text = "Add Table"
        ' 
        ' tsbAddFive
        ' 
        tsbAddFive.DisplayStyle = ToolStripItemDisplayStyle.Text
        tsbAddFive.ImageTransparentColor = Color.Magenta
        tsbAddFive.Name = "tsbAddFive"
        tsbAddFive.Size = New Size(42, 55)
        tsbAddFive.Text = "Add 5"
        ' 
        ' tsbClear
        ' 
        tsbClear.DisplayStyle = ToolStripItemDisplayStyle.Text
        tsbClear.ImageTransparentColor = Color.Magenta
        tsbClear.Name = "tsbClear"
        tsbClear.Size = New Size(38, 55)
        tsbClear.Text = "Clear"
        ' 
        ' Logo_01
        ' 
        Logo_01.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Logo_01.Location = New Point(768, 77)
        Logo_01.Name = "Logo_01"
        Logo_01.Size = New Size(134, 166)
        Logo_01.TabIndex = 1
        Logo_01.TabStop = False
        ' 
        ' ToolStripButton1
        ' 
        ToolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image
        ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), Image)
        ToolStripButton1.ImageTransparentColor = Color.Magenta
        ToolStripButton1.Name = "ToolStripButton1"
        ToolStripButton1.Size = New Size(23, 55)
        ToolStripButton1.Text = "ToolStripButton1"
        ' 
        ' ToolStripSeparator2
        ' 
        ToolStripSeparator2.Name = "ToolStripSeparator2"
        ToolStripSeparator2.Size = New Size(6, 58)
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 3
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 180F))
        TableLayoutPanel1.Location = New Point(92, 424)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Size = New Size(547, 100)
        TableLayoutPanel1.TabIndex = 3
        ' 
        ' Mesas_exemplo
        ' 
        AutoScaleDimensions = New SizeF(8F, 18F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(914, 540)
        Controls.Add(TableLayoutPanel1)
        Controls.Add(Logo_01)
        Controls.Add(tsRainbow)
        Font = New Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        IsMdiContainer = True
        Margin = New Padding(3, 4, 3, 4)
        Name = "Mesas_exemplo"
        Text = "PlayBar"
        tsRainbow.ResumeLayout(False)
        tsRainbow.PerformLayout()
        CType(Logo_01, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
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
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
End Class