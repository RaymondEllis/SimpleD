<?php
	
	include("simpled_helper.php");
	
	/*
	$g= new sdGroup("TheName",false);
	echo $g->name;
	echo $g->props[0]->name;
	*/
	
	
	$g=new sdGroupH("test.sd", true);
	$index=0;
	#echo "<p> FromStringBase: ". $g->FromString("gname{z=321;}",false);
	#$g->FromFile('test.sd', true);
	if (isset($g->grps[0])){
		echo "<p>".$g->ToString(false, sdStyle::K_R); 
		$g->ToFile('test.sd', false, sdStyle::K_R);
	}else{
		echo "<p>group 0 is unset.";
	}
	
	
?>