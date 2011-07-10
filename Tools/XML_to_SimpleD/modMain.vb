Module modMain
    Sub Main()
        If Environment.GetCommandLineArgs.Length = 2 Then
            Convert(Environment.GetCommandLineArgs(1), IO.Path.ChangeExtension(Environment.GetCommandLineArgs(1), ".sd"))
        ElseIf Environment.GetCommandLineArgs.Length = 3 Then
            Convert(Environment.GetCommandLineArgs(1), Environment.GetCommandLineArgs(2))
        Else
            MsgBox("Command line #1=XML file" & Environment.NewLine & "#2=Output file (Optional)")
        End If
        Console.WriteLine("Done")
    End Sub
    Public Sub Convert(ByVal xml As String, ByVal sdFile As String)
        Console.WriteLine("Converting")
        'Load the xml file.
        Dim x As New Xml.XmlDocument
        x.Load(xml)
        'Create SimpleD group and get all the child nodes.
        Dim sd As New SimpleD.Group
        For Each node As Xml.XmlNode In x.ChildNodes
            sd.Groups.Add(DoChildNode(node))
        Next
        sd.ToFile(sdFile, , SimpleD.Group.Style.GroupsOnNewLine) 'Save the SimpleD file.
    End Sub
    Private Function DoChildNode(node As Xml.XmlNode) As SimpleD.Group
        Dim g As New SimpleD.Group(node.Name)
        For Each child As Xml.XmlNode In node.ChildNodes
            g.Groups.Add(DoChildNode(child))
        Next
        For Each ad As Xml.XmlNode In node.Attributes
            g.Properties.Add(New SimpleD.Prop(ad.Name, ad.Value))
        Next
        Return g
    End Function
End Module
