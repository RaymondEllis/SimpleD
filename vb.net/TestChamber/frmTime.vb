Public Class frmTime

    Private Sub btnFromString_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFromString.Click
        Dim str As String = frmTest.txtFile.Text 'Get the string from the main form. (frmTest)
        Panel1.Enabled = False

        lblTest1.Text = "Test1= Allow Equals and Semicolon"
        lblTest2.Text = "Test2= Disallow Equals and Semicolon"

        SimpleD.AllowEqualsInValue = True
        SimpleD.AllowSemicolonInValue = True
        Dim TotalTimer As New Stopwatch
        Dim timer As New Stopwatch
        Dim time As Long = 0
        TotalTimer.Start()
        For i As Integer = 1 To numCount.Value
            timer.Reset()
            timer.Start()
            Dim sd As New SimpleD.Group()
            sd.FromString(str)
            'sd.ToString()
            timer.Stop()
            time += timer.ElapsedMilliseconds
        Next
        TotalTimer.Stop()

        txtTime.Text = time / numCount.Value
        txtTotalTime.Text = TotalTimer.ElapsedMilliseconds


        'Time2
        time = 0
        timer.Reset()
        TotalTimer.Reset()

        SimpleD.AllowEqualsInValue = False
        SimpleD.AllowSemicolonInValue = False
        TotalTimer.Start()
        For i As Integer = 1 To numCount.Value
            timer.Reset()
            timer.Start()
            Dim g As New SimpleD.Group()
            g.FromString(str)
            'g.ToString()
            timer.Stop()
            time += timer.ElapsedMilliseconds
        Next
        TotalTimer.Stop()

        txtTime2.Text = time / numCount.Value
        txtTotalTime2.Text = TotalTimer.ElapsedMilliseconds

        Panel1.Enabled = True

        SimpleD.AllowEqualsInValue = frmTest.chkAllowEqualsInValue.Checked
    End Sub

    Private Sub btnFromStream_Click(sender As System.Object, e As System.EventArgs) Handles btnFromStream.Click
        Dim file As String = "smallfiletest.sd"
        Panel1.Enabled = False

        lblTest1.Text = "Test1= FromStream"
        lblTest2.Text = "Test2= FromString"

        SimpleD.AllowEqualsInValue = True
        SimpleD.AllowSemicolonInValue = True
        Dim TotalTimer As New Stopwatch
        Dim timer As New Stopwatch
        Dim time As Long = 0
        TotalTimer.Start()
        For i As Integer = 1 To numCount.Value
            timer.Reset()
            timer.Start()
            Dim sd As New SimpleD.Group()
            sd.FromStream(New IO.StreamReader(file), True)
            sd = Nothing
            timer.Stop()
            time += timer.ElapsedMilliseconds
        Next
        TotalTimer.Stop()

        txtTime.Text = time / numCount.Value
        txtTotalTime.Text = TotalTimer.ElapsedMilliseconds


        'Time2
        time = 0
        timer.Reset()
        TotalTimer.Reset()

        TotalTimer.Start()
        For i As Integer = 1 To numCount.Value
            timer.Reset()
            timer.Start()
            Dim sd As New SimpleD.Group()
            Dim sr As New IO.StreamReader(file)
            sd.FromString(sr.ReadToEnd)
            sr.Close()
            sd = Nothing
            timer.Stop()
            time += timer.ElapsedMilliseconds
        Next
        TotalTimer.Stop()

        txtTime2.Text = time / numCount.Value
        txtTotalTime2.Text = TotalTimer.ElapsedMilliseconds

        Panel1.Enabled = True
    End Sub
End Class