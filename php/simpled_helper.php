<?php
	include('simpled.php');
	
	class sdGroupH extends sdGroup{
	
		function __construct($data, $FromFile){
			if($FromFile==true){
				$this->FromFile($data, false);
			}else{
				$this->name = $name;
			}
		}
		
		function ToFile($File, $AddVersion, $OverrideStyle){
			$fh=fopen($File, 'w');
			fwrite($fh, $this->ToString($AddVersion, $OverrideStyle));
			fclose($fh);
		}
		function FromFile($File, $AllowEqualsInValue){
			$fh=fopen($File, 'r');
			$this->FromString(fread($fh,filesize($File)), $AllowEqualsInValue);
			fclose($fh);
		}
	}
	
?>