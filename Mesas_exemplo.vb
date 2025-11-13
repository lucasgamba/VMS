'Imports System.ComponentModel
'Imports System.Drawing
'Imports System.Drawing.Drawing2D
'Imports System.Windows.Forms
'Imports System.Linq

'Public Class Mesas_exemplo

'    Private ReadOnly tableSize As Size = New Size(80, 80)
'    Private spacingX As Integer = 20
'    Private spacingY As Integer = 20
'    Private startX As Integer = 20
'    Private startY As Integer = 20
'    Private nextTableId As Integer = 1

'    Private Sub Mesas_exemplo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'        ' Set Logo
'        With Me.Logo_01
'            .Image = My.Resources.ResourcesPic.PlayBarLogo
'            .SizeMode = PictureBoxSizeMode.Zoom
'        End With

'        Me.WindowState = FormWindowState.Maximized

'        ' Load statuses from your existing DB helper (Module_db.QueryTable)
'        Try
'            LoadStatusesFromDb()
'        Catch ex As Exception
'            MessageBox.Show("Failed to load table statuses: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'        End Try

'        ' startY based on design-time toolstrip height
'        If Me.Controls.Contains(tsRainbow) Then
'            startY = tsRainbow.Height + 12
'            tsRainbow.BringToFront()
'        End If

'        CreateTables(rows:=5, cols:=5)
'        AddHandler Me.Resize, AddressOf Mesas_exemplo_Resize
'    End Sub

'    ' Load statuses using your existing Module_db.QueryTable helper
'    Private Sub LoadStatusesFromDb()
'        ' adjust SQL to match your table name/columns if needed
'        Dim sql As String = "SELECT Id, TableName, ColorHex FROM resto_Op_Tables ORDER BY Id"

'        Dim dt As DataTable = Module_db.QueryTable(sql)

'        DiningTableControl.StatusColors.Clear()
'        DiningTableControl.StatusIdToName.Clear()

'        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
'            ' fallback defaults
'            DiningTableControl.StatusColors("Available") = Color.LightGreen
'            DiningTableControl.StatusColors("Occupied") = Color.IndianRed
'            DiningTableControl.StatusColors("Reserved") = Color.Gold
'            Return
'        End If

'        For Each row As DataRow In dt.Rows
'            Dim id As Integer = If(row.Item("Id") IsNot DBNull.Value, Convert.ToInt32(row.Item("Id")), 0)
'            Dim name As String = If(row.Item("TableName") IsNot DBNull.Value, Convert.ToString(row.Item("TableName")), String.Empty)
'            Dim colorHex As String = If(row.Item("ColorHex") IsNot DBNull.Value, Convert.ToString(row.Item("ColorHex")), String.Empty)

'            If String.IsNullOrWhiteSpace(name) Then Continue For

'            Dim color As Color = DiningTableControl.DefaultStatusColor
'            If Not String.IsNullOrWhiteSpace(colorHex) Then
'                Try
'                    If Not colorHex.StartsWith("#"c) Then colorHex = "#" & colorHex
'                    color = ColorTranslator.FromHtml(colorHex)
'                Catch
'                    color = DiningTableControl.DefaultStatusColor
'                End Try
'            End If

'            DiningTableControl.StatusColors(name) = color
'            If Not DiningTableControl.StatusIdToName.ContainsKey(id) Then
'                DiningTableControl.StatusIdToName(id) = name
'            End If
'        Next

'        ' ensure sensible defaults if DB missing rows
'        If Not DiningTableControl.StatusColors.ContainsKey("Available") Then DiningTableControl.StatusColors("Available") = Color.LightGreen
'        If Not DiningTableControl.StatusColors.ContainsKey("Occupied") Then DiningTableControl.StatusColors("Occupied") = Color.IndianRed
'        If Not DiningTableControl.StatusColors.ContainsKey("Reserved") Then DiningTableControl.StatusColors("Reserved") = Color.Gold
'    End Sub

'    ' Designer buttons: map to actions (use status names)
'    Private Sub tsbRed_Click(sender As Object, e As EventArgs) Handles tsbRed.Click
'        AddTable(capacity:=2)
'    End Sub

'    Private Sub tsbOrange_Click(sender As Object, e As EventArgs) Handles tsbOrange.Click
'        AddTable(capacity:=4)
'    End Sub

'    Private Sub tsbYellow_Click(sender As Object, e As EventArgs) Handles tsbYellow.Click
'        AddTable(capacity:=6)
'    End Sub

'    Private Sub tsbGreen_Click(sender As Object, e As EventArgs) Handles tsbGreen.Click
'        AddTable(capacity:=8)
'    End Sub

'    Private Sub tsbBlue_Click(sender As Object, e As EventArgs) Handles tsbBlue.Click
'        AddTable(capacity:=4, statusName:="Reserved")
'    End Sub

'    Private Sub tsbIndigo_Click(sender As Object, e As EventArgs) Handles tsbIndigo.Click
'        AddTable(capacity:=4, statusName:="Occupied")
'    End Sub

'    Private Sub tsbViolet_Click(sender As Object, e As EventArgs) Handles tsbViolet.Click
'        AddTable(capacity:=4, shape:=DiningTableControl.TableShape.Rectangle)
'    End Sub

'    Private Sub tsbAddOne_Click(sender As Object, e As EventArgs) Handles tsbAddOne.Click
'        AddTable(capacity:=4)
'    End Sub

'    Private Sub tsbAddFive_Click(sender As Object, e As EventArgs) Handles tsbAddFive.Click
'        For i = 1 To 5
'            AddTable(capacity:=4)
'        Next
'    End Sub

'    Private Sub tsbClear_Click(sender As Object, e As EventArgs) Handles tsbClear.Click
'        ClearTables()
'    End Sub

'    Private Sub CreateTables(rows As Integer, cols As Integer)
'        For Each ctl In Me.Controls.OfType(Of DiningTableControl)().ToArray()
'            Me.Controls.Remove(ctl)
'            ctl.Dispose()
'        Next

'        nextTableId = 1
'        Dim total = rows * cols
'        For i = 1 To total
'            AddTable(capacity:=4, reposition:=False)
'        Next

'        RearrangeTables()
'    End Sub

'    Private Sub AddTable(capacity As Integer, Optional shape As DiningTableControl.TableShape = DiningTableControl.TableShape.Circle, Optional statusName As String = "Available", Optional reposition As Boolean = True)
'        Dim tbl As New DiningTableControl() With {
'            .TableId = nextTableId,
'            .Capacity = capacity,
'            .Shape = shape,
'            .StatusName = statusName,
'            .Size = tableSize
'        }

'        AddHandler tbl.TableClicked, AddressOf Table_Clicked
'        AddHandler tbl.TableDoubleClicked, AddressOf Table_DoubleClicked

'        AddHandler tbl.MouseUp, Sub(s, ev)
'                                    If ev.Button = MouseButtons.Right Then ShowTableMenu(CType(s, DiningTableControl), ev.Location)
'                                End Sub

'        Me.Controls.Add(tbl)
'        If Me.Controls.Contains(tsRainbow) Then tsRainbow.BringToFront()
'        Me.Logo_01.BringToFront()

'        nextTableId += 1
'        If reposition Then RearrangeTables()
'    End Sub

'    Private Sub ClearTables()
'        For Each ctl In Me.Controls.OfType(Of DiningTableControl)().ToArray()
'            Me.Controls.Remove(ctl)
'            ctl.Dispose()
'        Next
'        nextTableId = 1
'    End Sub

'    Private Sub RearrangeTables()
'        Dim tables = Me.Controls.OfType(Of DiningTableControl)().OrderBy(Function(t) t.TableId).ToList()
'        If tables.Count = 0 Then Return

'        Dim availableWidth = Me.ClientSize.Width - (startX * 2)
'        If availableWidth <= tableSize.Width Then availableWidth = tableSize.Width + spacingX

'        Dim columns = Math.Max(1, (availableWidth + spacingX) \ (tableSize.Width + spacingX))
'        Dim baseX As Integer = startX
'        Dim y As Integer = startY
'        Dim col As Integer = 0

'        Dim logoRect As Rectangle = Rectangle.Empty
'        If Me.Controls.ContainsKey("Logo_01") Then
'            logoRect = Me.Logo_01.Bounds
'        End If

'        For Each t In tables
'            Dim attempts As Integer = 0
'            While True
'                Dim proposedX = baseX + col * (tableSize.Width + spacingX)
'                Dim proposedRect = New Rectangle(proposedX, y, tableSize.Width, tableSize.Height)

'                If logoRect = Rectangle.Empty OrElse Not proposedRect.IntersectsWith(logoRect) Then
'                    t.Location = New Point(proposedX, y)
'                    col += 1
'                    If col >= columns Then
'                        col = 0
'                        y += tableSize.Height + spacingY
'                    End If
'                    Exit While
'                End If

'                col += 1
'                If col >= columns Then
'                    col = 0
'                    y += tableSize.Height + spacingY
'                End If

'                attempts += 1
'                If attempts > columns * 100 Then
'                    t.Location = New Point(baseX, y)
'                    col = 1
'                    Exit While
'                End If
'            End While
'        Next
'    End Sub

'    Private Sub Mesas_exemplo_Resize(sender As Object, e As EventArgs)
'        RearrangeTables()
'    End Sub

'    Private Sub Table_Clicked(sender As Object, e As EventArgs)
'        Dim t = CType(sender, DiningTableControl)
'        If String.Equals(t.StatusName, "Available", StringComparison.OrdinalIgnoreCase) Then
'            t.StatusName = "Occupied"
'        ElseIf String.Equals(t.StatusName, "Occupied", StringComparison.OrdinalIgnoreCase) Then
'            t.StatusName = "Available"
'        Else
'            t.StatusName = "Occupied"
'        End If
'    End Sub

'    Private Sub Table_DoubleClicked(sender As Object, e As EventArgs)
'        Dim t = CType(sender, DiningTableControl)
'        MessageBox.Show($"Open table {t.TableId} (capacity {t.Capacity}) - status: {t.StatusName}", "Table")
'    End Sub

'    Private Sub ShowTableMenu(table As DiningTableControl, location As Point)
'        Dim menu As New ContextMenuStrip()
'        Dim statuses = DiningTableControl.StatusColors.Keys.ToList()
'        If statuses.Count = 0 Then
'            statuses = New List(Of String) From {"Available", "Reserved", "Occupied"}
'        End If

'        For Each sName In statuses
'            Dim it = menu.Items.Add(sName)
'            it.Tag = table
'        Next

'        AddHandler menu.ItemClicked, Sub(s, ev)
'                                         Dim item = ev.ClickedItem
'                                         Dim tbl = CType(item.Tag, DiningTableControl)
'                                         tbl.StatusName = item.Text
'                                     End Sub

'        menu.Show(table, location)
'    End Sub

'    Private Sub Mesas_exemplo_Closed(sender As Object, e As EventArgs) Handles Me.Closed
'        Frm_00_01_Landing.Show()
'    End Sub
'End Class