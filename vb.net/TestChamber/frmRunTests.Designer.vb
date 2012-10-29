<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRunTests
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
        Me.lstTests = New System.Windows.Forms.ListBox()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.txtExpectedOutput = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTest = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lstTests
        '
        Me.lstTests.FormattingEnabled = True
        Me.lstTests.Location = New System.Drawing.Point(12, 12)
        Me.lstTests.Name = "lstTests"
        Me.lstTests.Size = New System.Drawing.Size(254, 212)
        Me.lstTests.TabIndex = 0
        '
        'btnRun
        '
        Me.btnRun.Location = New System.Drawing.Point(580, 201)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(95, 23)
        Me.btnRun.TabIndex = 1
        Me.btnRun.Text = "Reload and Run"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(272, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Output:"
        '
        'txtOutput
        '
        Me.txtOutput.Location = New System.Drawing.Point(275, 91)
        Me.txtOutput.Multiline = True
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.Size = New System.Drawing.Size(400, 40)
        Me.txtOutput.TabIndex = 3
        Me.txtOutput.Text = "g{test;}"
        '
        'txtExpectedOutput
        '
        Me.txtExpectedOutput.Location = New System.Drawing.Point(275, 150)
        Me.txtExpectedOutput.Multiline = True
        Me.txtExpectedOutput.Name = "txtExpectedOutput"
        Me.txtExpectedOutput.Size = New System.Drawing.Size(400, 40)
        Me.txtExpectedOutput.TabIndex = 4
        Me.txtExpectedOutput.Text = "g{test;}"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(272, 134)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Expected Output:"
        '
        'txtTest
        '
        Me.txtTest.Location = New System.Drawing.Point(275, 29)
        Me.txtTest.Multiline = True
        Me.txtTest.Name = "txtTest"
        Me.txtTest.Size = New System.Drawing.Size(400, 40)
        Me.txtTest.TabIndex = 6
        Me.txtTest.Text = "g{test;"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(272, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Test:"
        '
        'frmRunTests
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 236)
        Me.Controls.Add(Me.txtTest)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtExpectedOutput)
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnRun)
        Me.Controls.Add(Me.lstTests)
        Me.Name = "frmRunTests"
        Me.Text = "Tests"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstTests As System.Windows.Forms.ListBox
    Friend WithEvents btnRun As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtOutput As System.Windows.Forms.TextBox
    Friend WithEvents txtExpectedOutput As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTest As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
