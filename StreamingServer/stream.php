<?php

  // Generates a random string
  function generateRandomString($length = 10) {
    $characters = '0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ';
    $charactersLength = strlen($characters);
    $randomString = '';
    for ($i = 0; $i < $length; $i++) {
        $randomString .= $characters[rand(0, $charactersLength - 1)];
    }
    return $randomString;
  }

  // Get variables from url
  $pass = $_GET['pass'];
  $url = $_GET['url'];

  $url = str_replace("%20", " ", $url);
  $url = str_replace("%26", "&", $url);

  if ($pass !== "AblosStream00") {
    die("ERROR:401");
  }

  if (empty($url)) {
    die("ERROR:404");
  }

  $id = generateRandomString(30);

  while (file_exists(__DIR__ . "/streams/" . $id . ".mp3")) {
    $id = generateRandomString(30);
  }

  copy("https://ablos:AblosStack00@ablos.stackstorage.com/remote.php/webdav/" . $url, __DIR__ . "/streams/" . $id . ".mp3");

  echo "StreamID:" . $id;

?>
