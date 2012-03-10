package simpleD;

import java.util.ArrayList;
import java.util.List;


public class Group {
	public String name;
	
	public ArrayList<Group> Groups = new ArrayList<Group>();
	public List<Property> Properties = new ArrayList<Property>();
	
	public Style BraceStyle = Style.BSD_Allman;
	public String Tab="\t";
	
	public Group(){}
	public Group(String Name){
		name=Name;
	}
	
	public enum Style{
		None, NoStyle,
		Whitesmiths,
		GNU,
		BSD_Allman,
		K_R,
		GroupsOnNewLine
	}
	
	public String toString(Boolean AddVersion){
		return toString(true, -1, AddVersion, BraceStyle);
	}
	String toString(Boolean isFirst, int tabCount, Boolean AddVersion, Style braceStyle){
		if(Properties.isEmpty() & Groups.isEmpty())
			return "";
		
		if(tabCount <-1) tabCount=-2;
		
		//Brace styling
		if (this.BraceStyle==Style.None) braceStyle=this.BraceStyle;
		if(braceStyle==Style.None) braceStyle=Style.BSD_Allman;
		
		String tmp="";
		
		if(AddVersion) tmp="SimpleD{Version="+Info.Version+";FormatVersion="+Info.FileVersion+";}";
		
		//Name and start of group.  Name{
		if(!isFirst){
			switch (braceStyle){
				case NoStyle: case K_R:
					tmp += name + "{";
					break;
				case Whitesmiths:
					tmp += name + "\n" + getTabs(tabCount +1) +"{";
					break;
				case BSD_Allman:
					tmp += name+"\n"+getTabs(tabCount)+"{";
					break;
				case GNU:
					tmp += name+"\n"+getTabs(tabCount)+"  {";
					break;
				case GroupsOnNewLine:
					tmp += "\n"+getTabs(tabCount-1)+name+"{";
					break;
			}
		}
		
		//Groups and properties.
		switch(braceStyle){
			case NoStyle: case GroupsOnNewLine:
				for(int i=0; i<Properties.size(); i++){
					tmp += Properties.get(i).name+"="+Properties.get(i).value+";";
				}
				for(int i=0; i<Groups.size(); i++){
					tmp+=Groups.get(i).toString(false, tabCount+1, false, braceStyle);
				}
				break;
			case Whitesmiths: case BSD_Allman: case K_R: case GNU:
				for(int i=0; i<Properties.size(); i++){
					tmp +="\n"+getTabs(tabCount+1)+ Properties.get(i).name+"="+Properties.get(i).value+";";
				}
				for(int i=0; i<Groups.size(); i++){
					tmp+="\n"+getTabs(tabCount+1)+ Groups.get(i).toString(false, tabCount+1, false, braceStyle);
				}
				break;
		}
		
		//} end of group.
		if(!isFirst){
			switch(braceStyle){
				case NoStyle: case GroupsOnNewLine:
					tmp+="}";
					break;
				case Whitesmiths:
					tmp+="\n"+getTabs(tabCount+1)+"}";
					break;
				case BSD_Allman: case K_R:
					tmp+="\n"+getTabs(tabCount)+"}";
					break;
				case GNU:
					tmp+="\n"+getTabs(tabCount)+"  }";
					break;
			}
		}
		
		return tmp;
	}
	
	private String getTabs(int count){
		StringBuilder sb = new StringBuilder();
		for (int i =0; i<count; i++){
			sb.append(Tab);
		}
		return sb.toString();
	}
}
