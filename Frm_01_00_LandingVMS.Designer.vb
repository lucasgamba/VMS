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
        RibbonControlAdv1 = New Syncfusion.Windows.Forms.Tools.RibbonControlAdv()
        ToolStripTabItem1 = New Syncfusion.Windows.Forms.Tools.ToolStripTabItem()
        CType(Logo_01, ComponentModel.ISupportInitialize).BeginInit()
        CType(RibbonControlAdv1, ComponentModel.ISupportInitialize).BeginInit()
        RibbonControlAdv1.SuspendLayout()
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
        ' RibbonControlAdv1
        ' 
        RibbonControlAdv1.Dock = Syncfusion.Windows.Forms.Tools.DockStyleEx.Top
        RibbonControlAdv1.Font = New Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RibbonControlAdv1.Header.AddMainItem(ToolStripTabItem1)
        RibbonControlAdv1.Location = New Point(0, 0)
        RibbonControlAdv1.MenuButtonFont = New Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RibbonControlAdv1.MenuButtonText = ""
        RibbonControlAdv1.MenuColor = Color.FromArgb(CByte(0), CByte(114), CByte(198))
        RibbonControlAdv1.Name = "RibbonControlAdv1"
        RibbonControlAdv1.OfficeColorScheme = Syncfusion.Windows.Forms.Tools.ToolStripEx.ColorScheme.Managed
        ' 
        ' RibbonControlAdv1.OfficeMenu
        ' 
        RibbonControlAdv1.OfficeMenu.Name = "OfficeMenu"
        RibbonControlAdv1.OfficeMenu.ShowItemToolTips = True
        RibbonControlAdv1.OfficeMenu.Size = New Size(12, 65)
        RibbonControlAdv1.QuickPanelImageLayout = PictureBoxSizeMode.StretchImage
        RibbonControlAdv1.RibbonHeaderImage = Syncfusion.Windows.Forms.Tools.RibbonHeaderImage.None
        RibbonControlAdv1.SelectedTab = ToolStripTabItem1
        RibbonControlAdv1.ShowRibbonDisplayOptionButton = True
        RibbonControlAdv1.Size = New Size(1390, 180)
        RibbonControlAdv1.SystemText.QuickAccessDialogDropDownName = "Start menu"
        RibbonControlAdv1.SystemText.RenameDisplayLabelText = "&Display Name:"
        RibbonControlAdv1.TabIndex = 4
        RibbonControlAdv1.Text = "RibbonControlAdv1"
        ' 
        ' ToolStripTabItem1
        ' 
        ToolStripTabItem1.Name = "ToolStripTabItem1"
        ' 
        ' RibbonControlAdv1.RibbonPanel1
        ' 
        ToolStripTabItem1.Panel.Name = "RibbonPanel1"
        ToolStripTabItem1.Panel.ScrollPosition = 0
        ToolStripTabItem1.Panel.TabIndex = 2
        ToolStripTabItem1.Panel.Text = "ToolStripTabItem1"
        ToolStripTabItem1.Position = 0
        ToolStripTabItem1.Size = New Size(126, 24)
        RibbonControlAdv1.TabGroups.SetTabGroup(ToolStripTabItem1, Nothing)
        ToolStripTabItem1.Tag = "1"
        ToolStripTabItem1.Text = "ToolStripTabItem1"
        ' 
        ' Frm_01_00_LandingVMS
        ' 
        AutoScaleDimensions = New SizeF(8F, 18F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1390, 540)
        Controls.Add(RibbonControlAdv1)
        Controls.Add(Logo_01)
        Font = New Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        IsMdiContainer = True
        Margin = New Padding(3, 4, 3, 4)
        Name = "Frm_01_00_LandingVMS"
        Text = "VMS"
        CType(Logo_01, ComponentModel.ISupportInitialize).EndInit()
        CType(RibbonControlAdv1, ComponentModel.ISupportInitialize).EndInit()
        RibbonControlAdv1.ResumeLayout(False)
        RibbonControlAdv1.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents Logo_01 As PictureBox
    Friend WithEvents RibbonControlAdv1 As Syncfusion.Windows.Forms.Tools.RibbonControlAdv
    Friend WithEvents ToolStripTabItem1 As Syncfusion.Windows.Forms.Tools.ToolStripTabItem
End Class
