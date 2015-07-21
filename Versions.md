
```
'1.1    3-21-2012 *Stable*
'Added  : Can now make a empty property by just using a semicolon. p; is now the same as p=;
'Change : AllowEqualsInValue is now in Info.
'Change : } can now end the base group. so "p=v;}p2=2;" would only parse as "p=v;" because } ended the base group.
'Change : Comments are now /*comment*/ (was //comment\\)
'Change : The brace styles are now a bit simpiler.   Uses last groups style if none is specified. falls back to BSD_Allman if base group is none.
'Change : There is now NoStyle
'Fixed  : Did not specify that parse is the same as fromstring.
'Fixed  : Empty groups now save. Fixes Issue#2 "g{p=;g2{" better.

'1      7-18-2011 *Stable*
'New    : ToString now has brace styling.
'New    : FromString(Now Parse) is now faster. (Have seen 14x better speed. Bigger strings will have a bigger difference.)
'New    : Can now have properties with out any groups in a string.
'New    : Checks for empty data in "Group.FromString".
'New    : Can now set what you want to use as a tab.
'Renamed: Prop to Property
'Removed: Windows.Forms and everything that used it.
'Change : Now saves the version of SimpleD as a group on the top of the file. (was saved as a comment before.)
'Change : Removed "SimpleD.SimpleD" now just use "SimpleD.Group".
'Change : The helper functions are now in a seperate file. (Can be put in same file if desired.)
'Fixed  : Property is now a class. Fixed a few bugs because structures are not reference type.
'Fixed  : GetValue(ByRef Control, ByRef Value) Nolonger crashes if value did not convert properly. (Can be found at: https://code.google.com/p/simpled/wiki/control_helper)
'Fixed  : ToFile now creates dir if it does not exist.

'0.991  5-8-2011 *Stable*
'Added  : Error handling to FromString\FromFile
'Added  : Properties and Groups can now have duplcate names.
'Added  : AddValue AND FindArray AND GetValueArray AND GetGroupArray
'Change : Groups and properties are now public.
'Change : Clarified that the version on the top of the string is the SimpleD version.
'Rename : Propretys to Properties
'Rename : Set_Value to SetValue AND Get_Value to GetValue
'Rename : Get_Group to GetGroup AND Add_Group to AddGroup AND Create_Group to CreateGroup
'Cleaned: This version log.
'Fixed  : Issue#2 g{p=;g2{ would lockup.
'Fixed  : Can now compile using dot net 2+  (could only compile on 4.0 before)
'Fixed  : Was trimming the value.
'Fixed  : GetValue Would try and set a value it could not set.

'0.99   1-10-2011 *Stable*
'Added  : Can now have groups inside of groups.
'Added  : GetValue(Control,Value)  Gets the property from the control name. Then sets the contols value, if the control is known.
'Changed: Spliting is now done with a few options not a string.
'Fixed  : SetValue(Control) now check throgh known controls for the right value.

'0.986  12-27-2010
'Added: default value to Set_Value.
'Changed: Control to Windows.Forms.Control

'0.985  11-5-2010 *Stable*
'Added  : FileVersion So I can easley tell if the file has changed.
'Added  : IllegalCharacters property names and values can NOT have any of the characters in IllegalCharacters.
'Fixed  : Only allows one group with the same names. will combine groups if names match.
'Changed: Prop from a class to a structure.
'Changed: Everything returns empty if not found.
'Changed: Does not add if a value or name is empty.
'Changed: Get_Group returns Nothing if no group found.
'Removed: Group.Add because set_value will create if not found.

'0.983  9-30-2010
'Fixed: Spelling.

'0.982  9-25-2010
'Added: Add_Group

'0.981  9-23-2010~
'Changed: Get_Value(Name, Value) No longer throws a error if no value found.
'Clean up.
'Added: Linense and contact.

'0.98   9-7-2010
'Fixed: Spelling
'Added: New get value with byref value

'0.97   1-1-2010 *Stable*
'Added: ToFile
'Added: Check exists in FromFile

'0.96   7-28-2009
'Added: FromFile

'0.952  1-22-2009
'0.95   1-22-2009
```