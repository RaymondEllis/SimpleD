#Region "License & Contact"
'License:
'   Copyright (c) 2011 Raymond Ellis
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
'   Email: RaymondEllis*live.com
'   Website: https://sites.google.com/site/raymondellis89/
#End Region

Option Explicit On
Option Strict On

Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

'Version    : 1.2
'Last update: 12-15-2012 6am

Namespace SimpleD
    Partial Public Class Group

        ''' <summary>
        ''' Does NOT clear groups/properties.
        ''' Note: It will continue loading even with errors.
        ''' Slower then FromString
        ''' </summary>
        ''' <param name="Data">The text stream to parse.</param>
        ''' <returns>Errors if any.</returns>
        ''' <remarks></remarks>
        Public Function FromStream(ByVal Data As IO.TextReader) As String
            Return FromStreamBase(True, Data, 1)
        End Function

        ''' <summary>
        ''' Does NOT clear groups/properties.
        ''' Note: It will continue loading even with errors.
        ''' Slower then FromString
        ''' </summary>
        ''' <param name="Data">The text stream to parse.</param>
        ''' <returns>Errors if any.</returns>
        ''' <remarks></remarks>
        Public Function FromStream(ByVal Data As IO.TextReader, ByVal CloseStream As Boolean) As String
            Return FromStreamBase(True, Data, 1)
            If CloseStream Then Data.Close()
        End Function

        Private Function FromStreamBase(ByVal IsFirst As Boolean, ByVal Data As IO.TextReader, ByRef Line As Integer) As String
            If Data Is Nothing Then Return "Data is empty!"

            'Names can not contain { } ; /*
            'Property names can only contain = if AllowEqualsInValue is set to true.
            'p=g{};


            Dim Results As String = "" 'Holds errors to be returned later.
            Dim State As Byte = 0 '0 = Nothing    1 = In property   2 = In comment

            Dim StartLine As Integer = Line 'The start of the group.
            Dim ErrorLine As Integer = 0 'Used for error handling.
            Dim tName As String = "" 'Group or property name
            Dim tValue As String = ""

            Dim cCode As Integer = 0
            Do Until cCode = -1
                cCode = Data.Read
                Dim chr As Char = ChrW(cCode)

                Select Case State
                    Case 0 'In nothing

                        Select Case chr
                            Case "="c
                                ErrorLine = Line
                                State = 1 'In property

                            Case ";"c
                                tName = tName.Trim
                                If tName = "" Then
                                    Results &= " #Found end of property but no name&value at line: " & Line & " Could need AllowSemicolonInValue enabled."
                                Else
                                    Properties.Add(New [Property](tName, ""))
                                End If
                                tName = ""
                                tValue = ""

                            Case "{"c 'New group
                                Dim newGroup As New Group(tName.Trim)
                                Results &= newGroup.FromStreamBase(False, Data, Line)
                                If AllowEmpty OrElse Not newGroup.IsEmpty Then Groups.Add(newGroup)
                                tName = ""

                            Case "}"c 'End current group
                                Return Results


                            Case "/"c '/* start of comment
                                If ChrW(Data.Peek) = "*"c Then
                                    Data.Read()
                                    State = 2 'In comment
                                    ErrorLine = Line
                                Else
                                    tName &= chr
                                End If

                            Case Else
                                tName &= chr
                        End Select


                    Case 1 'get property value
                        If chr = ";"c Then
                            If (AllowSemicolonInValue) AndAlso ChrW(Data.Peek) = ";"c Then
                                Data.Read()
                                tValue &= chr
                            Else
                                Dim newPorp As New [Property](tName.Trim, tValue)
                                If AllowEmpty OrElse Not newPorp.IsEmpty Then Properties.Add(newPorp)
                                tName = ""
                                tValue = ""
                                State = 0
                            End If


                        ElseIf chr = "="c Then 'error
                            If AllowEqualsInValue Then
                                tValue &= chr
                            Else
                                Results &= "  #Missing end of property " & tName.Trim & " at line: " & ErrorLine
                                ErrorLine = Line
                                tName = ""
                                tValue = ""
                            End If
                        Else
                            tValue &= chr
                        End If

                    Case 2 'In comment
                        If chr = "/"c AndAlso ChrW(Data.Peek) = "*"c Then
                            Data.Read()
                            State = 0
                        End If


                End Select

                If chr = vbLf Then Line += 1
            Loop

            If State = 1 Then
                tName = tName.Trim
                If AllowEmpty OrElse tName <> "" Then Properties.Add(New [Property](tName, tValue))
                Results &= " #Missing end of property " & tName & " at line: " & ErrorLine
            ElseIf State = 2 Then
                Results &= " #Missing end of comment " & tName.Trim & " at line: " & ErrorLine
            ElseIf Not IsFirst Then 'The base group does not need to be ended.
                Results &= "  #Missing end of group " & Name & " at line: " & StartLine
            End If

            Return Results
        End Function

    End Class

End Namespace