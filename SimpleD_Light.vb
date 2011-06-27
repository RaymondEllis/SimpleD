#Region "License & Contact"
'License:
'   Copyright (c) 2010 Raymond Ellis
'   
'   This software is provided 'as-is', without any express or implied
'   warranty. In no event will the authors be held liable for any damages
'   arising from the use of this software.
'
'   Permission is granted to anyone to use this software for any purpose,
'   including commercial applications, and to alter it and redistribute it
'   freely, subject to the following restrictions:
'
'       1. The origin of this software must not be misrepresented; you must not
'           claim that you wrote the original software. If you use this software
'           in a product, an acknowledgment in the product documentation would be
'           appreciated but is not required.
'
'       2. Altered source versions must be plainly marked as such, and must not be
'           misrepresented as being the original software.
'
'       3. This notice may not be removed or altered from any source
'           distribution.
'
'
'Contact:
'   Raymond Ellis
'   Email: RaymondEllis@live.com
'   Website: https://sites.google.com/site/raymondellis89/
#End Region

Option Explicit On
Option Strict On
Namespace SimpleD

    ''' <summary>LightGroups Missing formating and can not contain any comments.</summary>
    Public Class lGroup
        Public Name As String

        Public Properties As New List(Of lProp)
        Public Groups As New List(Of lGroup)

        Public Sub New(Optional ByVal Name As String = "")
            Me.Name = Name
        End Sub

        Public Overloads Function ToString() As String
            If Properties.Count = 0 And Groups.Count = 0 Then Return ""

            Dim tmp As String = ""

            'Name and start of group.
            If Name <> "" Then tmp = Name & "{"

            'Add the properies from the group.
            For n As Integer = 0 To Properties.Count - 1
                tmp &= Properties(n).Name & "=" & Properties(n).Value & ";"
            Next

            'Get all the groups in the group.
            For Each Grp As lGroup In Groups
                tmp &= Grp.ToString
            Next

            '} end of group.
            If Name <> "" Then tmp &= "}"
            Return tmp
        End Function

        Public Function FromString(Data As String, Optional ByRef Index As Integer = 0) As String
            If Index = 0 AndAlso Data.Contains("//") Then Return "LightGroup can not contain any comments."
            'Now lets get all of the properties from the group.
            Do
                Dim Equals As Integer = Data.IndexOf("=", Index) 'Search for the next property.
                Dim GroupStart As Integer = Data.IndexOf("{", Index) 'Search for the NEXT group.
                If Equals = -1 AndAlso GroupStart = -1 Then Return "" 'If there is no more groups and properties then we are at the end of file.
                Dim GroupEnd As Integer = Data.IndexOf("}", Index)
                If GroupEnd > -1 And GroupEnd < GroupStart And GroupEnd < Equals Then 'Are we at the end of this group?
                    Index = GroupEnd
                    Return ""
                End If
                'Is the next thing a group or property?
                If Equals > -1 And ((Equals < GroupStart) Or GroupStart = -1) Then
                    Dim PropName As String = Data.Substring(Index, Equals - Index).Trim
                    Index = Equals
                    Dim PropEnd As Integer = Data.IndexOf(";", Index)
                    If PropEnd = -1 Then Return "Could not find end of Prop:" & PropName
                    Dim PropValue As String = Data.Substring(Index + 1, PropEnd - Index - 1)
                    Index = PropEnd
                    Properties.Add(New lProp(PropName, PropValue))

                ElseIf GroupStart > -1 Then
                    Dim gName As String = Trim(Data.Substring(Index, GroupStart - Index).Trim)
                    Index = GroupStart + 1

                    Dim NewGroup As New lGroup(gName)
                    Groups.Add(NewGroup)
                    Dim result As String = NewGroup.FromString(Data, Index)
                    If result <> "" Then Return result
                End If

                Index += 1
                If Index >= Data.Length Then Return "" 'The end of the string is also the end of the group.
            Loop Until Data.Substring(Index, 1) = "}"
            Return ""
        End Function
    End Class

    ''' <summary>Missing =</summary>
    Public Class lProp
        Public Name As String
        Public Value As String
        Public Sub New(ByVal Name As String, ByVal Value As String)
            Me.Name = Name
            Me.Value = Value
        End Sub
    End Class
End Namespace