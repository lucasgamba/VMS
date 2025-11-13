Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

<System.ComponentModel.ToolboxItem(True)>
Public Class RibbonLikeControl
    Inherits UserControl

    Private _ts As ToolStrip

    Public Sub New()
        MyBase.New()
        Me.Height = 88
        Me.Dock = DockStyle.Top
        InitializeToolStrip()
    End Sub

    Private Sub InitializeToolStrip()
        _ts = New ToolStrip() With {
            .Name = "tsRibbon",
            .Dock = DockStyle.Fill,
            .GripStyle = ToolStripGripStyle.Hidden,
            .LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow,
            .BackColor = Color.WhiteSmoke
        }
        Me.Controls.Clear()
        Me.Controls.Add(_ts)
    End Sub

    ' Adds a simple button to the ribbon. Can be called from code after placing the control on a form.
    Public Function AddButton(text As String, Optional image As Image = Nothing, Optional clickHandler As EventHandler = Nothing) As ToolStripButton
        Dim btn As New ToolStripButton(text) With {
            .AutoSize = False,
            .Width = 100,
            .Image = image,
            .ImageScaling = ToolStripItemImageScaling.SizeToFit,
            .TextImageRelation = TextImageRelation.ImageAboveText
        }
        If clickHandler IsNot Nothing Then
            AddHandler btn.Click, clickHandler
        End If
        _ts.Items.Add(btn)
        Return btn
    End Function

    ' Clears all items
    Public Sub ClearItems()
        _ts.Items.Clear()
    End Sub

    ' Expose the underlying ToolStrip for advanced customization
    <Browsable(False)>
    Public ReadOnly Property ToolStrip As ToolStrip
        Get
            Return _ts
        End Get
    End Property

End Class
