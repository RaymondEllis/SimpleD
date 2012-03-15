Imports SimpleD

Public Class frmMain
    Private Sub btnFromString_Click(sender As System.Object, e As System.EventArgs) Handles btnFromString.Click
        Dim MainGroup As New Group
        'Open from the string.
        txtErrors.Text = MainGroup.FromString(txtData.Text)

        Try
            'Get The Group
            Dim TheGroup As Group = MainGroup.GetGroup("the group") 'Names are not case sensitive.

            'Get the value from the group.
            TextBox1.Text = TheGroup.GetValue(TextBox1.Name)

            'Get sub group.
            Dim SubGroup As Group = TheGroup.GetGroup("SubGroup")
            SubGroup.GetValue("The check box", CheckBox1.Checked, False)

            'Get the other group.
            Dim OtherGroup As Group = MainGroup.GetGroup("OtherGroup")
            NumericUpDown1.Value = OtherGroup.GetValue(NumericUpDown1.Name)

        Catch ex As Exception
            MsgBox(ex.Message, , "Error")
        End Try
    End Sub

    Private Sub btnToString_Click(sender As System.Object, e As System.EventArgs) Handles btnToString.Click
        Dim MainGroup As New Group

        'The Group
        Dim TheGroup As Group = MainGroup.CreateGroup("The Group") 'Create group from sd.
        TheGroup.SetValue(TextBox1.Name, TextBox1.Text) 'Add textbox1   Can use most controls.

        'Sub group
        Dim SubGroup As Group = TheGroup.CreateGroup("SubGroup") 'Create the sub group from 'The Group'
        SubGroup.SetValue("The check box", CheckBox1.Checked) 'Yes there can be spaces in group and property names.

        'Other group    There is nothing new here.
        Dim OtherGroup As Group = MainGroup.CreateGroup("OtherGroup")
        OtherGroup.BraceStyle = Group.Style.NoStyle 'Set the brace style.
        OtherGroup.SetValue(NumericUpDown1.Name, NumericUpDown1.Value)

        'Save to the data text box.
        txtData.Text = MainGroup.ToString
    End Sub
End Class
