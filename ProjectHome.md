SimpleD uses a c-like syntax to hold data in a file or string.

V1.1 has been released!

Example string:
```
Group
{
   Test property=This is the value;
   /*This is a comment*\
}
/*Can also be like this*\
Group{Test property=This is the value;/*This is a comment*\}
/*Also supports sub groups*\
Group{g1{g2{g3{g4{=null;}}}}}
```
Code to use string:
```
Save:
MainGroup = New SimpleD.Group
g = MainGroup.CreateGroup("Group")
g.SetValue("Test property","This is the value")
MainGroup.toFile("tmp.sd")

Load:
MainGroup = New SimpleD.Group()
MainGroup.fromFile("tmp.sd")
g = MainGroup.GetGroup("Group")
MsgBox(g.GetValue("Test property"))
```
(Note: Code is using the helper class.)

SimpleD is licensed under the zlib license:http://opensource.org/licenses/zlib-license.php