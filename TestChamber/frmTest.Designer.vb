<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTest
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
        Me.txtFile = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.chkSplitNewLine = New System.Windows.Forms.CheckBox()
        Me.chkSplitTabs = New System.Windows.Forms.CheckBox()
        Me.txtError = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lstProperties = New System.Windows.Forms.ListBox()
        Me.lstGroups = New System.Windows.Forms.ListBox()
        Me.chkAutoOpen = New System.Windows.Forms.CheckBox()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.btnTimeTest = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtFile
        '
        Me.txtFile.Location = New System.Drawing.Point(264, 0)
        Me.txtFile.Multiline = True
        Me.txtFile.Name = "txtFile"
        Me.txtFile.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtFile.Size = New System.Drawing.Size(432, 384)
        Me.txtFile.TabIndex = 0
        Me.txtFile.WordWrap = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.NumericUpDown1)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(224, 106)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Stuff..."
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(8, 48)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {10000, 0, 0, -2147483648})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(120, 20)
        Me.NumericUpDown1.TabIndex = 2
        Me.NumericUpDown1.Value = New Decimal(New Integer() {57, 0, 0, 0})
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(8, 72)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(120, 20)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "Some text"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(8, 24)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "CheckBox1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(184, 360)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(184, 336)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(75, 23)
        Me.btnOpen.TabIndex = 2
        Me.btnOpen.Text = "Open"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RadioButton3)
        Me.GroupBox2.Controls.Add(Me.RadioButton4)
        Me.GroupBox2.Controls.Add(Me.NumericUpDown2)
        Me.GroupBox2.Controls.Add(Me.CheckBox2)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 112)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(224, 124)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Stuff..."
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(8, 97)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(90, 17)
        Me.RadioButton3.TabIndex = 4
        Me.RadioButton3.Text = "RadioButton3"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Checked = True
        Me.RadioButton4.Location = New System.Drawing.Point(8, 74)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(90, 17)
        Me.RadioButton4.TabIndex = 3
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "RadioButton4"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Location = New System.Drawing.Point(8, 48)
        Me.NumericUpDown2.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NumericUpDown2.Minimum = New Decimal(New Integer() {10000, 0, 0, -2147483648})
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(120, 20)
        Me.NumericUpDown2.TabIndex = 2
        Me.NumericUpDown2.Value = New Decimal(New Integer() {57, 0, 0, 0})
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(8, 24)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox2.TabIndex = 0
        Me.CheckBox2.Text = "CheckBox2"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'chkSplitNewLine
        '
        Me.chkSplitNewLine.AutoSize = True
        Me.chkSplitNewLine.Checked = True
        Me.chkSplitNewLine.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSplitNewLine.Location = New System.Drawing.Point(8, 336)
        Me.chkSplitNewLine.Name = "chkSplitNewLine"
        Me.chkSplitNewLine.Size = New System.Drawing.Size(121, 17)
        Me.chkSplitNewLine.TabIndex = 5
        Me.chkSplitNewLine.Text = "Split using new lines"
        Me.chkSplitNewLine.UseVisualStyleBackColor = True
        '
        'chkSplitTabs
        '
        Me.chkSplitTabs.AutoSize = True
        Me.chkSplitTabs.Checked = True
        Me.chkSplitTabs.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSplitTabs.Location = New System.Drawing.Point(8, 358)
        Me.chkSplitTabs.Name = "chkSplitTabs"
        Me.chkSplitTabs.Size = New System.Drawing.Size(97, 17)
        Me.chkSplitTabs.TabIndex = 5
        Me.chkSplitTabs.Text = "Split using tabs"
        Me.chkSplitTabs.UseVisualStyleBackColor = True
        '
        'txtError
        '
        Me.txtError.Location = New System.Drawing.Point(8, 263)
        Me.txtError.Name = "txtError"
        Me.txtError.Size = New System.Drawing.Size(224, 20)
        Me.txtError.TabIndex = 1
        Me.txtError.Text = "Error:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(703, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Groups:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(883, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Properties=Value:"
        '
        'lstProperties
        '
        Me.lstProperties.FormattingEnabled = True
        Me.lstProperties.HorizontalScrollbar = True
        Me.lstProperties.Location = New System.Drawing.Point(829, 16)
        Me.lstProperties.Name = "lstProperties"
        Me.lstProperties.Size = New System.Drawing.Size(205, 368)
        Me.lstProperties.TabIndex = 7
        '
        'lstGroups
        '
        Me.lstGroups.FormattingEnabled = True
        Me.lstGroups.HorizontalScrollbar = True
        Me.lstGroups.Location = New System.Drawing.Point(703, 17)
        Me.lstGroups.Name = "lstGroups"
        Me.lstGroups.Size = New System.Drawing.Size(120, 368)
        Me.lstGroups.TabIndex = 7
        '
        'chkAutoOpen
        '
        Me.chkAutoOpen.AutoSize = True
        Me.chkAutoOpen.Checked = True
        Me.chkAutoOpen.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAutoOpen.Location = New System.Drawing.Point(8, 313)
        Me.chkAutoOpen.Name = "chkAutoOpen"
        Me.chkAutoOpen.Size = New System.Drawing.Size(74, 17)
        Me.chkAutoOpen.TabIndex = 8
        Me.chkAutoOpen.Text = "AutoOpen"
        Me.chkAutoOpen.UseVisualStyleBackColor = True
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Location = New System.Drawing.Point(8, 290)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(33, 13)
        Me.lblTime.TabIndex = 9
        Me.lblTime.Text = "Time:"
        '
        'btnTimeTest
        '
        Me.btnTimeTest.Location = New System.Drawing.Point(184, 301)
        Me.btnTimeTest.Name = "btnTimeTest"
        Me.btnTimeTest.Size = New System.Drawing.Size(75, 23)
        Me.btnTimeTest.TabIndex = 10
        Me.btnTimeTest.Text = "Time Test"
        Me.btnTimeTest.UseVisualStyleBackColor = True
        '
        'frmTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1040, 387)
        Me.Controls.Add(Me.btnTimeTest)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.chkAutoOpen)
        Me.Controls.Add(Me.lstGroups)
        Me.Controls.Add(Me.lstProperties)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkSplitTabs)
        Me.Controls.Add(Me.txtError)
        Me.Controls.Add(Me.chkSplitNewLine)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnOpen)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtFile)
        Me.Name = "frmTest"
        Me.Text = "SimpleD Test"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFile As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents chkSplitNewLine As System.Windows.Forms.CheckBox
    Friend WithEvents chkSplitTabs As System.Windows.Forms.CheckBox
    Friend WithEvents txtError As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lstProperties As System.Windows.Forms.ListBox
    Friend WithEvents lstGroups As System.Windows.Forms.ListBox
    Friend WithEvents chkAutoOpen As System.Windows.Forms.CheckBox
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents btnTimeTest As System.Windows.Forms.Button

End Class
