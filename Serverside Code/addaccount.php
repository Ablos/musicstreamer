<?php

  $username = $_GET['username'];
  $email = $_GET['email'];
  $password = $_GET['password'];

  if (empty($username) || empty($email) || empty($password)) {
    die("empty_value");
  }

  $mysqli = new mysqli('localhost', 'ablos_users', 'AblosSQL00', 'ablos_users');
  $result = $mysqli->query("SELECT ID FROM users WHERE username = '$username'");
  if ($result->num_rows == 0) {

    $mysqli->query("INSERT INTO `users` (`username`, `email`, `password`) VALUES (`$username`, `$email`, `$password`)");
    header("location:../");

  }else {
    header("location:http://vibesmusic.cf/");
  }
  $mysqli->close();

?>
