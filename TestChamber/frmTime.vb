Public Class frmTime

    Private Sub btnFromString_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFromString.Click
        Dim str As String = frmTest.txtFile.Text 'Get the string from the main form. (frmTest)
        Panel1.Enabled = False

        Dim TotalTimer As New highTimer
        Dim timer As New highTimer
        Dim time As Double = 0
        TotalTimer.StartTimer()
        For i As Integer = 1 To numCount.Value
            timer.StartTimer()
            Dim sd As New SimpleD.SimpleD(str)
            timer.StopTimer()
            time += timer.TimeElapsed(highTimer.PerformanceValue.pvMilliSecond)
        Next
        TotalTimer.StopTimer()

        txtTime.Text = time / numCount.Value
        txtTotalTime.Text = TotalTimer.TimeElapsed(highTimer.PerformanceValue.pvSecond)

        Panel1.Enabled = True
    End Sub
End Class