Just a helper function to get/set a value to/from a Windows.Forms control.

Useage: `GetValue(TextBox1, group)`

The functions: (place them where ever.)
```
#Region "Get/Set value to/from control v1"
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
```

Was removed from SimpleD v1 because of reference to Windows.Forms