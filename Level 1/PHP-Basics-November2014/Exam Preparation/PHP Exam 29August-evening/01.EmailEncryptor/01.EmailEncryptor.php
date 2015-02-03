<?php

// $_GET['recipient'] = 'info@softuni.bg';
// $_GET['subject'] = 'SoftUniConf <2014>';
// $_GET['body'] = 'SoftUniConf <2014> is coming.
// <a href="https://softuni.bg/SoftUniConf">Learn more</a>
// ';
// $_GET['key'] = 's3cr3t!';

$recipient = trim(htmlspecialchars($_GET['recipient']));
$subject = trim(htmlspecialchars($_GET['subject']));
$body = trim(htmlspecialchars($_GET['body']));
$key = $_GET['key'];

$formatMessage = "<p class='recipient'>$recipient</p><p class='subject'>$subject</p><p class='message'>$body</p>";

$count = 0;
$output = "";
while ($count < strlen($formatMessage)) {
    for ($index = 0; $index < strlen($key); $index++) {
        if ($count >= strlen($formatMessage)) {
            break;
        }
        $cryptedChar = ord($formatMessage[$count]) * ord($key[$index]);
        $cryptedChar = dechex($cryptedChar);
        $output .= "|" . $cryptedChar;

        $count++;
    }
}

// var_dump($formatMessage);
$output .= "|";
echo $output;