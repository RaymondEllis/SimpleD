Module modMain
    Sub Main()
        If Environment.GetCommandLineArgs.Length = 2 Then
            Convert(Environment.GetCommandLineArgs(1), IO.Path.ChangeExtension(Environment.GetCommandLineArgs(1), ".sd"))
        ElseIf Environment.GetCommandLineArgs.Length = 3 Then
            Convert(Environment.GetCommandLineArgs(1), Environment.GetCommandLineArgs(2))
        Else
            Console.WriteLine("Command line:" & Environment.NewLine & _
                              "#1 = XML file" & Environment.NewLine & _
                              "#2 = Output file (Optional)")
            Console.ReadKey()
        End If
    End Sub
    Public Sub Convert(ByVal xml As String, ByVal sdFile As String)
        If IO.File.Exists(xml) = False Then
            Console.WriteLine("XML file does Not exist!")
            Console.ReadKey()
            Return
        End If
        Console.WriteLine("Converting...")
        'Load the xml file.
        Dim x As New Xml.XmlDocument
        x.Load(xml)
        'Create SimpleD group and get all the child nodes.
        Dim sd As New SimpleD.Group
        For Each node As Xml.XmlNode In x.ChildNodes
            sd.Groups.Add(DoChildNode(node))
        Next
        Console.Write(" Done.")
        'Save the SimpleD file.
        If sdFile.Contains("\") Or sdFile.Contains("/") Then
            IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(sdFile))
        End If
        Dim sw As New IO.StreamWriter(sdFile)
        sw.Write(sd.ToString(, SimpleD.Group.Style.GroupsOnNewLine))
        sw.Close()
        Console.WriteLine("File saved to: " & Environment.NewLine & sdFile)
    End Sub
    Private Function DoChildNode(node As Xml.XmlNode) As SimpleD.Group
        If node Is Nothing Then Return Nothing
        Dim g As New SimpleD.Group(node.Name)
        If node.ChildNodes.Count = 0 And node.Attributes Is Nothing Then
            g.BraceStyle = SimpleD.Group.Style.None
            Return g
        End If
        For Each child As Xml.XmlNode In node.ChildNodes
            Dim tmp As SimpleD.Group = DoChildNode(child)
            If tmp.BraceStyle = SimpleD.Group.Style.None Then
                g.Properties.Add(New SimpleD.Property("", child.InnerText))
            Else
                g.Groups.Add(tmp)
            End If
        Next
        If node.Attributes IsNot Nothing Then
            For Each ad As Xml.XmlNode In node.Attributes
                g.Properties.Add(New SimpleD.Property(ad.Name, ad.Value))
            Next
        End If
        Return g
    End Function
End Module
