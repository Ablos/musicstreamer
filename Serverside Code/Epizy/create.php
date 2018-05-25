<?php

  $username = $_GET['username'];
  $email = $_GET['email'];
  $password = $_GET['password'];

  if (empty($username) || empty($email) || empty($password)) {
    die("empty_value");
  }

  header("Location:http://ablos.square7.ch/accounts/addaccount.php?username=$username&password=$password&email=$email");

?>
