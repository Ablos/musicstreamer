<?php

  $username = $_POST['username'];
  $password = $_POST['password'];

  if (empty($username) || empty($password)) {
    die("empty_value");
  }

  $mysqli = new mysqli('localhost', 'ablos_users', 'AblosSQL00', 'ablos_users');
  $unameresult = $mysqli->query("SELECT ID FROM users WHERE username = '$username'");
  $emailresult = $mysqli->query("SELECT ID FROM users WHERE email = '$username'");
  if ($unameresult->num_rows > 0 || $emailresult->num_rows > 0) {

    if ($unameresult->num_rows > 0) {
      while ($row = $unameresult->fetch_assoc()) {
          $ID = $row['ID'];
      }
    }else {
      while ($row = $emailresult->fetch_assoc()) {
          $ID = $row['ID'];
      }
    }

    $result = $mysqli->query("SELECT password FROM users WHERE ID = '$ID'");

    while ($row = $result->fetch_assoc()) {
      if (password_verify($password, $row['password'])) {
        echo "success";
      }else {
        echo "incorrect";
      }
    }

  }else {
    die("user_not_found");
  }
  $mysqli->close();

?>
