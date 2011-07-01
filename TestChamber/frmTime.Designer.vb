<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTime
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.numCount = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnFromString = New System.Windows.Forms.Button()
        Me.btnToString = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTime = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTotalTime = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTime2 = New System.Windows.Forms.TextBox()
        Me.txtTotalTime2 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.numCount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(202, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "This will test the string from the main form."
        '
        'numCount
        '
        Me.numCount.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numCount.Location = New System.Drawing.Point(3, 16)
        Me.numCount.Maximum = New Decimal(New Integer() {276447232, 23283, 0, 0})
        Me.numCount.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numCount.Name = "numCount"
        Me.numCount.Size = New System.Drawing.Size(120, 20)
        Me.numCount.TabIndex = 1
        Me.numCount.Value = New Decimal(New Integer() {1000, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Count:"
        '
        'btnFromString
        '
        Me.btnFromString.Location = New System.Drawing.Point(3, 42)
        Me.btnFromString.Name = "btnFromString"
        Me.btnFromString.Size = New System.Drawing.Size(75, 23)
        Me.btnFromString.TabIndex = 3
        Me.btnFromString.Text = "FromString"
        Me.btnFromString.UseVisualStyleBackColor = True
        '
        'btnToString
        '
        Me.btnToString.Enabled = False
        Me.btnToString.Location = New System.Drawing.Point(3, 71)
        Me.btnToString.Name = "btnToString"
        Me.btnToString.Size = New System.Drawing.Size(75, 23)
        Me.btnToString.TabIndex = 3
        Me.btnToString.Text = "ToString"
        Me.btnToString.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 174)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "avg ms Time:"
        '
        'txtTime
        '
        Me.txtTime.Location = New System.Drawing.Point(12, 190)
        Me.txtTime.Name = "txtTime"
        Me.txtTime.Size = New System.Drawing.Size(202, 20)
        Me.txtTime.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.numCount)
        Me.Panel1.Controls.Add(Me.btnFromString)
        Me.Panel1.Controls.Add(Me.btnToString)
        Me.Panel1.Location = New System.Drawing.Point(15, 58)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 99)
        Me.Panel1.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 224)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "total s Time:"
        '
        'txtTotalTime
        '
        Me.txtTotalTime.Location = New System.Drawing.Point(12, 240)
        Me.txtTotalTime.Name = "txtTotalTime"
        Me.txtTotalTime.Size = New System.Drawing.Size(202, 20)
        Me.txtTotalTime.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(220, 174)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "avg ms Time:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(220, 224)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "total s Time:"
        '
        'txtTime2
        '
        Me.txtTime2.Location = New System.Drawing.Point(220, 190)
        Me.txtTime2.Name = "txtTime2"
        Me.txtTime2.Size = New System.Drawing.Size(202, 20)
        Me.txtTime2.TabIndex = 5
        '
        'txtTotalTime2
        '
        Me.txtTotalTime2.Location = New System.Drawing.Point(220, 240)
        Me.txtTotalTime2.Name = "txtTotalTime2"
        Me.txtTotalTime2.Size = New System.Drawing.Size(202, 20)
        Me.txtTotalTime2.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(284, 161)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "FromString2"
        '
        'frmTime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 269)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtTotalTime2)
        Me.Controls.Add(Me.txtTotalTime)
        Me.Controls.Add(Me.txtTime2)
        Me.Controls.Add(Me.txtTime)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmTime"
        Me.Text = "SimpleD Timer test"
        CType(Me.numCount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents numCount As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnFromString As System.Windows.Forms.Button
    Friend WithEvents btnToString As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTime As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTotalTime As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTime2 As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalTime2 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
