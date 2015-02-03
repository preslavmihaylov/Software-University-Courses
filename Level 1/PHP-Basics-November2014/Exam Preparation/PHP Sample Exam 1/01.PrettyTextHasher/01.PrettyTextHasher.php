<?php

$text = $_GET['text'];
$hashValue = (int)$_GET['hashValue'];
$fontSize = $_GET['fontSize'];
$style = $_GET['fontStyle'];

for ($index = 0; $index < strlen($text); $index++) {
    $ch = ord($text[$index]);
    if ($index % 2 == 0) {
        $ch+= $hashValue;
    } else {
        $ch-= $hashValue;
    }

    $text[$index] = chr($ch);
}

if ($style == "bold") {
    echo '<p style="font-size:'.$fontSize.';font-weight:bold;">' . $text . '</p>';
} else {
    echo '<p style="font-size:'.$fontSize.';font-style:'.$style.';">' . $text . '</p>';
}