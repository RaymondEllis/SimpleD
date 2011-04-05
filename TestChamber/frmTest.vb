'Note: This file is for TESTING only it is not at all clean.
Public Class frmTest

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim sD As New SimpleD.SimpleD

        Dim g As SimpleD.Group = sD.CreateGroup("Test")

        'g.SetValue(TextBox1)
        'g.SetValue(NumericUpDown1)
        'g.SetValue(CheckBox1)

        For Each Control As Object In GroupBox1.Controls
            g.SetValue(Control)
        Next

        g = sD.CreateGroup("Test2")
        For Each Control As Object In GroupBox2.Controls
            g.SetValue(Control)
        Next

        txtFile.Text = sD.ToString(chkSplitNewLine.Checked, chkSplitTabs.Checked)
    End Sub

    Dim OpenSD As SimpleD.SimpleD
    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        Dim LastSelected As Integer = lstGroups.SelectedIndex
        'Dim sD As New SimpleD.SimpleD
        OpenSD = New SimpleD.SimpleD
        txtError.Text = "Error:" & OpenSD.FromString(txtFile.Text)

        lstGroups.Items.Clear()

        For Each grp As SimpleD.Group In OpenSD.Groups
            DoGroup(grp, "")
        Next

        If LastSelected < lstGroups.Items.Count Then
            lstGroups.SelectedIndex = LastSelected
        ElseIf lstGroups.Items.Count > 0 Then
            lstGroups.SelectedIndex = 0
        End If


        On Error Resume Next
        Dim g As SimpleD.Group = OpenSD.GetGroup("Test")
        If g Is Nothing Then Return

        'g.GetValue(TextBox1, "")
        'g.GetValue(NumericUpDown1, "")
        'g.GetValue(CheckBox1, "")

        For Each Control As Object In GroupBox1.Controls
            g.GetValue(Control, "")
        Next

        g = OpenSD.GetGroup("test2")
        If g Is Nothing Then Return
        For Each Control As Object In GroupBox2.Controls
            g.GetValue(Control, "")
        Next

    End Sub
#Region "Group list box en stuff.)"
    Private Structure gItem
        Public Group As SimpleD.Group
        Public Level As String
        Public Sub New(ByVal Level As String, ByVal Group As SimpleD.Group)
            Me.Level = Level
            Me.Group = Group
        End Sub
        Public Overrides Function ToString() As String
            Return Level
        End Function
    End Structure

    Private Sub DoGroup(ByVal g As SimpleD.Group, ByVal Level As String)
        If Level = "" Then
            Level &= g.Name
        Else
            Level &= "," & g.Name
        End If

        lstGroups.Items.Add(New gItem(Level, g))

        For Each grp As SimpleD.Group In g.Groups
            DoGroup(grp, Level)
        Next
    End Sub

    Private Sub lstGroups_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstGroups.SelectedIndexChanged
        If lstGroups.SelectedIndex < 0 Then Return

        'Set properties.
        lstProperties.Items.Clear()
        For Each prop As SimpleD.Prop In lstGroups.SelectedItem.Group.Properties
            lstProperties.Items.Add(prop.Name & "=" & prop.Value)
        Next
    End Sub
#End Region

    Private Sub chkSplitNewLine_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSplitNewLine.CheckedChanged
        chkSplitTabs.Enabled = chkSplitNewLine.Checked
    End Sub

    Private Sub txtFile_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFile.TextChanged
        If chkAutoOpen.Checked Then
            btnOpen_Click(sender, e)
        End If
    End Sub

    Private Sub btnTimeTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimeTest.Click
        frmTime.Show()
    End Sub
End Class
