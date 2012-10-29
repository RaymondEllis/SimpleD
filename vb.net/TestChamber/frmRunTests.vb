Public Class frmRunTests

    Public Tests As New List(Of Test)

    Private Sub frmRunTests_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        LoadTests()
        RunTests()
    End Sub

    Private Sub btnRun_Click(sender As System.Object, e As System.EventArgs) Handles btnRun.Click
        Dim selIndex As Integer = lstTests.SelectedIndex
        LoadTests()
        Me.Invalidate()
        RunTests()
        lstTests.SelectedIndex = selIndex
    End Sub

    Public Sub LoadTests()
        Tests.Clear()
        lstTests.Items.Clear()

        Dim sr As New IO.StreamReader("tests.sd")
        Dim i As Integer = -1
        Do Until sr.EndOfStream
            i += 1
            sr.ReadLine()
            Tests.Add(New Test(i, sr.ReadLine, sr.ReadLine))
            lstTests.Items.Add("U: " & Tests(Tests.Count - 1).test)
        Loop
        sr.Close()

    End Sub

    Public Sub RunTests()
        Dim passed As Integer = 0
        For Each Test As Test In Tests
            If RunTest(Test) Then passed += 1
        Next
        Me.Text = "Tests " & passed & "/" & Tests.Count & " passed"
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

    Private Sub lstTests_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstTests.SelectedIndexChanged
        Dim test As Test = Tests(lstTests.SelectedIndex)
        txtTest.Text = test.test
        txtOutput.Text = test.output
        txtExpectedOutput.Text = test.expected
    End Sub


    Public Class Test
        Public Index As Integer = -1
        Public test As String
        Public output As String
        Public expected As String

        Sub New(ByRef index As Integer, ByRef test As String, ByRef expected As String)
            Me.Index = index
            Me.test = test
            Me.expected = expected
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