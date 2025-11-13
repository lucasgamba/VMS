Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

<ToolboxItem(True)>
<DefaultEvent("Click")>
Public Class ImageLabelButton
    Inherits UserControl

    Private pb As PictureBox
    Private lbl As Label

    Public Sub New()
        MyBase.New()
        Me.Width = 90
        Me.Height = 90
        Me.Margin = New Padding(2)

        ' Setup PictureBox
        pb = New PictureBox() With {
            .SizeMode = PictureBoxSizeMode.Zoom,
            .Dock = DockStyle.Top,
            .Height = 64,
            .Cursor = Cursors.Hand
        }
        AddHandler pb.Click, AddressOf ChildClicked
        AddHandler pb.MouseEnter, AddressOf ChildMouseEnter
        AddHandler pb.MouseLeave, AddressOf ChildMouseLeave

        ' Setup Label
        lbl = New Label() With {
            .Dock = DockStyle.Fill,
            .TextAlign = ContentAlignment.TopCenter,
            .AutoEllipsis = True,
            .Height = 28
        }
        AddHandler lbl.Click, AddressOf ChildClicked

        ' Add controls (Label below PictureBox)
        Me.Controls.Add(lbl)
        Me.Controls.Add(pb)

        ' Make the whole control clickable and show hand cursor
        Me.Cursor = Cursors.Hand
        Me.BackColor = Color.Transparent
    End Sub

    ' Forward child click to control click
    Private Sub ChildClicked(sender As Object, e As EventArgs)
        Me.OnClick(e)
    End Sub

    Private Sub ChildMouseEnter(sender As Object, e As EventArgs)
        Me.BackColor = Color.FromArgb(240, 240, 240)
    End Sub

    Private Sub ChildMouseLeave(sender As Object, e As EventArgs)
        Me.BackColor = Color.Transparent
    End Sub

    Private Sub InitializeComponent()

    End Sub

    <Browsable(True)>
    <Category("Appearance")>
    <Description("Image displayed above the text")>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property Image As Image
        Get
            Return pb.Image
        End Get
        Set(value As Image)
            pb.Image = value
        End Set
    End Property

    <Browsable(True)>
    <Category("Appearance")>
    <Description("Text displayed below the image")>
    <Localizable(True)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Overrides Property Text As String
        Get
            Return lbl.Text
        End Get
        Set(value As String)
            lbl.Text = value
        End Set
    End Property

    Protected Overrides Sub OnClick(e As EventArgs)
        MyBase.OnClick(e)
        ' Click event will be raised normally
    End Sub

    ' Expose inner controls if needed for customization
    <Browsable(False)>
    Public ReadOnly Property PictureBoxControl As PictureBox
        Get
            Return pb
        End Get
    End Property

    <Browsable(False)>
    Public ReadOnly Property LabelControl As Label
        Get
            Return lbl
        End Get
    End Property

End Class
