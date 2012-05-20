'Note: This file is for TESTING only it is not at all clean.
'Note: This file is for TESTING only it is not at all clean.
'Note: This file is for TESTING only it is not at all clean.
'Note: This file is for TESTING only it is not at all clean.
Public Class frmTest

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim sD As New SimpleD.Group

        Dim g As SimpleD.Group = sD.CreateGroup("Test")


        For Each Control As Object In GroupBox1.Controls
            SetValue(Control, g)
        Next

        g = sD.CreateGroup("Test2")
        For Each Control As Object In GroupBox2.Controls
            SetValue(Control, g)
        Next

        sD.BraceStyle = comBraceStyle.SelectedIndex
        txtFile.Text = sD.ToString()
    End Sub


    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        Dim LastSelected As Integer = lstGroups.SelectedIndex
        If LastSelected = -1 Then LastSelected = 0

        Dim sd As New SimpleD.Group
        SimpleD.AllowEqualsInValue = chkAllowEqualsInValue.Checked
        SimpleD.AllowSemicolonInValue = chkAllowSemicolon.Checked
        txtError.Text = "Error:" & sd.FromString(txtFile.Text)

        'sd.RemoveDuplicateGroups(True)
        'sd.RemoveDuplicateGroups("Test", True)


        lstGroups.Items.Clear()

        DoGroup(sd, "")

        If LastSelected < lstGroups.Items.Count Then
            lstGroups.SelectedIndex = LastSelected
        ElseIf lstGroups.Items.Count > 0 Then
            lstGroups.SelectedIndex = 0
        End If

        If chkResave.Checked Then
            sd.BraceStyle = comBraceStyle.SelectedIndex
            txtResave.Text = sd.ToString(False)
        End If

        'On Error Resume Next
        Dim g As SimpleD.Group = sd.GetGroup("Test")
        If g Is Nothing Then Return

        'g.GetValue(TextBox1, "")
        'g.GetValue(NumericUpDown1, "")
        'g.GetValue(CheckBox1, "")

        For Each Control As Control In GroupBox1.Controls
            GetValue(Control, g)
        Next

        g = sd.GetGroup("test2")
        If g Is Nothing Then Return
        For Each Control As Control In GroupBox2.Controls
            GetValue(Control, g)
        Next

    End Sub

#Region "Get/Set value to/from control v1" 'Update to https://code.google.com/p/simpled/wiki/control_helper
    ''' <summary>
    ''' Sets the value of the control to the proprety with the same name.
    ''' Known controls: TextBox,Label,CheckBox,RadioButton,NumericUpDown,ProgressBar
    ''' </summary>
    ''' <param name="Control">The control to get the property from.</param>
    ''' <param name="Group">The group to get the value from.</param>
    Public Sub GetValue(ByRef Control As Windows.Forms.Control, Group As SimpleD.Group)
        Dim [Property] As SimpleD.Property = Group.Find(Control.Name) 'Find the property from the control name.
        If [Property] Is Nothing Then Return
        Dim TempValue As String = [Property].Value
        Dim obj As Object = Control
        If TypeOf Control Is Windows.Forms.TextBox Or TypeOf Control Is Windows.Forms.Label Then
            obj.Text = TempValue
        ElseIf TypeOf Control Is Windows.Forms.CheckBox Or TypeOf Control Is Windows.Forms.RadioButton Then
            If Not Boolean.TryParse(TempValue, obj.Checked) Then Return
        ElseIf TypeOf Control Is Windows.Forms.NumericUpDown Or TypeOf Control Is Windows.Forms.ProgressBar Then
            Dim tValue As Decimal = 0
            If Decimal.TryParse(TempValue, tValue) Then
                If tValue > obj.Maximum Then
                    obj.Value = obj.Maximum
                ElseIf tValue < obj.Minimum Then
                    obj.Value = obj.Minimum
                Else
                    obj.Value = tValue
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' This sets the value of a property.
    ''' If it can not find the property it creates it.
    ''' </summary>
    Public Sub SetValue(ByVal Control As Windows.Forms.Control, Group As SimpleD.Group)
        Dim Value As String = GetValueFromControl(Control) 'Find the property from a object and set the value.
        Dim tmp As SimpleD.Property = Group.Find(Control.Name) 'Find the property.
        If tmp Is Nothing Then 'If it could not find the property then.
            Group.Properties.Add(New SimpleD.Property(Control.Name, Value)) 'Add the property.
        Else
            tmp.Value = Value 'Set the value.
        End If
    End Sub
    Private Function GetValueFromControl(ByVal Obj As Object) As String
        If TypeOf Obj Is Windows.Forms.TextBox Or TypeOf Obj Is Windows.Forms.Label Then
            Return Obj.Text
        ElseIf TypeOf Obj Is Windows.Forms.CheckBox Or TypeOf Obj Is Windows.Forms.RadioButton Then
            Return Obj.Checked
        ElseIf TypeOf Obj Is Windows.Forms.NumericUpDown Or TypeOf Obj Is Windows.Forms.ProgressBar Then
            Return Obj.Value
        End If

        'Unknown control, so lets see if we can find the right value.
        Dim Value As String = "Could_Not_Find_Value"
        Try 'Try and get the value.
            Value = Obj.Value
        Catch
            Try 'Try and get checked.
                Value = Obj.Checked
            Catch
                Try 'Try and get the text.
                    Value = Obj.Text
                Catch
                    Try
                        Value = Obj.ToString
                    Catch
                        Throw New Exception("Could not get value from object:" & Obj.name)
                    End Try
                End Try
            End Try
        End Try
        Return Value
    End Function
#End Region


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
        For Each prop As SimpleD.Property In lstGroups.SelectedItem.Group.Properties
            lstProperties.Items.Add(prop.Name & "=" & prop.Value)
        Next
    End Sub
#End Region

    Private Sub chkSplitNewLine_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSplitNewLine.CheckedChanged
        chkSplitTabs.Enabled = chkSplitNewLine.Checked
    End Sub

    Private Sub txtFile_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFile.TextChanged, txtResave.TextChanged
        If chkAutoOpen.Checked Then
            btnOpen_Click(sender, e)
        End If
    End Sub

    Private Sub btnTimeTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimeTest.Click
        frmTime.Show()
    End Sub

    Private Sub chkFromString2_CheckedChanged(sender As System.Object, e As System.EventArgs)
        btnOpen_Click(sender, e)
    End Sub

    Private Sub chkResave_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkResave.CheckedChanged, chkAllowEqualsInValue.CheckedChanged, chkAllowSemicolon.CheckedChanged
        panResize.Visible = chkResave.Checked
        btnOpen_Click(sender, e)
    End Sub

    Private Sub frmTest_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        comBraceStyle.Items.AddRange([Enum].GetNames(GetType(SimpleD.Group.Style)))
        comBraceStyle.SelectedIndex = 0

        chkAllowEqualsInValue.Checked = SimpleD.AllowEqualsInValue
        chkAllowSemicolon.Checked = SimpleD.AllowSemicolonInValue

    End Sub

    Private Sub comBraceStyle_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles comBraceStyle.SelectedIndexChanged
        btnOpen_Click(sender, e)
    End Sub
End Class
