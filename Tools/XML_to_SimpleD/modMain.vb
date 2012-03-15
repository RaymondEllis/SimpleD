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
        sd.BraceStyle = SimpleD.Group.Style.K_R
        sw.Write(sd.ToString())
        sw.Close()
        Console.WriteLine("File saved to: " & Environment.NewLine & sdFile)
    End Sub
    Private Function DoChildNode(node As Xml.XmlNode) As SimpleD.Group
        Dim g As New SimpleD.Group(node.Name)
        For Each child As Xml.XmlNode In node.ChildNodes
            If child.HasChildNodes Or child.Attributes IsNot Nothing Then
                g.Groups.Add(DoChildNode(child))
            Else
                g.BraceStyle = SimpleD.Group.Style.NoStyle
                g.Properties.Add(New SimpleD.Property(child.InnerText.Trim, ""))
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
