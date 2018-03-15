<?php

  // Get variables from url
  $pass = $_GET['pass'];
  $id = $_GET['id'];

  if ($pass !== "AblosStream00") {
    die("ERROR:401");
  }

  if (empty($id)) {
    die("ERROR:404");
  }

  if (unlink(__DIR__ . "/streams/" . $id . ".mp3")) {
    echo "status:OK";
  }else {
    echo "status:ERROR";
  }

?>
