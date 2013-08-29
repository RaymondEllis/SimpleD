<?php
	include('simpled.php');
	
	class sdGroupH extends sdGroup{
	
		function __construct($data, $FromFile){
			if($FromFile==true){
				$this->FromFile($data, false);
			}else{
				$this->name = $data;
			}
		}
		
		function ToFile($File, $AddVersion){
			$fh=fopen($File, 'w');
			fwrite($fh, $this->ToString($AddVersion));
			fclose($fh);
		}
		function FromFile($File){
			if(!file_exists($File))
			{
				echo "<b>Error</b> file: $File does not exist!";
				return;
			}
			if(filesize($File)>0){
				$fh=fopen($File, 'r');
				$error=$this->FromString(fread($fh,filesize($File)));
				fclose($fh);
				return $error;
			} else {
				echo "Error File is empty! ".$File;
			}
		}
	}
	
?>