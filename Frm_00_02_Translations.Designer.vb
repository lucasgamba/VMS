<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_00_02_Translations
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
        Logo_01 = New PictureBox()
        RadioButton1 = New RadioButton()
        RadioButton2 = New RadioButton()
        ListView1 = New ListView()
        ListView2 = New ListView()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        TextBox1 = New TextBox()
        Label4 = New Label()
        TextBox2 = New TextBox()
        Label5 = New Label()
        Label6 = New Label()
        TextBox3 = New TextBox()
        ListView3 = New ListView()
        Button1 = New Button()
        Button2 = New Button()
        Button3 = New Button()
        CType(Logo_01, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Logo_01
        ' 
        Logo_01.Location = New Point(634, 12)
        Logo_01.Name = "Logo_01"
        Logo_01.Size = New Size(100, 100)
        Logo_01.TabIndex = 0
        Logo_01.TabStop = False
        ' 
        ' RadioButton1
        ' 
        RadioButton1.AutoSize = True
        RadioButton1.Checked = True
        RadioButton1.Location = New Point(12, 12)
        RadioButton1.Name = "RadioButton1"
        RadioButton1.Size = New Size(64, 22)
        RadioButton1.TabIndex = 0
        RadioButton1.TabStop = True
        RadioButton1.Text = "Forms"
        RadioButton1.UseVisualStyleBackColor = True
        ' 
        ' RadioButton2
        ' 
        RadioButton2.AutoSize = True
        RadioButton2.Location = New Point(12, 40)
        RadioButton2.Name = "RadioButton2"
        RadioButton2.Size = New Size(74, 22)
        RadioButton2.TabIndex = 1
        RadioButton2.Text = "MsgBox"
        RadioButton2.UseVisualStyleBackColor = True
        ' 
        ' ListView1
        ' 
        ListView1.CheckBoxes = True
        ListView1.Location = New Point(12, 84)
        ListView1.MultiSelect = False
        ListView1.Name = "ListView1"
        ListView1.Size = New Size(305, 300)
        ListView1.TabIndex = 3
        ListView1.UseCompatibleStateImageBehavior = False
        ' 
        ' ListView2
        ' 
        ListView2.CheckBoxes = True
        ListView2.Location = New Point(323, 84)
        ListView2.MultiSelect = False
        ListView2.Name = "ListView2"
        ListView2.Size = New Size(305, 300)
        ListView2.TabIndex = 4
        ListView2.UseCompatibleStateImageBehavior = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 65)
        Label1.Name = "Label1"
        Label1.Size = New Size(46, 18)
        Label1.TabIndex = 3
        Label1.Text = "Forms"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(323, 63)
        Label2.Name = "Label2"
        Label2.Size = New Size(55, 18)
        Label2.TabIndex = 3
        Label2.Text = "Objects"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(12, 398)
        Label3.Name = "Label3"
        Label3.Size = New Size(97, 18)
        Label3.TabIndex = 3
        Label3.Text = "Current Value:"
        ' 
        ' TextBox1
        ' 
        TextBox1.BorderStyle = BorderStyle.FixedSingle
        TextBox1.Location = New Point(12, 419)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(305, 26)
        TextBox1.TabIndex = 6
        TextBox1.TabStop = False
        TextBox1.WordWrap = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(12, 448)
        Label4.Name = "Label4"
        Label4.Size = New Size(129, 18)
        Label4.TabIndex = 3
        Label4.Text = "Current Translation:"
        ' 
        ' TextBox2
        ' 
        TextBox2.BorderStyle = BorderStyle.FixedSingle
        TextBox2.Location = New Point(12, 469)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(305, 26)
        TextBox2.TabIndex = 7
        TextBox2.TabStop = False
        TextBox2.WordWrap = False
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(323, 398)
        Label5.Name = "Label5"
        Label5.Size = New Size(70, 18)
        Label5.TabIndex = 3
        Label5.Text = "Language:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(12, 498)
        Label6.Name = "Label6"
        Label6.Size = New Size(79, 18)
        Label6.TabIndex = 3
        Label6.Text = "New Value:"
        ' 
        ' TextBox3
        ' 
        TextBox3.BorderStyle = BorderStyle.FixedSingle
        TextBox3.Location = New Point(12, 519)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(305, 26)
        TextBox3.TabIndex = 8
        TextBox3.WordWrap = False
        ' 
        ' ListView3
        ' 
        ListView3.CheckBoxes = True
        ListView3.Location = New Point(323, 419)
        ListView3.MultiSelect = False
        ListView3.Name = "ListView3"
        ListView3.Size = New Size(305, 126)
        ListView3.TabIndex = 5
        ListView3.UseCompatibleStateImageBehavior = False
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(634, 467)
        Button1.Name = "Button1"
        Button1.Size = New Size(100, 36)
        Button1.TabIndex = 9
        Button1.Text = "Save"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(634, 509)
        Button2.Name = "Button2"
        Button2.Size = New Size(100, 36)
        Button2.TabIndex = 10
        Button2.Text = "Exit"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(92, 37)
        Button3.Name = "Button3"
        Button3.Size = New Size(100, 29)
        Button3.TabIndex = 2
        Button3.Text = "New MsgBox"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Frm_00_02_Translations
        ' 
        AutoScaleDimensions = New SizeF(8F, 18F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(742, 551)
        Controls.Add(Button2)
        Controls.Add(Button3)
        Controls.Add(Button1)
        Controls.Add(TextBox3)
        Controls.Add(TextBox2)
        Controls.Add(TextBox1)
        Controls.Add(Label6)
        Controls.Add(Label4)
        Controls.Add(Label2)
        Controls.Add(Label5)
        Controls.Add(Label3)
        Controls.Add(Label1)
        Controls.Add(ListView3)
        Controls.Add(ListView2)
        Controls.Add(ListView1)
        Controls.Add(RadioButton2)
        Controls.Add(RadioButton1)
        Controls.Add(Logo_01)
        Font = New Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Margin = New Padding(3, 4, 3, 4)
        Name = "Frm_00_02_Translations"
        Text = "Translations"
        CType(Logo_01, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Logo_01 As PictureBox
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ListView2 As ListView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents ListView3 As ListView
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
End Class
