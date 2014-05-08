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
	/// <summary>System wide settings/info</summary>
	public static class Info
	{
		/// <summary>The current version of SimpleD</summary>
		public const Single Version = 1.2f;
		/// <summary>The current file version, if this changes your files may not load properly.</summary>
		public const Single FileVersion = 3f;

		/// <summary>Allow "=" in the values? fv3 just doesn't report it as an error...</summary>
		public static bool AllowEqualsInValue = true;
		/// <summary>Allow ";" in values? fv3 replaces them with ";;"</summary>
		public static bool AlllowSemicolonInValue = true;
		/// <summary>if True, than ToString() will return empty groups and properties.
		/// ex: "{}=;" (empty group with an empty property.)</summary>
		public static bool AllowEmpty = false;

		/* Last update:
		 * 
		 * 1.2 *InDev* 2014-02-14
		 * SimpleD.Info done!
		 * SimpleD.Proprety needs operators.
		 * Needs testing as well.
		 */
	}

	/// <summary>Container to place other groups and properties.
	/// "Name{}"</summary>
	public class Group
	{
		/// <summary>Name of the group. Goes befure "{".</summary>
		public string Name;
		/// <summary>It's a list of groups</summary>
		public List<Group> Groups = new List<Group>();
		/// <summary>And this is a list of properties</summary>
		public List<Property> Properties = new List<Property>();

		/// <summary>Creates an empty group</summary>
		public Group() { }
		/// <summary>Creats an group with a name</summary>
		/// <param name="name"></param>
		public Group(string name)
		{
			this.Name = name;
		}
		/// <summary>Creats an group with a name and a custom style</summary>
		/// <param name="name"></param>
		/// <param name="braceStyle"></param>
		public Group(string name, Style braceStyle)
		{
			this.Name = name;
			this.BraceStyle = braceStyle;
		}

		#region Parse(FromString)
		/// <summary>Parses a string into this group.</summary>
		/// <param name="data">string to parse</param>
		/// <returns>Returns a string of warnings/errors, or an empty string if no warnings/errors</returns>
		public string FromString(string data)
		{
			int index = 0;
			int line = 1;
			StringBuilder Results = new StringBuilder();
			FromStringBase(true, data, ref index, ref line, ref Results);
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

		/// <summary>Parses a string into this group.</summary>
		/// <param name="data">string to parse</param>
		/// <returns>Does not do anything with errors/warnings!</returns>
		public static Group Parse(string data)
		{
			Group g = new Group();
			g.FromString(data);
			return g;
		}
		#endregion

		#region ToString and Styling
		/// <summary>Style to use when calling ToString()</summary>
		public enum Style
		{
			/// <summary>No style has been set, use parent style.</summary>
			None = 0,
			/// <summary>Don't use any styling, will be one long string.</summary>
			NoStyle = 1,
			/// <summary>See http://en.wikipedia.org/wiki/Indent_style#Whitesmiths_style </summary>
			Whitesmiths = 2,
			/// <summary>See http://en.wikipedia.org/wiki/Indent_style#GNU_style </summary>
			GNU = 3,
			/// <summary>See  </summary>
			BSD_Allman = 4,
			/// <summary>K and R See http://en.wikipedia.org/wiki/Indent_style#K.26R_style </summary>
			K_R = 5,
			/// <summary>Simply places new groups on a new line.</summary>
			GroupsOnNewLine = 6
		}
		/// <summary>It's a little more than the brace style</summary>
		public Style BraceStyle = Style.None;
		/// <summary>What do you want to use as a tab?</summary>
		public Char Tab = Convert.ToChar("\t");

		/// <summary>Converts all groups and properties to a string</summary>
		public override string ToString()
		{
			bool SaveName = true;
			if (Name == null || Name.Length == 0) SaveName = false;
			StringBuilder Output = new StringBuilder();
			ToStringBase(SaveName, -1, false, BraceStyle, ref Output);
			return Output.ToString();
		}

		/// <summary>Converts all groups and properties to a StringBuilder</summary>
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
						if (Properties[i] == null) continue;
						output.Append(Properties[i].ToString());
					}
					for (int i = 0; i < Groups.Count; ++i)
					{
						if (Groups[i] == null) continue;
						Groups[i].ToStringBase(true, tabCount + 1, false, braceStyle, ref output);
					}
					break;
				case Style.Whitesmiths:
				case Style.BSD_Allman:
				case Style.K_R:
				case Style.GNU:
					for (int i = 0; i < Properties.Count; ++i)
					{
						if (Properties[i] == null) continue;
						output.AppendLine();
						if (tabCount > -1) output.Append(Tab, tabCount + 1);
						output.Append(Properties[i].ToString());
					}
					for (int i = 0; i < Groups.Count; ++i)
					{
						if (Groups[i] == null) continue;
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

		/// <summary>Is the group empty?
		/// Groups.Count==0 andalso Properties.Count==0 andalso Name==""</summary>
		public bool IsEmpty()
		{
			return Groups.Count == 0 && Properties.Count == 0 && Name == "";
		}
	}

	/// <summary>A property. "name=value;"</summary>
	public class Property
	{
		/// <summary>Name of the property.
		/// can be empty even if AllowEmpty is false, as long as value has a value.</summary>
		public string Name;
		/// <summary>The value of the property.
		/// can be empty even if AllowEmpty is false, as long as name is not empty.</summary>
		public string Value;

		/// <summary>
		/// Basic constructor.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		public Property(string name, string value)
		{
			this.Name = name;
			this.Value = value;
		}

		/// <summary>"Name=Value;", if just value is empty "Name;", if just Name is empty "=Value;".</summary>
		/// <returns></returns>
		public override string ToString()
		{
			if (Value == null || Value.Length == 0)
			{
				if (Name == null || Name.Length == 0)
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

		/// <summary>Is the property empty?
		/// Both name and value must be empty.</summary>
		public bool IsEmpty()
		{
			//Name andalso value is null or empty.
			return (Name == null || Name.Length == 0) && (Value == null || Value.Length == 0);
		}
	}
}