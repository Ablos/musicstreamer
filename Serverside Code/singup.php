<?php

  $username = "ablos";//$_POST['username'];
  $email = "a.dieterich2002@gmail.com"; //$_POST['email'];
  $password = "test"; //$_POST['password'];

  if (empty($username) || empty($email) || empty($password)) {
    die("empty_value");
  }

  $mysqli = new mysqli('localhost', 'ablos_users', 'AblosSQL00', 'ablos_users');
  $result = $mysqli->query("SELECT ID FROM users WHERE username = '$username'");
  if ($result->num_rows == 0) {

    $hash = password_hash($password, PASSWORD_BCRYPT);

    $subject = "Verification VIBES account";

    $message = str_replace("INSERTUSERNAMEHERE", $username, str_replace("INSERTLINKHERE", "http://ablos.square7.ch/accounts/addaccount.php?username=$username&password=$hash&email=$email", file_get_contents("http://ablos.square7.ch/accounts/singupmail.html")));

    $headers = "MIME-Version: 1.0" . "\r\n";
    $headers .= "Content-type:text/html;charset=UTF-8" . "\r\n";
    $headers .= 'From: <no-reply@vibesmusic.cf>' . "\r\n";

    if (mail($email,$subject,$message,$headers) !== FALSE) {
      echo "success";
    }else {
      die("false_email");
    }

  }else {
    die("user_exists");
  }
  $mysqli->close();

?>
