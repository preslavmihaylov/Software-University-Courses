<?php
date_default_timezone_set('Europe/Sofia');

$date = strtotime(date_format(new DateTime(), 'Y-m-d G:i:s'));
$currentYear = (int)date_format(new DateTime(), 'Y') + 1;
$newYear = strtotime("01.01.$currentYear");
$timestamp = $newYear - $date;

echo 'Hours until New Year: ' . floor($timestamp / 3600) . "<br/>\n";
echo 'Minutes until New Year: ' . (int)($timestamp / 60) . "<br/>\n";
echo 'Seconds until New Year: ' . $timestamp . "<br/>\n";

$days = round($timestamp / (3600 * 24));
$timestamp %= (int)(3600 * 24);

$hours = str_pad(round($timestamp / 3600), 2, '0', STR_PAD_LEFT);
$timestamp %= (int)3600;

$minutes = str_pad(round($timestamp / 60), 2, '0', STR_PAD_LEFT);
$timestamp %= (int)60;

$seconds = str_pad(round($timestamp % 60), 2, '0', STR_PAD_LEFT);

echo 'Days:Hours:Minutes:Seconds until New Year: ' .
    "$days:$hours:$minutes:$seconds" . "<br/>\n";
?>