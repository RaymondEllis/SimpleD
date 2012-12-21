Public Class frmTime
    Dim str As String
    Dim file As String
    Private CopyStr As System.Text.StringBuilder = Nothing

#Region "Testing"
    Private LoopTime As Integer
    Private Sub startTesting()
        CopyStr = New System.Text.StringBuilder()
        panTests.Controls.Clear()
        testIndex = 0

        Panel1.Enabled = False

        SimpleD.AllowEqualsInValue = True
        SimpleD.AllowSemicolonInValue = True

        runTest("Loop check", Nothing)

    End Sub
    Private Sub stopTesting()
        Status("Done")
        Panel1.Enabled = True
    End Sub

    Private testIndex As Integer
    Private Sub runTest(ByVal testName As String, ByVal test As Action)
        Status("Running test: " & testName)
        'Threading.Tasks.Task.Factory.s
        Dim TotalTimer As New Stopwatch
        Dim timer As New Stopwatch
        Dim time As Double = 0
        TotalTimer.Start()
        For i As Integer = 1 To numCount.Value
            timer.Reset()
            timer.Start()

            'Run the test
            If test IsNot Nothing Then test.Invoke()

            timer.Stop()
            time += timer.ElapsedTicks / Stopwatch.Frequency
        Next
        TotalTimer.Stop()

        If test Is Nothing Then
            LoopTime = TotalTimer.ElapsedTicks / Stopwatch.Frequency
            Return
        End If


        testIndex += 1
        Dim lblName As New TextBox
        lblName.Text = testName
        lblName.Location = New Point(0, 22 * testIndex)
        CopyStr.AppendLine()
        CopyStr.Append(testName & ": " & vbTab)

        Dim txtTime As New TextBox
        txtTime.Text = Math.Round(time / numCount.Value * 10000) / 10 & "ms"
        txtTime.Location = New Point(100, 22 * testIndex)
        CopyStr.Append(txtTime.Text & vbTab & vbTab)

        Dim txtTotalTime As New TextBox
        txtTotalTime.Text = TotalTimer.ElapsedMilliseconds - LoopTime & "ms"
        txtTotalTime.Location = New Point(200, 22 * testIndex)
        CopyStr.Append(txtTotalTime.Text)

        With panTests.Controls
            .Add(lblName)
            .Add(txtTime)
            .Add(txtTotalTime)
        End With
    End Sub

    Private Sub Status(ByVal text As String)
        lblStatus.Text = "Status: " & text
        Application.DoEvents()
    End Sub
#End Region

#Region "Parse(FromString)"
    Private Sub btnFromStringStream_Click(sender As System.Object, e As System.EventArgs) Handles btnFromStringStream.Click
        startTesting()

        runTest("FromString", Sub()
                                  Dim sd As New SimpleD.Group()
                                  Dim sr As New IO.StreamReader(file)
                                  sd.FromString(sr.ReadToEnd)
                                  sr.Close()
                                  sd = Nothing

                              End Sub)

        runTest("FromStream", Sub()
                                  Dim sd As New SimpleD.Group()
                                  sd.FromStream(New IO.StreamReader(file), True)
                                  sd = Nothing
                              End Sub)

        stopTesting()
    End Sub

    Private Sub btnFromEqualsSemi_Click(sender As System.Object, e As System.EventArgs) Handles btnFromEqualsSemi.Click
        startTesting()

        SimpleD.AllowEqualsInValue = False
        SimpleD.AllowSemicolonInValue = False
        runTest("Disallowed", Sub()
                                  Dim sd As New SimpleD.Group
                                  sd.FromString(str)
                                  sd = Nothing
                              End Sub)

        SimpleD.AllowEqualsInValue = True
        SimpleD.AllowSemicolonInValue = True
        runTest("Allowed", Sub()
                               Dim sd As New SimpleD.Group
                               sd.FromString(str)
                               sd = Nothing
                           End Sub)

        stopTesting()
    End Sub
#End Region

#Region "ToString"

    Private Sub btnToString_Click(sender As System.Object, e As System.EventArgs) Handles btnToString.Click
        startTesting()

        Dim sd As New SimpleD.Group()
        Dim sr As New IO.StreamReader(file)
        sd.FromString(sr.ReadToEnd)
        sr.Close()

        runTest("ToString", Sub()
                                sd.ToString()
                            End Sub)


        stopTesting()
    End Sub

#End Region

    Private Sub frmTime_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        comFile.Items.AddRange(IO.Directory.GetFiles("..\..\Time Tests\", "*.sd"))
        comFile.SelectedIndex = 0
    End Sub

    Private Sub comFile_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles comFile.SelectedIndexChanged
        file = comFile.Items(comFile.SelectedIndex)
        Dim sr As New IO.StreamReader(file)
        str = sr.ReadToEnd
        sr.Close()
    End Sub

    Private Sub btnCopyToClip_Click(sender As System.Object, e As System.EventArgs) Handles btnCopyToClip.Click
        If Not CopyStr Is Nothing Then My.Computer.Clipboard.SetText(CopyStr.ToString)
    End Sub

End Class