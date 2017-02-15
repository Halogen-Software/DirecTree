<?php

class ConnectionInfo{
	public $_serverName;
	public $_connectionInfo;
	public $conn;
	
	public function GetConnection(){
		$this->_serverName = 'localhost';
		$this->_connectionInfo = array("Database"=>"DirecTree","UID"=>"lukedavids","PWD"=>"qwer8765ASDF_D");
		$this->conn = sqlsrv_connect($this->_serverName,$this->$_connectionInfo);
		
		return $this->conn;
	}
}
?>