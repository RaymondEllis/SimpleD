<?php
	
	include("simpled.php");
	
	/*
	$g= new sdGroup("TheName",false);
	echo $g->name;
	echo $g->props[0]->name;
	*/
	
	
	$g=new sdGroup("");
	$index=0;
	#echo "<p> FromStringBase: ". $g->FromString("gname{z=321;}",false);
	$g->Load('test.sd', true);
	if (isset($g->grps[0])){
		echo "<p>".$g->ToString(false, sdStyle::K_R); 
		$g->Save('test.sd', false, sdStyle::K_R);
	}else{
		echo "<p>group 0 is unset.";
	}
	
	
?>