package tset;

import simpleD.*;
import simpleD.Group.Style;

public class SDTest {
	public static void main(String[] args){
		//toTest();
		fromTest();
	}
	
	static void toTest(){
		Group g=new Group("Test");
		g.Properties.add(new Property("prop","Value"));
		
		Group g2=new Group("G2");
		g2.Properties.add(new Property("p","214a"));
		
		g.Groups.add(g2);
		
		g.BraceStyle=Style.K_R;
		System.out.print(g.toString(true));
	}
	
	static void fromTest(){
		Group g = new Group();
		Info.AllowEqualsInValue=true;
		Info.AllowSemicolonInValue=true;
		System.out.println(g.fromString("g{p=test;g2{a;b=;c=a=b;;;}}c=a=b;;;"));
		g.BraceStyle=Style.K_R;
		System.out.println(g.toString(true));
	}
}
