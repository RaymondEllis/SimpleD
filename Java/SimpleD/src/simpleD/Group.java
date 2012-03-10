package simpleD;

import java.util.ArrayList;

public class Group {
	public String Name;
	
	public ArrayList<Group> Groups;
	public ArrayList<Property> Properties;
	
	public Style BraceStyle = Style.BSD_Allman;
	public String Tab="\t";
	
	public Group(){}
	public Group(String name){
		Name=name;
	}
	
	public enum Style{
		None, NoStyle,
		Whitesmiths,
		GNU,
		BSD_Allman,
		K_R,
		GroupsOnNewLine
	}
	
	public String ToString(Boolean AddVersion){
		return ToString(true, -1, AddVersion);
	}
	String ToString(Boolean isFirst, int tabCount, Boolean AddVersion){
		
		
		return "";
	}
	
}
