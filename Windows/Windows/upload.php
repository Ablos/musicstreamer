<?php

$title = $_REQUEST["title"];
$artists = $_REQUEST["artists"];
$genre = $_REQUEST["genre"];
$album = $_REQUEST["album"];
$duration = $_REQUEST["duration"];
$path = $_REQUEST["path"];

$servername = "localhost";
$username = "ablos";
$password = "AblosSQL00";
$dbname = "ablos";

//Create connection
$conn = mysqli_connect($servername, $username, $password, $dbname);

//Check connection
if (!$conn) {
	die("Connection failed: " . $conn->connect_error);
}

//Insert song attributes
$sql = "INSERT INTO `song_list`(`title`,`artists`,`genre`,`album`,`duration`,`path`) VALUES (\"$title\",\"$artists\",\"$genre\",\"$album\",\"$duration\",\"$path\")";

//Give feedback
if (mysqli_query($conn, $sql)) {
	echo "affirmative";
}

//Close connection
mysqli_close($conn);

?>
