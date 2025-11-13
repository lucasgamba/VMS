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
        LstVw_01_Forms = New ListView()
        LstVw_02_Objects = New ListView()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Txt_01_CurrentValue = New TextBox()
        Label4 = New Label()
        Txt_02_CurrentTranslation = New TextBox()
        Label5 = New Label()
        Label6 = New Label()
        Txt_03_NewValue = New TextBox()
        LstVw_03_Languages = New ListView()
        Btn_01_Save = New Button()
        Btn_02_Exit = New Button()
        Btn_03_NewMsgBox = New Button()
        CType(Logo_01, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Logo_01
        ' 
        Logo_01.Anchor = AnchorStyles.Top Or AnchorStyles.Right
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
        ' LstVw_01_Forms
        ' 
        LstVw_01_Forms.Location = New Point(10, 118)
        LstVw_01_Forms.MultiSelect = False
        LstVw_01_Forms.Name = "LstVw_01_Forms"
        LstVw_01_Forms.Size = New Size(305, 300)
        LstVw_01_Forms.TabIndex = 3
        LstVw_01_Forms.UseCompatibleStateImageBehavior = False
        ' 
        ' LstVw_02_Objects
        ' 
        LstVw_02_Objects.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LstVw_02_Objects.Location = New Point(321, 118)
        LstVw_02_Objects.MultiSelect = False
        LstVw_02_Objects.Name = "LstVw_02_Objects"
        LstVw_02_Objects.Size = New Size(413, 300)
        LstVw_02_Objects.Sorting = SortOrder.Ascending
        LstVw_02_Objects.TabIndex = 4
        LstVw_02_Objects.UseCompatibleStateImageBehavior = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(10, 99)
        Label1.Name = "Label1"
        Label1.Size = New Size(46, 18)
        Label1.TabIndex = 3
        Label1.Text = "Forms"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(321, 97)
        Label2.Name = "Label2"
        Label2.Size = New Size(55, 18)
        Label2.TabIndex = 3
        Label2.Text = "Objects"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(10, 432)
        Label3.Name = "Label3"
        Label3.Size = New Size(120, 18)
        Label3.TabIndex = 3
        Label3.Text = "Object Text Value:"
        ' 
        ' Txt_01_CurrentValue
        ' 
        Txt_01_CurrentValue.BackColor = Color.LightGray
        Txt_01_CurrentValue.BorderStyle = BorderStyle.FixedSingle
        Txt_01_CurrentValue.Location = New Point(10, 453)
        Txt_01_CurrentValue.Name = "Txt_01_CurrentValue"
        Txt_01_CurrentValue.Size = New Size(305, 26)
        Txt_01_CurrentValue.TabIndex = 6
        Txt_01_CurrentValue.TabStop = False
        Txt_01_CurrentValue.WordWrap = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(10, 482)
        Label4.Name = "Label4"
        Label4.Size = New Size(129, 18)
        Label4.TabIndex = 3
        Label4.Text = "Current Translation:"
        ' 
        ' Txt_02_CurrentTranslation
        ' 
        Txt_02_CurrentTranslation.BackColor = Color.LightGray
        Txt_02_CurrentTranslation.BorderStyle = BorderStyle.FixedSingle
        Txt_02_CurrentTranslation.Location = New Point(10, 503)
        Txt_02_CurrentTranslation.Name = "Txt_02_CurrentTranslation"
        Txt_02_CurrentTranslation.Size = New Size(305, 26)
        Txt_02_CurrentTranslation.TabIndex = 7
        Txt_02_CurrentTranslation.TabStop = False
        Txt_02_CurrentTranslation.WordWrap = False
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(321, 432)
        Label5.Name = "Label5"
        Label5.Size = New Size(70, 18)
        Label5.TabIndex = 3
        Label5.Text = "Language:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(10, 532)
        Label6.Name = "Label6"
        Label6.Size = New Size(79, 18)
        Label6.TabIndex = 3
        Label6.Text = "New Value:"
        ' 
        ' Txt_03_NewValue
        ' 
        Txt_03_NewValue.BorderStyle = BorderStyle.FixedSingle
        Txt_03_NewValue.Location = New Point(10, 553)
        Txt_03_NewValue.Name = "Txt_03_NewValue"
        Txt_03_NewValue.Size = New Size(305, 26)
        Txt_03_NewValue.TabIndex = 8
        Txt_03_NewValue.WordWrap = False
        ' 
        ' LstVw_03_Languages
        ' 
        LstVw_03_Languages.Location = New Point(321, 453)
        LstVw_03_Languages.MultiSelect = False
        LstVw_03_Languages.Name = "LstVw_03_Languages"
        LstVw_03_Languages.Size = New Size(305, 126)
        LstVw_03_Languages.TabIndex = 5
        LstVw_03_Languages.UseCompatibleStateImageBehavior = False
        LstVw_03_Languages.View = View.List
        ' 
        ' Btn_01_Save
        ' 
        Btn_01_Save.Location = New Point(632, 501)
        Btn_01_Save.Name = "Btn_01_Save"
        Btn_01_Save.Size = New Size(100, 36)
        Btn_01_Save.TabIndex = 9
        Btn_01_Save.Text = "Save"
        Btn_01_Save.UseVisualStyleBackColor = True
        ' 
        ' Btn_02_Exit
        ' 
        Btn_02_Exit.Location = New Point(632, 543)
        Btn_02_Exit.Name = "Btn_02_Exit"
        Btn_02_Exit.Size = New Size(100, 36)
        Btn_02_Exit.TabIndex = 10
        Btn_02_Exit.Text = "Exit"
        Btn_02_Exit.UseVisualStyleBackColor = True
        ' 
        ' Btn_03_NewMsgBox
        ' 
        Btn_03_NewMsgBox.Location = New Point(92, 37)
        Btn_03_NewMsgBox.Name = "Btn_03_NewMsgBox"
        Btn_03_NewMsgBox.Size = New Size(100, 29)
        Btn_03_NewMsgBox.TabIndex = 2
        Btn_03_NewMsgBox.Text = "New MsgBox"
        Btn_03_NewMsgBox.UseVisualStyleBackColor = True
        ' 
        ' Frm_00_02_Translations
        ' 
        AutoScaleDimensions = New SizeF(8F, 18F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(742, 585)
        Controls.Add(Btn_02_Exit)
        Controls.Add(Btn_03_NewMsgBox)
        Controls.Add(Btn_01_Save)
        Controls.Add(Txt_03_NewValue)
        Controls.Add(Txt_02_CurrentTranslation)
        Controls.Add(Txt_01_CurrentValue)
        Controls.Add(Label6)
        Controls.Add(Label4)
        Controls.Add(Label2)
        Controls.Add(Label5)
        Controls.Add(Label3)
        Controls.Add(Label1)
        Controls.Add(LstVw_03_Languages)
        Controls.Add(LstVw_02_Objects)
        Controls.Add(LstVw_01_Forms)
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
    Friend WithEvents LstVw_01_Forms As ListView
    Friend WithEvents LstVw_02_Objects As ListView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Txt_01_CurrentValue As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Txt_02_CurrentTranslation As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Txt_03_NewValue As TextBox
    Friend WithEvents LstVw_03_Languages As ListView
    Friend WithEvents Btn_01_Save As Button
    Friend WithEvents Btn_02_Exit As Button
    Friend WithEvents Btn_03_NewMsgBox As Button
End Class
