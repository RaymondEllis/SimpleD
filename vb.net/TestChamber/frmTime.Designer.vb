﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.comFile = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnToString = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnFromStringStream = New System.Windows.Forms.Button()
        Me.btnFromEqualsSemi = New System.Windows.Forms.Button()
        Me.panTests = New System.Windows.Forms.Panel()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.btnCopyToClip = New System.Windows.Forms.Button()
        CType(Me.numCount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        Me.numCount.Location = New System.Drawing.Point(6, 16)
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
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.comFile)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.numCount)
        Me.Panel1.Location = New System.Drawing.Point(15, 36)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(373, 311)
        Me.Panel1.TabIndex = 6
        '
        'comFile
        '
        Me.comFile.FormattingEnabled = True
        Me.comFile.Location = New System.Drawing.Point(132, 15)
        Me.comFile.Name = "comFile"
        Me.comFile.Size = New System.Drawing.Size(226, 21)
        Me.comFile.TabIndex = 11
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnToString)
        Me.GroupBox2.Location = New System.Drawing.Point(185, 58)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(173, 237)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ToString"
        '
        'btnToString
        '
        Me.btnToString.Location = New System.Drawing.Point(6, 19)
        Me.btnToString.Name = "btnToString"
        Me.btnToString.Size = New System.Drawing.Size(158, 23)
        Me.btnToString.TabIndex = 4
        Me.btnToString.Text = "ToString"
        Me.btnToString.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnFromStringStream)
        Me.GroupBox1.Controls.Add(Me.btnFromEqualsSemi)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 58)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(173, 237)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Parse(FromString)"
        '
        'btnFromStringStream
        '
        Me.btnFromStringStream.Location = New System.Drawing.Point(6, 71)
        Me.btnFromStringStream.Name = "btnFromStringStream"
        Me.btnFromStringStream.Size = New System.Drawing.Size(158, 23)
        Me.btnFromStringStream.TabIndex = 4
        Me.btnFromStringStream.Text = "FromString vs FromStream"
        Me.btnFromStringStream.UseVisualStyleBackColor = True
        '
        'btnFromEqualsSemi
        '
        Me.btnFromEqualsSemi.Location = New System.Drawing.Point(6, 19)
        Me.btnFromEqualsSemi.Name = "btnFromEqualsSemi"
        Me.btnFromEqualsSemi.Size = New System.Drawing.Size(158, 46)
        Me.btnFromEqualsSemi.TabIndex = 3
        Me.btnFromEqualsSemi.Text = "no Eueals or Semi" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Equals and Semi VS"
        Me.btnFromEqualsSemi.UseVisualStyleBackColor = True
        '
        'panTests
        '
        Me.panTests.Location = New System.Drawing.Point(394, 36)
        Me.panTests.Name = "panTests"
        Me.panTests.Size = New System.Drawing.Size(381, 295)
        Me.panTests.TabIndex = 8
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(391, 334)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(40, 13)
        Me.lblStatus.TabIndex = 9
        Me.lblStatus.Text = "Status:"
        '
        'btnCopyToClip
        '
        Me.btnCopyToClip.Location = New System.Drawing.Point(700, 331)
        Me.btnCopyToClip.Name = "btnCopyToClip"
        Me.btnCopyToClip.Size = New System.Drawing.Size(75, 23)
        Me.btnCopyToClip.TabIndex = 10
        Me.btnCopyToClip.Text = "Copy"
        Me.btnCopyToClip.UseVisualStyleBackColor = True
        '
        'frmTime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(797, 357)
        Me.Controls.Add(Me.btnCopyToClip)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.panTests)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmTime"
        Me.Text = "SimpleD Timer test"
        CType(Me.numCount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents numCount As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents panTests As System.Windows.Forms.Panel
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnFromStringStream As System.Windows.Forms.Button
    Friend WithEvents btnFromEqualsSemi As System.Windows.Forms.Button
    Friend WithEvents comFile As System.Windows.Forms.ComboBox
    Friend WithEvents btnCopyToClip As System.Windows.Forms.Button
    Friend WithEvents btnToString As System.Windows.Forms.Button
End Class
