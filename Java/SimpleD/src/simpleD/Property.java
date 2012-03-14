package simpleD;

public class Property {
	
	public String name;
	public String value;
	
	public Property(String Name, String Value){
		name=Name;
		value=Value;
	}
	
	@Override
	public String toString(){
		if(Info.AllowSemicolonInValue){
			String tmpValue=value.replace(";", ";;");
			if(tmpValue.isEmpty()) return name+";";
			return name +"="+ tmpValue +";";
		} else {
			if(value.isEmpty()) return name+";";
			return name +"="+ value +";";
		}
	}
	
}
