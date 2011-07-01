Public Class frmTime

    Private Sub btnFromString_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFromString.Click
        Dim str As String = frmTest.txtFile.Text 'Get the string from the main form. (frmTest)
        Panel1.Enabled = False

        Dim TotalTimer As New Stopwatch
        Dim timer As New Stopwatch
        Dim time As Double = 0
        TotalTimer.Start()
        For i As Integer = 1 To numCount.Value
            timer.Start()
            Dim sd As New SimpleD.Group()
            sd.FromString(str)
            timer.Stop()
            time += timer.ElapsedMilliseconds
        Next
        TotalTimer.Stop()

        txtTime.Text = time / numCount.Value
        txtTotalTime.Text = TotalTimer.Elapsed.Seconds


        'Time2
        time = 0
        timer.Reset()
        TotalTimer.Reset()


        TotalTimer.Start()
        For i As Integer = 1 To numCount.Value
            timer.Start()
            Dim sd As New SimpleD.Group()
            sd.FromString2(str)
            timer.Stop()
            time += timer.ElapsedMilliseconds
        Next
        TotalTimer.Stop()

        txtTime2.Text = time / numCount.Value
        txtTotalTime2.Text = TotalTimer.Elapsed.Seconds

        Panel1.Enabled = True
    End Sub
End Class