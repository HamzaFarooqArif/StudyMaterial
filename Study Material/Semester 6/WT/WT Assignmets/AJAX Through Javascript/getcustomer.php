<?php
$mysqli = new mysqli("localhost", "root", "", "databasename");
if($mysqli->connect_error) {
    exit('Could not connect');
}

$sql = "SELECT username, password
FROM tablename WHERE id = ?";

$stmt = $mysqli->prepare($sql);
$stmt->bind_param("s", $_GET['customerId']);
$stmt->execute();
$stmt->store_result();
$stmt->bind_result( $cname, $pass);
$stmt->fetch();
$stmt->close();

echo "<p><b>Sender Name: </b>";
echo $_GET['senderName'];
echo "</p>";

echo "<table>";
echo "<tr>";
echo "<th>Username</th>";
echo "<td>" . $cname . "</td>";
echo "</tr>";
echo "<tr>";
echo "<th>Password</th>";
echo "<td>" . $pass . "</td>";
echo "</tr>";
echo "</table>";
?>