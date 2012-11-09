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
        Me.lblComment = New System.Windows.Forms.Label()
        Me.lblLine = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lstTests
        '
        Me.lstTests.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.lstTests.FormattingEnabled = True
        Me.lstTests.Location = New System.Drawing.Point(12, 12)
        Me.lstTests.Name = "lstTests"
        Me.lstTests.Size = New System.Drawing.Size(254, 238)
        Me.lstTests.TabIndex = 0
        '
        'btnRun
        '
        Me.btnRun.Location = New System.Drawing.Point(580, 227)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(95, 23)
        Me.btnRun.TabIndex = 1
        Me.btnRun.Text = "Reload and Run"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(272, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Output:"
        '
        'txtOutput
        '
        Me.txtOutput.Location = New System.Drawing.Point(275, 117)
        Me.txtOutput.Multiline = True
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.Size = New System.Drawing.Size(400, 40)
        Me.txtOutput.TabIndex = 3
        Me.txtOutput.Text = "g{test;}"
        '
        'txtExpectedOutput
        '
        Me.txtExpectedOutput.Location = New System.Drawing.Point(275, 176)
        Me.txtExpectedOutput.Multiline = True
        Me.txtExpectedOutput.Name = "txtExpectedOutput"
        Me.txtExpectedOutput.Size = New System.Drawing.Size(400, 40)
        Me.txtExpectedOutput.TabIndex = 4
        Me.txtExpectedOutput.Text = "g{test;}"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(272, 160)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Expected Output:"
        '
        'txtTest
        '
        Me.txtTest.Location = New System.Drawing.Point(275, 55)
        Me.txtTest.Multiline = True
        Me.txtTest.Name = "txtTest"
        Me.txtTest.Size = New System.Drawing.Size(400, 40)
        Me.txtTest.TabIndex = 6
        Me.txtTest.Text = "g{test;"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(272, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Test:"
        '
        'lblComment
        '
        Me.lblComment.AutoSize = True
        Me.lblComment.Location = New System.Drawing.Point(272, 12)
        Me.lblComment.Name = "lblComment"
        Me.lblComment.Size = New System.Drawing.Size(79, 13)
        Me.lblComment.TabIndex = 5
        Me.lblComment.Text = "Last comment: "
        '
        'lblLine
        '
        Me.lblLine.AutoSize = True
        Me.lblLine.Location = New System.Drawing.Point(577, 12)
        Me.lblLine.Name = "lblLine"
        Me.lblLine.Size = New System.Drawing.Size(33, 13)
        Me.lblLine.TabIndex = 7
        Me.lblLine.Text = "Line: "
        '
        'frmRunTests
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 263)
        Me.Controls.Add(Me.lblLine)
        Me.Controls.Add(Me.txtTest)
        Me.Controls.Add(Me.lblComment)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtExpectedOutput)
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnRun)
        Me.Controls.Add(Me.lstTests)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
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
    Friend WithEvents lblComment As System.Windows.Forms.Label
    Friend WithEvents lblLine As System.Windows.Forms.Label
End Class
