<?php
	require_once(dirname(__FILE__).'/ConnectionInfo.php');
	
	$connectionInfo = new ConnectionInfo();
	$connectionInfo->GetConnection();
	
	if (!$connectionInfo->conn){
		echo 'No connection';
	}else{
		$query = 'SELECT * from Vendor';
		
		$statement = sqlsrv_query($connectionInfo->conn, $query);
		
		if (!$statement){
			echo 'Query failed';
		}else{
			$vendors = array();
			
			while ($row = sqlsrv_fetch_array($statement,SQLSRV_FETCH_ASSOC)){
				$vendor = array(
					"Id"
					"CompanyName" => $row['id'],
					"VendorName" => $row['vendor_name'],
					"VendorSurname" => $row['vendor_surname'],
					"Address" => $row['address'],
					"Email" => $row['email'],
					"Username" => $row['username'],
					"Password" => $row['password'],
					"ProfilePic" => $row['profile_pic'],
					"ProfileBackground" => $row['profile_background'],
					"ProfileLayout" => $row['profile_layout'],
					"ProfileBackgroundColor" => $row['profile_background_color']
				)
				array_push($vendors, $vendor);
			}
			
			echo json_encode($vendors);
		}
	}
?>        