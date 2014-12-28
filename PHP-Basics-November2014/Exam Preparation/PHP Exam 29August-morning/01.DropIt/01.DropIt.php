<?php
// $_GET['text'] = 'Hi PHP5';
// $_GET['minFontSize'] = '4';
// $_GET['maxFontSize'] = '8';
// $_GET['step'] = '3';

$text = $_GET['text'];
$minFont = (int)$_GET['minFontSize'];
$maxFont = (int)$_GET['maxFontSize'];
$step = (int)$_GET['step'] * -1;

$currentFont = $minFont;

for ($index = 0; $index < strlen($text); $index++) {
    $char = htmlspecialchars($text[$index]);

    if (preg_match('/[a-zA-Z]/', $text[$index]) && ($currentFont <= $minFont || $currentFont >= $maxFont)) {
        $step *= -1;
    }

    if (ord($text[$index]) % 2 == 0) {
        $output = "<span style='font-size:$currentFont;text-decoration:line-through;'>$char</span>";
    } else {
        $output = "<span style='font-size:$currentFont;'>$char</span>";
    }

    if (preg_match('/[a-zA-Z]/', $text[$index])) {
        $currentFont += $step;
    }
    echo $output;


}

// <span style='font-size:4;text-decoration:line-through;'>H</span>