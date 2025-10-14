Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Public Class DiningTableControl
    Inherits UserControl

    ' Dynamic status (loaded from DB)
    Private _tableId As Integer
    Private _capacity As Integer = 4
    Private _statusId As Integer
    Private _statusName As String = "Available"
    Private _shape As TableShape = TableShape.Circle

    Public Enum TableShape
        Circle
        Rectangle
    End Enum

    ' Shared dictionaries populated at startup from DB
    Public Shared StatusColors As New Dictionary(Of String, Color)(StringComparer.OrdinalIgnoreCase)
    Public Shared StatusIdToName As New Dictionary(Of Integer, String)
    Public Shared DefaultStatusColor As Color = Color.LightGreen

    <Category("Data")>
    Public Property TableId As Integer
        Get
            Return _tableId
        End Get
        Set(value As Integer)
            _tableId = value
            Invalidate()
        End Set
    End Property

    <Category("Data")>
    Public Property Capacity As Integer
        Get
            Return _capacity
        End Get
        Set(value As Integer)
            _capacity = value
            Invalidate()
        End Set
    End Property

    <Category("Appearance")>
    Public Property Shape As TableShape
        Get
            Return _shape
        End Get
        Set(value As TableShape)
            _shape = value
            Invalidate()
        End Set
    End Property

    <Category("Data")>
    Public Property StatusId As Integer
        Get
            Return _statusId
        End Get
        Set(value As Integer)
            _statusId = value
            ' attempt to resolve name from id
            If StatusIdToName.ContainsKey(value) Then
                _statusName = StatusIdToName(value)
            End If
            Invalidate()
        End Set
    End Property

    <Category("Data")>
    Public Property StatusName As String
        Get
            Return _statusName
        End Get
        Set(value As String)
            _statusName = If(value, String.Empty)
            Invalidate()
        End Set
    End Property

    Public Event TableClicked As EventHandler
    Public Event TableDoubleClicked As EventHandler

    Public Sub New()
        Me.DoubleBuffered = True
        Me.Size = New Size(80, 80)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim rect = New Rectangle(2, 2, Me.Width - 4, Me.Height - 4)

        Dim fillColor As Color = DefaultStatusColor
        If Not String.IsNullOrEmpty(_statusName) AndAlso StatusColors.ContainsKey(_statusName) Then
            fillColor = StatusColors(_statusName)
        End If

        Using fill As New SolidBrush(fillColor)
            If _shape = TableShape.Circle Then
                g.FillEllipse(fill, rect)
                g.DrawEllipse(Pens.Black, rect)
            Else
                g.FillRectangle(fill, rect)
                g.DrawRectangle(Pens.Black, rect)
            End If
        End Using

        Dim sf As New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
        Dim text = $"T{_tableId}" & vbCrLf & $"{_capacity}" & If(String.IsNullOrEmpty(_statusName), "", vbCrLf & _statusName)
        g.DrawString(text, Me.Font, Brushes.Black, rect, sf)
    End Sub

    Protected Overrides Sub OnClick(e As EventArgs)
        MyBase.OnClick(e)
        RaiseEvent TableClicked(Me, EventArgs.Empty)
    End Sub

    Protected Overrides Sub OnDoubleClick(e As EventArgs)
        MyBase.OnDoubleClick(e)
        RaiseEvent TableDoubleClicked(Me, EventArgs.Empty)
    End Sub
End Class