#region License & Contact
/*
License:
   Copyright (c) 2011 Raymond Ellis

   This software is provided 'as-is', without any express or implied
   warranty. In no event will the authors be held liable for any damages
   arising from the use of this software.

   Permission is granted to anyone to use this software for any purpose,
   including commercial applications, and to alter it and redistribute it
   freely, subject to the following restrictions:

       1. The origin of this software must not be misrepresented; you must not
           claim that you wrote the original software. If you use this software
           in a product, an acknowledgment in the product documentation would be
           appreciated but is not required.

       2. Altered source versions must be plainly marked as such, and must not be
           misrepresented as being the original software.

       3. This notice may not be removed or altered from any source
           distribution.


Contact:
   Raymond Ellis
   Email: RaymondEllis*live.com
   Website: https://sites.google.com/site/raymondellis89/
*/
#endregion

using System;
using System.Collections;
using System.Collections.Generic;

namespace SimpleD
{
	public static class Info
	{
		public const Single Version = 1.2f;
		public const Single FileVersion = 3f;

		public static bool AllowEqualsInValue = true;
		public static bool AlllowSemicolonInValue = true;
		public static bool AllowEmpty = false;

		/* Last update:
		 * 
		 * 1.2 *InDev* 12-19-2012 NOT COMPLEATE!
		 * SimpleD.Info functionality done!
		 * SimpleD.Proprety needs operators & XML comments.
		 */
	}

	public class Group
	{
		public string Name;
		public List<Group> Groups = new List<Group>();
		public List<Property> Properties = new List<Property>();

		public Group() { }
		public Group(string name)//ToDo: Needs style
		{
			this.Name = name;
		}

		#region Parse(FromString)

		public string FromString(string data)
		{
			int index=0;
			int line=1;
			return FromStringBase(true, data, ref index, ref line);
		}

		private string FromStringBase(bool isFirst, string data, ref int index, ref int line)
		{
			if (data == "") return "Data is empty!";

			string Results="";
			byte State = 0; //0 = Get name    1 = In property   2 = Finish comment

			int StartLine = line;
			int ErrorLine = 0;
			string tName = "";
			string tValue = "";

			while (index < data.Length)
			{
				Char chr = data[index];

				switch (State)
				{
					case 0://Get bane

						switch (chr)
						{
							case '=':
								ErrorLine = line;
								State = 1; //Property
								break;

							case ';':
								tName = tName.Trim();
								if (tName == "")
								{
									Results += " #Found end of property but no name at line: " + line + " Could need AllowSemicolonInValue enabled.";
								}
								else
								{
									Properties.Add(new Property(tName, ""));
								}
								tName = "";
								tValue = ""; //Should not have to set to nothing.
								break;

							case '{': //New group
								++index;
								Group newGroup = new Group(tName.Trim());
								Results += newGroup.FromStringBase(false, data, ref index, ref line);
								if (Info.AllowEmpty || !newGroup.IsEmpty()) Groups.Add(newGroup);
								tName = "";
								break;

							case '}': //End current group
								return Results;

							case '/': //Start of comment
								if (index + 1 < data.Length && data[index + 1] == '*')
								{
									State = 2;
									ErrorLine = line;
								}
								else
								{
									tName += chr;
								}
								break;

							default:
								tName += chr;
								break;
						}
						break;

					case 1: //Get propergy value
						if (chr == ';')
						{
							if (Info.AlllowSemicolonInValue && index + 1 < data.Length && data[index + 1] == ';')
							{
								++index;
							}
							else
							{
								Property newProp = new Property(tName.Trim(), tValue);
								if (Info.AllowEmpty || !newProp.IsEmpty()) Properties.Add(newProp);
								tName = "";
								tValue = "";
								State = 0;
								break;
							}
						}
						else if (chr == '=' && !Info.AllowEqualsInValue) //Should there be = in value?
						{
							Results += "  #Missing end of property " + tName.Trim() + " at line: " + ErrorLine;
							ErrorLine = line;
							tName = "";
							tValue = "";
							break;
						}

						tValue += chr;
						break;

					case 2: //Finsh comment
						if (chr == '/' && data[index - 1] == '*')
						{
							State = 0;
						}
						break;
				}

				if (chr == "\n"[0]) ++line;
				++index;
			}

			if (State == 1)
			{
				tName = tName.Trim();
				if (Info.AllowEmpty || tName != "") Properties.Add(new Property(tName, tValue));
				Results += " #Missing end of property " + tName + " at line: " + ErrorLine;
			}
			else if (State == 2)
			{
				Results += " #Missing end of comment " + tName.Trim() + " at line: " + ErrorLine;
			}
			else if (!isFirst) //The base group does not need to be ended.
			{
				Results += "  #Missing end of group " + Name + " at line: " + ErrorLine;
			}


			return Results;
		}

		#endregion

		public bool IsEmpty()
		{
			return Groups.Count == 0 && Properties.Count == 0 && Name == "";
		}
	}

	public class Property
	{
		public string Name;
		public string Value;


		public Property(string name, string value)
		{
			this.Name = name;
			this.Value = value;
		}

		public override string ToString()
		{
			if (Value == "")
			{
				if (Name == "")
				{
					if (!Info.AllowEmpty) return "";
					return "=;";
				}
				else
				{
					return Name + ";";
				}
			}

			if (Info.AlllowSemicolonInValue)
			{
				string tmpValue = Value.Replace(";", ";;");
				return Name + "=" + tmpValue + ";";
			}

			return Name + "=" + Value + ";";
		}

		public bool IsEmpty()
		{
			return Name == "" && Value == "";
		}
	}
}