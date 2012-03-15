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
		if(value.isEmpty()) return name+";";
		if(Info.AllowSemicolonInValue){
			String tmpValue=value.replace(";", ";;");
			return name +"="+ tmpValue +";";
		} else {
			return name +"="+ value +";";
		}
	}
	
}
