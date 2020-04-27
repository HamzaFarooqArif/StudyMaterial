<?php
$mysqli = new mysqli("localhost", "root", "", "databasename");
if($mysqli->connect_error) {
    exit('Could not connect');
}

$query = "SELECT id, username, password
FROM tablename";

$result = $mysqli->query($query);
$rows = array();
while($row = $result->fetch_assoc()){
    $rows[] = $row;
}
echo json_encode($rows);
?>