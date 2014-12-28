<?php
//$_GET['text'] = '.[*)%2Bsu.[*)%2Bfgjgf90+.[*)%2Bper+.[*)%2B+jfg%0D%0A.[*)%2Bspecia.[*)%2B+.[*)%2Bl+.[*)%2B+.[*)%2Bsymbo.[*)%2Bfgjjgf%2B45^%24%26%24%25%26%25%24.[*)%2Bls.[*)%2B&';
//
//$_GET['key'] = '.7#"F5';

$text = $_GET['text'];
$key = $_GET['key'];

$firstKeyElement = $key[0];
if (preg_match('/[^0-9a-zA-Z]/', $firstKeyElement)) {
    $firstKeyElement = '\\' . $firstKeyElement;
}

$lastKeyElement = $key[strlen($key) - 1];
if (preg_match('/[^0-9a-zA-Z]/', $lastKeyElement)) {
    $lastKeyElement = '\\' . $lastKeyElement;
}

$key = substr($key, 1, strlen($key) - 2);

//$text = str_replace(array("\n", "\r"), '', $text);
$key = preg_replace('/([^0-9a-zA-Z])/','\\\$1', $key);
$key = preg_replace('/[a-z]/', '[a-z]*', $key);
$key = preg_replace('/[A-Z]/', '[A-Z]*', $key);
$key = preg_replace('/[0-9]/', '[0-9]*', $key);

$regex = '/' . $firstKeyElement . $key . $lastKeyElement . "(.{2,6})" . $firstKeyElement . $key . $lastKeyElement . '/';
preg_match_all($regex, $text, $result);
$output = implode('', $result[1]);
echo $output;
