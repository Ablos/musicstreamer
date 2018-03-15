<?php

  // Get variables from url
  $pass = $_GET['pass'];

  if ($pass !== "AblosStream00") {
    die("ERROR:401");
  }

  $streams = scandir(__DIR__ . "/streams/");

  foreach ($streams as $stream) {
    $file = __DIR__ . "/streams/" . $stream;
    if (is_file($file)) {
      if (time()-filemtime($file) > 720) {
          unlink($file);
      }
    }
  }

  echo "done";
?>
