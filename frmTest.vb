Public Class frmTest

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim sD As New SimpleD.SimpleD

        Dim g As SimpleD.Group = sD.Create_Group("Test")

        'g.Set_Value(TextBox1)
        'g.Set_Value(NumericUpDown1)
        'g.Set_Value(CheckBox1)

        For Each Control As Object In GroupBox1.Controls
            g.Set_Value(Control)
        Next

        g = sD.Create_Group("Test2")
        For Each Control As Object In GroupBox2.Controls
            g.Set_Value(Control)
        Next

        txtFile.Text = sD.ToString(chkSplitNewLine.Checked, chkSplitTabs.Checked)
    End Sub



    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        Dim sD As New SimpleD.SimpleD
        sD.FromString(txtFile.Text)

        Dim g As SimpleD.Group = sD.Get_Group("Test")
        If g Is Nothing Then Return
        'g.Get_Value(TextBox1, "")
        'g.Get_Value(NumericUpDown1, "")
        'g.Get_Value(CheckBox1, "")

        For Each Control As Object In GroupBox1.Controls
            g.Get_Value(Control, "")
        Next


        g = sD.Get_Group("test2")
        'If g Is Nothing Then Return
        For Each Control As Object In GroupBox2.Controls
            g.Get_Value(Control, "")
        Next

    End Sub

    Private Sub chkSplitNewLine_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSplitNewLine.CheckedChanged
        chkSplitTabs.Enabled = chkSplitNewLine.Checked
    End Sub
End Class
