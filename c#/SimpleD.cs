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
using System.Text;
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
		 * 1.2 *InDev* 12-21-2012
		 * SimpleD.Info done!
		 * SimpleD.Proprety needs operators & XML comments.
		 * SimpleD.Group needs XML comments.
		 * Needs testing as well.
		 */
	}

	public class Group
	{
		public string Name;
		public List<Group> Groups = new List<Group>();
		public List<Property> Properties = new List<Property>();

		public Group() { }
		public Group(string name)
		{
			this.Name = name;
		}
		public Group(string name, Style braceStyle)
		{
			this.Name = name;
			this.BraceStyle = braceStyle;
		}

		#region Parse(FromString)

		public string FromString(string data)
		{
			int index=0;
			int line=1;
			StringBuilder Results=new StringBuilder();
			FromStringBase(true, data, ref index, ref line,ref Results);
			return Results.ToString();
		}

		private void FromStringBase(bool isFirst, string data, ref int index, ref int line, ref StringBuilder Results)
		{
			if (data == "")
			{
				Results.Append("Data is empty!");
				return;
			}

			byte State = 0; //0 = Get name    1 = In property   2 = Finish comment

			int StartLine = line;
			int ErrorLine = 0;
			StringBuilder sbName = new StringBuilder();
			StringBuilder sbValue = null;

			while (index < data.Length)
			{
				Char chr = data[index];

				switch (State)
				{
					case 0://Get name

						switch (chr)
						{
							case '=':
								sbValue = new StringBuilder();
								ErrorLine = line;
								State = 1; //Get property value
								break;

							case ';':
								String tName = sbName.ToString().Trim();
								if (tName == "")
								{
									Results.Append(" #Found end of property but no name at line: " + line + " Could need AllowSemicolonInValue enabled.");
								}
								else
								{
									Properties.Add(new Property(tName, ""));
								}
								sbName = new StringBuilder();
								break;

							case '{': //New group
								++index;
								Group newGroup = new Group(sbName.ToString().Trim());
								newGroup.FromStringBase(false, data, ref index, ref line, ref Results);
								if (Info.AllowEmpty || !newGroup.IsEmpty()) Groups.Add(newGroup);
								sbName = new StringBuilder();
								break;

							case '}': //End current group
								return;

							case '/': //Start of comment
								if (index + 1 < data.Length && data[index + 1] == '*')
								{
									State = 2;
									ErrorLine = line;
									break;
								}
								sbName.Append(chr); //Don't start comment.
								break;

							default:
								sbName.Append(chr);
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
								Property newProp = new Property(sbName.ToString().Trim(), sbValue.ToString());
								if (Info.AllowEmpty || !newProp.IsEmpty()) Properties.Add(newProp);
								sbName = new StringBuilder();
								sbValue = null;
								State = 0;
								break;
							}
						}
						else if (chr == '=' && !Info.AllowEqualsInValue) //Should there be = in value?
						{
							Results.Append("  #Missing end of property " + sbName.ToString().Trim() + " at line: " + ErrorLine);
							ErrorLine = line;
							sbName = new StringBuilder();
							sbValue = null;
							break;
						}

						sbValue.Append(chr);
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
				String tName = sbName.ToString().Trim();
				if (Info.AllowEmpty || tName != "") Properties.Add(new Property(tName, sbValue.ToString()));
				Results.Append(" #Missing end of property " + tName + " at line: " + ErrorLine);
			}
			else if (State == 2)
			{
				Results.Append(" #Missing end of comment " + sbName.ToString().Trim() + " at line: " + ErrorLine);
			}
			else if (!isFirst) //The base group does not need to be ended.
			{
				Results.Append("  #Missing end of group " + Name + " at line: " + ErrorLine);
			}

		}

		public static Group Parse(string data)
		{
			Group g = new Group();
			g.FromString(data);
			return g;
		}
		#endregion

		#region ToString and Styling

		public enum Style
		{
			None = 0,
			NoStyle = 1,
			Whitesmiths = 2,
			GNU = 3,
			BSD_Allman = 4,
			K_R = 5,
			GroupsOnNewLine = 6
		}
		public Style BraceStyle = Style.None;
		public Char Tab = Convert.ToChar("\t");

		public override string ToString()
		{
			bool SaveName = true;
			if (Name == null || Name.Length == 0) SaveName = false;
			StringBuilder Output = new StringBuilder();
			ToStringBase(SaveName, -1, false, BraceStyle, ref Output);
			return Output.ToString();
		}

		public StringBuilder ToStringBuilder()
		{
			bool SaveName = true;
			if (Name == null || Name.Length == 0) SaveName = false;
			StringBuilder Output = new StringBuilder();
			ToStringBase(SaveName, -1, false, BraceStyle, ref Output);
			return Output;
		}

		private void ToStringBase(bool saveName, int tabCount, bool addVersion, Style braceStyle, ref StringBuilder output)
		{
			if (!Info.AllowEmpty && IsEmpty()) return;
			if (tabCount < -1) tabCount = -2;

			if (this.BraceStyle != Style.None) braceStyle = this.BraceStyle;
			if (braceStyle == Style.None) braceStyle = Style.BSD_Allman;

			if (addVersion) output.Append("SimpleD{Version=" + Info.Version + ";FormatVersion=" + Info.FileVersion + ";}");

			//Name and start of group. GroupName{
			if (saveName)
			{
				switch (braceStyle)
				{
					case Style.NoStyle:
					case Style.K_R:
						output.Append(Name);
						output.Append('{');
						break;
					case Style.Whitesmiths:
						output.Append(Name);
						output.AppendLine();
						if (tabCount > -1) output.Append(Tab, tabCount + 1);
						output.Append('{');
						break;
					case Style.BSD_Allman:
						output.Append(Name);
						output.AppendLine();
						if (tabCount > 0) output.Append(Tab, tabCount);
						output.Append('{');
						break;
					case Style.GNU:
						output.Append(Name);
						output.AppendLine();
						if (tabCount > 0) output.Append(Tab, tabCount);
						output.Append("  {");
						break;
					case Style.GroupsOnNewLine:
						output.AppendLine();
						if (tabCount > 1) output.Append(Tab, tabCount - 1);
						output.Append(Name);
						output.Append('{');
						break;
				}
			}

			//Groups and properties
			switch (braceStyle)
			{
				case Style.NoStyle:
				case Style.GroupsOnNewLine:
					for (int i = 0; i < Properties.Count; ++i)
					{
						output.Append(Properties[i].ToString());
					}
					for (int i = 0; i < Groups.Count; ++i)
					{
						Groups[i].ToStringBase(true, tabCount + 1, false, braceStyle, ref output);
					}
					break;
				case Style.Whitesmiths:
				case Style.BSD_Allman:
				case Style.K_R:
				case Style.GNU:
					for (int i = 0; i < Properties.Count; ++i)
					{
						output.AppendLine();
						if (tabCount > -1) output.Append(Tab, tabCount + 1);
						output.Append(Properties[i].ToString());
					}
					for (int i = 0; i < Groups.Count; ++i)
					{
						output.AppendLine();
						if (tabCount > -1) output.Append(Tab, tabCount + 1);
						Groups[i].ToStringBase(true, tabCount + 1, false, braceStyle, ref output);
					}
					break;
			}

			//End of group }
			if (saveName)
			{
				switch (braceStyle)
				{
					case Style.NoStyle:
					case Style.GroupsOnNewLine:
						output.Append('}');
						break;
					case Style.Whitesmiths:
						output.Append('}');
						if (tabCount > -1) output.Append(Tab, tabCount + 1);
						output.Append('}');
						break;
					case Style.BSD_Allman:
					case Style.K_R:
						output.AppendLine();
						if (tabCount > 0) output.Append(Tab, tabCount);
						output.Append('}');
						break;
					case Style.GNU:
						output.AppendLine();
						if (tabCount > 0) output.Append(Tab, tabCount);
						output.Append("  }");
						break;

				}
			}
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
			if (Value == null || Value.Length==0)
			{
				if (Name == null || Name.Length==0)
				{
					if (Info.AllowEmpty) return "=;";
					return "";
				}
				else
				{
					return Name + ";";
				}
			}

			if (Info.AlllowSemicolonInValue)
			{
				return Name + "=" + Value.Replace(";", ";;") + ";";
			}

			return Name + "=" + Value + ";";
		}

		public bool IsEmpty()
		{
			//Name andalso value is null or empty.
			return (Name == null || Name.Length==0) && (Value == null || Value.Length==0);
		}
	}
}