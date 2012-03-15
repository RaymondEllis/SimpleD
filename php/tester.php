<?php
	
	include("simpled_helper.php");
	
	/*
	$g= new sdGroup("TheName",false);
	echo $g->name;
	echo $g->props[0]->name;
	*/
	
	#$AllowSemicolonInValue=false;
	$g=new sdGroupH("test.sd", true);
	#echo "<p> FromStringBase: ". $g->FromString("gname{z=321;}",false);
	#$g->FromFile('test.sd', true);
	if (isset($g->grps[0])){
		$g->braceStyle=sdStyle::BSD_Allman;
		echo "<p>".$g->ToString(false); 
		$g->ToFile('test.sd', false);
	}else{
		echo "<p>group 0 is unset.";
	}
	
	
?>