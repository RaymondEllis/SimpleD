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
	/// <summary>Some info and settigs for SimpleD.</summary>
	public static class Info
	{
		/// <summary>The version of SimpleD.</summary>
		public const Single Version = 1.2f;
		/// <summary>The supported SimpleD file format version.</summary>
		public const Single FileVersion = 3f;

		/// <summary>Allow equals in property vales? faster if set to false.</summary>
		public static bool AllowEqualsInValue = true;
		/// <summary>Allow semicolons in property vales? faster if set to false.</summary>
		public static bool AlllowSemicolonInValue = true;
		/// <summary>Allow empty groups/peroperties, for both FromString() and ToString()</summary>
		public static bool AllowEmpty = false;

		/* Last update:
		 * 
		 * 1.2 *InDev* 2014-05-07
		 * Needs testing.
		 */
	}

	/// <summary>
	///  A group of groups and properties.
	/// </summary>
	public class Group
	{
		/// <summary>Name of the group, can be empty.</summary>
		public string Name;
		/// <summary>A list of sub groups.</summary>
		public List<Group> Groups = new List<Group>();
		/// <summary>A list of properties.</summary>
		public List<Property> Properties = new List<Property>();

		/// <summary></summary>
		public Group() { }
		/// <summary></summary>
		///<param name="name"></param>
		public Group(string name)
		{
			this.Name = name;
		}
		/// <summary></summary>
		/// <param name="name"></param>
		/// <param name="braceStyle"></param>
		public Group(string name, Style braceStyle)
		{
			this.Name = name;
			this.BraceStyle = braceStyle;
		}

		#region Parse(FromString)

		/// <summary>Appends groups/properties from a string.</summary>
		/// <param name="data"></param>
		/// <returns>Returns a empty string if there is no errors.</returns>
		public string FromString(string data)
		{
			int index = 0;
			int line = 1;
			StringBuilder Results = new StringBuilder();
			fromStringBase(true, data, ref index, ref line, ref Results);
			return Results.ToString();
		}

		private void fromStringBase(bool isFirst, string data, ref int index, ref int line, ref StringBuilder Results)
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
								newGroup.fromStringBase(false, data, ref index, ref line, ref Results);
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

		/// <summary>Creats new group and calls FromString(). Note: There is no way to check for errors.</summary>
		/// <param name="data"></param>
		/// <returns></returns>
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
			/// <summary>Style not set, use parent or default styling.</summary>
			None = 0,
			/// <summary>Everything on one line. (no styling)</summary>
			NoStyle = 1,
			/// <summary>Whitesmiths 
			/// http://en.wikipedia.org/wiki/Indent_style#Whitesmiths_style </summary>
			Whitesmiths = 2,
			/// <summary>GNU, May need to set Tab to a space?
			/// http://en.wikipedia.org/wiki/Indent_style#GNU_style </summary>
			GNU = 3,
			/// <summary>Allman (used in BSD Unix)
			/// http://en.wikipedia.org/wiki/Indent_style#Allman_style </summary>
			BSD_Allman = 4,
			/// <summary>Kernighan and Ritchie http://en.wikipedia.org/wiki/Indent_style#K.26R_style </summary>
			K_R = 5,
			/// <summary>Simply puts groups on a new line. (with Tab)</summary>
			GroupsOnNewLine = 6
		}
		/// <summary>Style to use when calling ToString()</summary>
		public Style BraceStyle = Style.None;
		/// <summary>What to use as a tab, when calling ToString()</summary>
		public Char Tab = Convert.ToChar("\t");

		/// <summary>Converts all data in this group to a string,
		/// simply calls ToStringBuilder.Tostring()</summary>
		/// <returns></returns>
		public override string ToString()
		{
			return ToStringBuilder().ToString();
		}

		/// <summary>Converts all data in this group to a string.</summary>
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

		/// <summary>Returns true when there is no groups no properties and the name is empty.</summary>
		/// <returns></returns>
		public bool IsEmpty()
		{
			return Groups.Count == 0 && Properties.Count == 0 && Name == "";
		}
	}

	/// <summary>
	/// Used to store values.
	/// </summary>
	public class Property
	{
		/// <summary>Name of property, can not contain ";" or "="</summary>
		public string Name;
		/// <summary>Value of property.</summary>
		public string Value;

		/// <summary></summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		public Property(string name, string value)
		{
			this.Name = name;
			this.Value = value;
		}

		/// <summary>
		/// Returns "Name=Value;"
		/// Or if there is no value "Name;"
		/// </summary>
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

		/// <summary>Name and Value are equal</summary>
		/// <param name="left"></param>
		/// <param name="right"></param>
		/// <returns></returns>
		public static bool operator ==(Property left, Property right)
		{
			if ((object)left == null && (object)right == null) return true;
			if ((object)left == null || (object)right == null) return false;
			return left.Name == right.Name && left.Value == right.Value;
		}
		/// <summary>Name Or Value are not equal</summary>
		/// <param name="left"></param>
		/// <param name="right"></param>
		/// <returns></returns>
		public static bool operator !=(Property left, Property right)
		{
			return !(left == right);
		}

		/// <summary></summary>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			if (obj == null || !(obj is Property)) return false;
			return this == (Property)obj;
		}
		/// <summary></summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return Name.GetHashCode() ^ Value.GetHashCode();
		}

		/// <summary>Returns true when name AND value is empty.</summary>
		/// <returns></returns>
		public bool IsEmpty()
		{
			//Name andalso value is null or empty.
			return (Name == null || Name.Length == 0) && (Value == null || Value.Length == 0);
		}
	}
}