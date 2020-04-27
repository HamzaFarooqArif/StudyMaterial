<?php
	include "dbConnection.php";
	$conn= mysqli_connect($host, $username, $password, $database); 
if(isset($_POST['Submit'])) {	
	$name = $_POST['name'];
	$age = $_POST['age'];
	$email = $_POST['email'];
		
		
	//insert data to database	
	$result = $conn->query("INSERT INTO users(name,age,email) VALUES('$name','$age','$email')");
     if ($result)
		{
		echo "<font color='green'>Data added successfully.";
		echo "<br/><a href='index.php'>View Result</a>";
	}
	else
		 echo "Error: " . $sql . "<br>" . $conn->error;

	
} else if(isset($_POST['update']))  //update data
{	
	$id = $_POST['id'];
	$name = $_POST['name'];
	$age = $_POST['age'];
	$email = $_POST['email'];
	$result = $conn->query("UPDATE users SET name='$name',age='$age',email='$email' WHERE id=$id");
		
		//redirectig to the display page. In our case, it is index.php
		header("Location: index.php");
	
}
else   //delete data
{
	$id = $_GET['id'];
	$result = $conn->query("DELETE FROM  users WHERE id=$id");
	header("Location:index.php");
}
?>