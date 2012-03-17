package simpleD;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;

public class GroupHelper extends Group {
	
	public String fromFile(String filename){
		try {
			BufferedReader in = new BufferedReader(new FileReader(filename));
			String data = "";
			String str;
			while ((str=in.readLine()) !=null){
				data+=str;
			}
			in.close();
			return this.fromString(data);
		} catch (IOException e) {
			return e.getMessage();
		}
	}
	
	public void toFile(String filename, Boolean AddVersion){
		try {
			BufferedWriter out = new BufferedWriter(new FileWriter(filename));
			out.write(this.toString(AddVersion));
			out.close();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
}
