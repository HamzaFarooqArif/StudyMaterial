
<?php
include "dbConnection.php";
$id = $_GET['id'];

//selecting data associated with this particular id
$result = $conn->query("SELECT * FROM users WHERE id=$id");

foreach ($result as $res) {
	$name = $res['name'];
	$age = $res['age'];
	$email = $res['email'];
}
?>
<html>
<head>	
	<title>Edit Data</title>
</head>

<body>
	<a href="index.php">Home</a>
	<br/><br/>
	
	<form name="form1" method="post" action="crud.php">
		<table border="0">
			<tr> 
				<td>Name</td>
				<td><input type="text" name="name" value="<?php echo $name;?>" required></td>
			</tr>
			<tr> 
				<td>Age</td>
				<td><input type="number" name="age" value="<?php echo $age;?>" required></td>
			</tr>
			<tr> 
				<td>Email</td>
				<td><input type="email" name="email" value="<?php echo $email;?>" required></td>
			</tr>
			<tr>
				<td><input type="hidden" name="id" value=<?php echo $_GET['id'];?>></td>
				<td><input type="submit" name="update" value="Update"></td>
			</tr>
		</table>
	</form>
</body>
</html>
