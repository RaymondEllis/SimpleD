Public Class frmTime

    Private Sub btnFromString_FromStringL_Click(sender As System.Object, e As System.EventArgs) Handles btnFromString_FromStringL.Click
        startTesting()

        Dim str As String = frmTest.txtFile.Text

        runTest("FromString", Sub()
                                  Dim sd As New SimpleD.Group
                                  sd.FromString(str)
                                  sd = Nothing
                              End Sub)

        runTest("FromStringL", Sub()
                                   Dim sd As New SimpleD.Group
                                   sd.FromStringBaseL(True, str, 0, 1)
                                   sd = Nothing
                               End Sub)

        stopTesting()
    End Sub

#Region "Testing"
    Private LoopTime As Integer
    Private Sub startTesting()
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
        Dim time As Long = 0
        TotalTimer.Start()
        For i As Integer = 1 To numCount.Value
            timer.Reset()
            timer.Start()

            'Run the test
            If test IsNot Nothing Then test.Invoke()

            timer.Stop()
            time += timer.ElapsedMilliseconds
        Next
        TotalTimer.Stop()

        If test Is Nothing Then
            LoopTime = TotalTimer.ElapsedMilliseconds
            Return
        End If

        ' txtTime.Text = time / numCount.Value
        ' txtTotalTime.Text = TotalTimer.ElapsedMilliseconds

        testIndex += 1

        Dim lblName As New TextBox
        lblName.Text = testName
        lblName.Location = New Point(0, 22 * testIndex)

        Dim txtTime As New TextBox
        txtTime.Text = time / numCount.Value
        txtTime.Location = New Point(100, 22 * testIndex)

        Dim txtTotalTime As New TextBox
        txtTotalTime.Text = TotalTimer.ElapsedMilliseconds - LoopTime
        txtTotalTime.Location = New Point(200, 22 * testIndex)

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

    Private Sub btnFromStringStream_Click(sender As System.Object, e As System.EventArgs) Handles btnFromStringStream.Click
        startTesting()

        Dim file As String = "smallfiletest.sd"

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

        Dim str As String = frmTest.txtFile.Text

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
End Class