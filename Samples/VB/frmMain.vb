Imports SimpleD

Public Class frmMain
    Private Sub btnOpen_Click(sender As System.Object, e As System.EventArgs) Handles btnOpen.Click
        Dim sd As New SimpleD.SimpleD
        'Open from the string.
        sd.FromString(txtData.Text)

        Dim g As Group

        Try
            'Get The Group
            g = sd.GetGroup("the group") 'Names are not case sensitive.

            'Get the value from the group.
            g.GetValue(TextBox1)

            'Get sub group.
            g = g.GetGroup("SubGroup")
            g.GetValue("The check box", CheckBox1.Checked)

            'Get the other group.
            g = sd.GetGroup("OtherGroup")
            NumericUpDown1.Value = g.GetValue(NumericUpDown1.Name)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Dim sd As New SimpleD.SimpleD

        Dim g As Group
        'The Group
        g = sd.CreateGroup("The Group") 'Create group from sd.
        g.SetValue(TextBox1) 'Add textbox1   Can use most controls.

        'Sub group
        g = g.CreateGroup("SubGroup") 'Create the sub group from 'The Group'
        g.SetValue("The check box", CheckBox1.Checked) 'Yes there can be spaces in group and property names.

        'Other group    There is nothing new here.
        g = sd.CreateGroup("OtherGroup")
        g.SetValue(NumericUpDown1)

        'Save to the data text box.
        txtData.Text = sd.ToString
    End Sub
End Class
