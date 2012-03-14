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
	
	//###################### ToString ######################
	@Override
	public String toString(){
		return toString(false);
	}
	public String toString(Boolean AddVersion){
		return toString(true, -1, AddVersion, BraceStyle);
	}
	String toString(Boolean isFirst, int tabCount, Boolean AddVersion, Style braceStyle){
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
					tmp += Properties.get(i).toString();
				}
				for(int i=0; i<Groups.size(); i++){
					tmp+=Groups.get(i).toString(false, tabCount+1, false, braceStyle);
				}
				break;
			case Whitesmiths: case BSD_Allman: case K_R: case GNU:
				for(int i=0; i<Properties.size(); i++){
					tmp +="\n"+getTabs(tabCount+1)+ Properties.get(i).toString();
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
	
	
	//###################### FromString ######################
	public String fromString(String data){
		return fromString(true, data, 0).error;
	}
	private parseReturn fromString(boolean isFirst, String data, int index){
		if(data.isEmpty()) return new parseReturn("Data is empty!",0);
		
		
		String results="";
		Byte state=0; //0=nothing 1= in property 2=in comment
		
		int startIndex=index;
		int errorIndex=0;
		String tmpName="";
		String tmpValue="";
		
		while (index<data.length()){
			char chr=data.charAt(index);
			
			switch(state){
				case 0: //in nothing.
					switch(chr){
						case '=':
							errorIndex=index;
							state=1;
							break;
						case ';':
							if(tmpName.trim().isEmpty()){
								results +="#Found end of property but no name&value at index: " + index + "Could need AllowSemicolonInValue enabled.";
							} else {
								Properties.add(new Property(tmpName.trim(),""));
							}
							tmpName="";
							tmpValue="";
							break;
						case '{':
							index++;
							Group newGroup = new Group(tmpName.trim());
							parseReturn pr = newGroup.fromString(false ,data, index);
							index=pr.index;
							results+=pr.error;
							Groups.add(newGroup);
							tmpName="";
							break;
						case '}':
							return new parseReturn(results,index);
						
						case '*':
							if(index-1>=0 && data.charAt(index-1)=='/'){
								tmpName="";
								state=2;
								errorIndex=index;
							} else {
								tmpName+= chr;
							}
							break;
						default :
							tmpName+=chr;
							break;
					}
					break;
					
				case 1://In property
					if(chr==';'){
						if((Info.AllowSemicolonInValue & index+1 <data.length()) && data.charAt(index+1) == 'c'){
							index ++;
							tmpValue +=chr;
						} else {
							Properties.add(new Property(tmpName.trim(), tmpValue));
							tmpName="";
							tmpValue="";
							state=0;
						}
						
					} else if(chr=='='){
						if(Info.AllowEqualsInValue){
							tmpValue +=chr;
						} else {
							results+="  #Missing end of property " + tmpName.trim() + " at index: " + errorIndex;
							errorIndex=index;
							tmpName="";
							tmpValue="";
						}
					} else {
						tmpValue+=chr;
					}
					break;
				case 2://in comment.
					if(data.charAt(index-1)=='*' && chr=='/'){
						state=0;
					}
					break;
			}
			
			index++;
		}
		
		if(state==1){
			results += " #Missing end of property " + tmpName.trim() + " at index: " + errorIndex;
		} else if(state == 2){
			results += " #Missing end of comment " + tmpName.trim() + " at index: " + errorIndex;
		} else if(!isFirst){
			results += "  #Missing end of group " + name.trim() + " at index: " + startIndex;
		}
		
		return new parseReturn(results, index);
	}
	private class parseReturn{
		String error="";
		int index=0;
		public parseReturn(String Error, int Index){
			this.error=Error;
			this.index=Index;
		}
	}
}
