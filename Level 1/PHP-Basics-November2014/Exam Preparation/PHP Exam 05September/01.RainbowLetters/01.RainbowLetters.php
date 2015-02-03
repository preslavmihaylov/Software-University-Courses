<?php

//$_GET['text'] = 'Hell&Asshole';
//$_GET['red'] = '15';
//$_GET['green'] = '100';
//$_GET['blue'] = '20';
//$_GET['nth'] = '5';

$text = $_GET['text'];
$red = str_pad(dechex((int)$_GET['red']), 2, '0',STR_PAD_LEFT);
$green = str_pad(dechex((int)$_GET['green']), 2, '0',STR_PAD_LEFT);
$blue = str_pad(dechex((int)$_GET['blue']), 2, '0',STR_PAD_LEFT);
$num = (int)$_GET['nth'];

$count = 1;
echo '<p>';
for ($index = 0; $index < strlen($text); $index++) {
    $char = htmlspecialchars($text[$index]);
    if ($count == $num) {
        $count = 0;
        echo '<span style="color: ' . "#$red$green$blue" . "\">$char</span>";
    } else {
        echo $char;
    }
    $count++;
}
echo '</p>';