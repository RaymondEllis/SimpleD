Imports SimpleD

Public Class frmMain
    Private Sub btnOpen_Click(sender As System.Object, e As System.EventArgs) Handles btnOpen.Click
        Dim MainGroup As New SimpleD.Group
        'Open from the string.
        MainGroup.FromString(txtData.Text)

        Dim g As Group

        Try
            'Get The Group
            g = MainGroup.GetGroup("the group") 'Names are not case sensitive.

            'Get the value from the group.
            TextBox1.Text = g.GetValue(TextBox1.Name)

            'Get sub group.
            g = g.GetGroup("SubGroup")
            g.GetValue("The check box", CheckBox1.Checked, False)

            'Get the other group.
            g = MainGroup.GetGroup("OtherGroup")
            NumericUpDown1.Value = g.GetValue(NumericUpDown1.Name)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Dim MainGroup As New SimpleD.Group

        Dim g As Group
        'The Group
        g = MainGroup.CreateGroup("The Group") 'Create group from sd.
        g.SetValue(TextBox1.Name, TextBox1.Text) 'Add textbox1   Can use most controls.

        'Sub group
        g = g.CreateGroup("SubGroup") 'Create the sub group from 'The Group'
        g.SetValue("The check box", CheckBox1.Checked) 'Yes there can be spaces in group and property names.

        'Other group    There is nothing new here.
        g = MainGroup.CreateGroup("OtherGroup")
        g.SetValue(NumericUpDown1.Name, NumericUpDown1.Value)

        'Save to the data text box.
        txtData.Text = MainGroup.ToString
    End Sub
End Class
