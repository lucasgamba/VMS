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
        TabControl1 = New TabControl()
        TabPage1 = New TabPage()
        CheckBox1 = New CheckBox()
        Button4 = New Button()
        TabPage2 = New TabPage()
        Button3 = New Button()
        Button2 = New Button()
        Button1 = New Button()
        TabPage3 = New TabPage()
        TableLayoutPanel1 = New TableLayoutPanel()
        ToolStrip1 = New ToolStrip()
        ToolStripButton1 = New ToolStripButton()
        Label1 = New Label()
        ToolStripButton2 = New ToolStripButton()
        ToolStripButton3 = New ToolStripButton()
        CType(Logo_01, ComponentModel.ISupportInitialize).BeginInit()
        TabControl1.SuspendLayout()
        TabPage1.SuspendLayout()
        TabPage2.SuspendLayout()
        TabPage3.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        ToolStrip1.SuspendLayout()
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
        ' TabControl1
        ' 
        TabControl1.AllowDrop = True
        TabControl1.Appearance = TabAppearance.Buttons
        TabControl1.Controls.Add(TabPage1)
        TabControl1.Controls.Add(TabPage2)
        TabControl1.Controls.Add(TabPage3)
        TabControl1.Dock = DockStyle.Top
        TabControl1.HotTrack = True
        TabControl1.ImeMode = ImeMode.NoControl
        TabControl1.Location = New Point(0, 0)
        TabControl1.Name = "TabControl1"
        TabControl1.Padding = New Point(6, 15)
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(1390, 160)
        TabControl1.SizeMode = TabSizeMode.Fixed
        TabControl1.TabIndex = 5
        ' 
        ' TabPage1
        ' 
        TabPage1.Controls.Add(CheckBox1)
        TabPage1.Controls.Add(Button4)
        TabPage1.Location = New Point(4, 54)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(1382, 102)
        TabPage1.TabIndex = 0
        TabPage1.Text = "TabPage1"
        TabPage1.UseVisualStyleBackColor = True
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AutoSize = True
        CheckBox1.Location = New Point(104, 36)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(94, 22)
        CheckBox1.TabIndex = 1
        CheckBox1.Text = "CheckBox1"
        CheckBox1.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Location = New Point(6, 15)
        Button4.Name = "Button4"
        Button4.Size = New Size(75, 63)
        Button4.TabIndex = 0
        Button4.Text = "Button4"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' TabPage2
        ' 
        TabPage2.Controls.Add(Button3)
        TabPage2.Controls.Add(Button2)
        TabPage2.Controls.Add(Button1)
        TabPage2.Location = New Point(4, 54)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(1382, 102)
        TabPage2.TabIndex = 1
        TabPage2.Text = "TabPage2"
        TabPage2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(168, 6)
        Button3.Name = "Button3"
        Button3.Size = New Size(75, 80)
        Button3.TabIndex = 0
        Button3.Text = "Button1"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(87, 6)
        Button2.Name = "Button2"
        Button2.Size = New Size(75, 80)
        Button2.TabIndex = 0
        Button2.Text = "Button1"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(6, 6)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 80)
        Button1.TabIndex = 0
        Button1.Text = "Button1"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' TabPage3
        ' 
        TabPage3.Controls.Add(TableLayoutPanel1)
        TabPage3.Location = New Point(4, 54)
        TabPage3.Name = "TabPage3"
        TabPage3.Padding = New Padding(3)
        TabPage3.Size = New Size(1382, 102)
        TabPage3.TabIndex = 2
        TabPage3.Text = "TabPage3"
        TabPage3.UseVisualStyleBackColor = True
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 4
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel1.Controls.Add(ToolStrip1, 0, 0)
        TableLayoutPanel1.Controls.Add(Label1, 0, 1)
        TableLayoutPanel1.Dock = DockStyle.Top
        TableLayoutPanel1.Location = New Point(3, 3)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 81F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 19F))
        TableLayoutPanel1.Size = New Size(1376, 100)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' ToolStrip1
        ' 
        ToolStrip1.BackColor = SystemColors.Control
        ToolStrip1.Items.AddRange(New ToolStripItem() {ToolStripButton1, ToolStripButton3, ToolStripButton2})
        ToolStrip1.Location = New Point(0, 0)
        ToolStrip1.Name = "ToolStrip1"
        ToolStrip1.Size = New Size(306, 81)
        ToolStrip1.TabIndex = 0
        ToolStrip1.Text = "ToolStrip1"
        ' 
        ' ToolStripButton1
        ' 
        ToolStripButton1.Font = New Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), Image)
        ToolStripButton1.ImageScaling = ToolStripItemImageScaling.None
        ToolStripButton1.ImageTransparentColor = Color.Magenta
        ToolStripButton1.Name = "ToolStripButton1"
        ToolStripButton1.Padding = New Padding(15, 0, 15, 0)
        ToolStripButton1.Size = New Size(98, 78)
        ToolStripButton1.Text = "Conifg"
        ToolStripButton1.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Dock = DockStyle.Bottom
        Label1.Font = New Font("Calibri", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(3, 86)
        Label1.Name = "Label1"
        Label1.Size = New Size(300, 14)
        Label1.TabIndex = 1
        Label1.Text = "Label1"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' ToolStripButton2
        ' 
        ToolStripButton2.Font = New Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), Image)
        ToolStripButton2.ImageScaling = ToolStripItemImageScaling.None
        ToolStripButton2.ImageTransparentColor = Color.Magenta
        ToolStripButton2.Name = "ToolStripButton2"
        ToolStripButton2.Padding = New Padding(15, 0, 15, 0)
        ToolStripButton2.Size = New Size(98, 78)
        ToolStripButton2.Text = "Conifg"
        ToolStripButton2.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' ToolStripButton3
        ' 
        ToolStripButton3.Font = New Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), Image)
        ToolStripButton3.ImageScaling = ToolStripItemImageScaling.None
        ToolStripButton3.ImageTransparentColor = Color.Magenta
        ToolStripButton3.Name = "ToolStripButton3"
        ToolStripButton3.Padding = New Padding(15, 0, 15, 0)
        ToolStripButton3.Size = New Size(98, 78)
        ToolStripButton3.Text = "Conifg"
        ToolStripButton3.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' Frm_01_00_LandingVMS
        ' 
        AutoScaleDimensions = New SizeF(8F, 18F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1390, 540)
        Controls.Add(TabControl1)
        Controls.Add(Logo_01)
        Font = New Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        IsMdiContainer = True
        Margin = New Padding(3, 4, 3, 4)
        Name = "Frm_01_00_LandingVMS"
        Text = "VMS"
        CType(Logo_01, ComponentModel.ISupportInitialize).EndInit()
        TabControl1.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        TabPage1.PerformLayout()
        TabPage2.ResumeLayout(False)
        TabPage3.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        ToolStrip1.ResumeLayout(False)
        ToolStrip1.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents Logo_01 As PictureBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Button4 As Button
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents Label1 As Label
End Class
