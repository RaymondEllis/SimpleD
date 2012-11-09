Public Class frmRunTests

    Public Tests As New List(Of Test)

    Private Sub frmRunTests_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        RunTests()
    End Sub

    Private Sub btnRun_Click(sender As System.Object, e As System.EventArgs) Handles btnRun.Click
        Dim selIndex As Integer = lstTests.SelectedIndex
        RunTests()
        Me.Invalidate()
        lstTests.SelectedIndex = selIndex
    End Sub

    Public Sub RunTests()
        Tests.Clear()
        lstTests.Items.Clear()

        Dim passed As Integer = 0
        Dim lastComment As String = ""

        'Load and run
        Dim sr As New IO.StreamReader("tests.sd")
        Dim i As Integer = -1
        Do Until sr.EndOfStream
            Dim tmpComment As String = sr.ReadLine
            'Do we setup?
            If tmpComment = """Setup""" Then
                Boolean.TryParse(sr.ReadLine, SimpleD.AllowEqualsInValue)
                Boolean.TryParse(sr.ReadLine, SimpleD.AllowSemicolonInValue)

            Else
                If tmpComment <> "" And tmpComment <> """""" Then lastComment = tmpComment
                'Load the test
                i += 1
                Tests.Add(New Test(i, sr.ReadLine, sr.ReadLine, lastComment))
                lstTests.Items.Add("U: " & Tests(Tests.Count - 1).test)
                'Run the test
                If RunTest(Tests(i)) Then passed += 1
            End If

        Loop
        sr.Close()

        Me.Text = String.Format("SimpleD - Tests {0}/{1} ({2}%) passed  {3} failed", passed, Tests.Count, Math.Round(passed / Tests.Count * 100), Tests.Count - passed)
    End Sub

    Public Function RunTest(ByRef Test As Test) As Boolean
        Dim g As New SimpleD.Group(, SimpleD.Group.Style.NoStyle)
        g.FromString(Test.test)
        Test.output = g.ToString(False)
        lstTests.Items(Test.Index) = Test.ToString
        Me.Invalidate()

        'Return true if passed
        Return Test.output = Test.expected
    End Function

    'Color the results.
    Private Sub lstTests_DrawItem(sender As Object, e As System.Windows.Forms.DrawItemEventArgs) Handles lstTests.DrawItem
        If lstTests.Items.Count = 0 Or e.Index = -1 Then Return
        Dim isSelected As Boolean = (e.State And DrawItemState.Selected) = DrawItemState.Selected

        'Get color for background
        Dim backColor As Brush = Brushes.DarkGreen
        Select Case lstTests.Items(e.Index).ToString(0)
            Case "p"
                If isSelected Then backColor = New SolidBrush(Color.FromArgb(0, 200, 0))

            Case "F"
                backColor = Brushes.DarkRed
                If isSelected Then backColor = Brushes.Red

        End Select
        e.Graphics.FillRectangle(backColor, e.Bounds) 'Draw the background

        'Draw text
        e.Graphics.DrawString(lstTests.Items(e.Index).ToString, e.Font, Brushes.White, e.Bounds.Location)
    End Sub

    Private Sub lstTests_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstTests.SelectedIndexChanged
        Dim test As Test = Tests(lstTests.SelectedIndex)
        txtTest.Text = test.test
        txtOutput.Text = test.output
        txtExpectedOutput.Text = test.expected
        lblComment.Text = "Last comment: " & test.comment
    End Sub



    Public Class Test
        Public Index As Integer = -1
        Public test As String
        Public output As String
        Public expected As String

        Public comment As String

        Sub New(ByRef index As Integer, ByRef test As String, ByRef expected As String, ByRef commant As String)
            Me.Index = index
            Me.test = test
            Me.expected = expected
            Me.comment = commant
        End Sub

        Public Overrides Function ToString() As String
            If output = expected Then
                Return "passed: " & test
            Else
                Return "FAILED: " & test
            End If
        End Function
    End Class
End Class