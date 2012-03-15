<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.grpGroup1 = New System.Windows.Forms.GroupBox()
        Me.grpSubGroup = New System.Windows.Forms.GroupBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.grpOtherGroup = New System.Windows.Forms.GroupBox()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txtErrors = New System.Windows.Forms.TextBox()
        Me.btnToString = New System.Windows.Forms.Button()
        Me.btnFromString = New System.Windows.Forms.Button()
        Me.txtData = New System.Windows.Forms.TextBox()
        Me.grpGroup1.SuspendLayout()
        Me.grpSubGroup.SuspendLayout()
        Me.grpOtherGroup.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(6, 19)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Text = "Some text"
        '
        'grpGroup1
        '
        Me.grpGroup1.Controls.Add(Me.grpSubGroup)
        Me.grpGroup1.Controls.Add(Me.TextBox1)
        Me.grpGroup1.Location = New System.Drawing.Point(12, 12)
        Me.grpGroup1.Name = "grpGroup1"
        Me.grpGroup1.Size = New System.Drawing.Size(119, 105)
        Me.grpGroup1.TabIndex = 3
        Me.grpGroup1.TabStop = False
        Me.grpGroup1.Text = "The Group"
        '
        'grpSubGroup
        '
        Me.grpSubGroup.Controls.Add(Me.CheckBox1)
        Me.grpSubGroup.Location = New System.Drawing.Point(11, 45)
        Me.grpSubGroup.Name = "grpSubGroup"
        Me.grpSubGroup.Size = New System.Drawing.Size(95, 53)
        Me.grpSubGroup.TabIndex = 3
        Me.grpSubGroup.TabStop = False
        Me.grpSubGroup.Text = "SubGroup"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(7, 20)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "CheckBox1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'grpOtherGroup
        '
        Me.grpOtherGroup.Controls.Add(Me.NumericUpDown1)
        Me.grpOtherGroup.Location = New System.Drawing.Point(12, 123)
        Me.grpOtherGroup.Name = "grpOtherGroup"
        Me.grpOtherGroup.Size = New System.Drawing.Size(119, 56)
        Me.grpOtherGroup.TabIndex = 3
        Me.grpOtherGroup.TabStop = False
        Me.grpOtherGroup.Text = "Other Group"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(11, 20)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(95, 20)
        Me.NumericUpDown1.TabIndex = 0
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(141, 210)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(86, 13)
        Me.label1.TabIndex = 15
        Me.label1.Text = "fromString errors:"
        '
        'txtErrors
        '
        Me.txtErrors.Location = New System.Drawing.Point(233, 207)
        Me.txtErrors.Name = "txtErrors"
        Me.txtErrors.Size = New System.Drawing.Size(309, 20)
        Me.txtErrors.TabIndex = 14
        '
        'btnToString
        '
        Me.btnToString.Location = New System.Drawing.Point(137, 41)
        Me.btnToString.Name = "btnToString"
        Me.btnToString.Size = New System.Drawing.Size(90, 23)
        Me.btnToString.TabIndex = 13
        Me.btnToString.Text = "> toString >"
        Me.btnToString.UseVisualStyleBackColor = True
        '
        'btnFromString
        '
        Me.btnFromString.Location = New System.Drawing.Point(137, 12)
        Me.btnFromString.Name = "btnFromString"
        Me.btnFromString.Size = New System.Drawing.Size(90, 23)
        Me.btnFromString.TabIndex = 12
        Me.btnFromString.Text = "< fromString <"
        Me.btnFromString.UseVisualStyleBackColor = True
        '
        'txtData
        '
        Me.txtData.Location = New System.Drawing.Point(233, 12)
        Me.txtData.Multiline = True
        Me.txtData.Name = "txtData"
        Me.txtData.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtData.Size = New System.Drawing.Size(309, 186)
        Me.txtData.TabIndex = 11
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(554, 239)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.txtErrors)
        Me.Controls.Add(Me.btnToString)
        Me.Controls.Add(Me.btnFromString)
        Me.Controls.Add(Me.txtData)
        Me.Controls.Add(Me.grpOtherGroup)
        Me.Controls.Add(Me.grpGroup1)
        Me.Name = "frmMain"
        Me.Text = "VB SimpleD Sample"
        Me.grpGroup1.ResumeLayout(False)
        Me.grpGroup1.PerformLayout()
        Me.grpSubGroup.ResumeLayout(False)
        Me.grpSubGroup.PerformLayout()
        Me.grpOtherGroup.ResumeLayout(False)
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents grpGroup1 As System.Windows.Forms.GroupBox
    Friend WithEvents grpSubGroup As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents grpOtherGroup As System.Windows.Forms.GroupBox
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents txtErrors As System.Windows.Forms.TextBox
    Friend WithEvents btnToString As System.Windows.Forms.Button
    Friend WithEvents btnFromString As System.Windows.Forms.Button
    Friend WithEvents txtData As System.Windows.Forms.TextBox

End Class
