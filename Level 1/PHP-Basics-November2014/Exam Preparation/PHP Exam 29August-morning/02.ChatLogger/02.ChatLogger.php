<?php

// $_GET['currentDate'] = '29-08-2014 16:33:11';
// $_GET['messages'] = 'Kaji na mama che q obicham / 29-08-2014 15:32:23
// mS/:)sg17 / 29-08-2014 15:30:32
// Brat sgashtiha me da prepisvam i me karat v raionnoto.. / 29-08-2014 15:30:58';

date_default_timezone_set('Europe/Sofia');

$currentDate = strtotime($_GET['currentDate']);

$messages = preg_split('/\r?\n/', $_GET['messages']);

$data = [];

foreach ($messages as $message) {
    $elements = preg_split('/\//', $message);
    $data[] = [];
    if (count($elements) > 2) {
        $temp = trim($elements[0]);
        for ($index = 1; $index < count($elements) - 1; $index++) {
            $temp .= '/' . trim($elements[$index]);
        }

        $data[count($data) - 1]['message'] = htmlspecialchars($temp);
        $data[count($data) - 1]['date'] = trim($elements[count($elements) - 1]);
    } else {
        $data[count($data) - 1]['message'] = htmlspecialchars(trim($elements[0]));
        $data[count($data) - 1]['date'] = trim($elements[1]);
    }
}

usort($data, 'compare_func');

function compare_func($a, $b)
{
    // CONVERT $a AND $b to DATE AND TIME using strtotime() function
    $t1 = strtotime($a['date']);
    $t2 = strtotime($b['date']);

    return ($t1 - $t2);
}

$lastDate = strtotime($data[count($data) - 1]['date']);
$output = '';

for ($index = 0; $index < count($data); $index++) {
    $message = $data[$index]['message'];
    $output .= "<div>$message</div>\n";
}

$timeElapsed = $currentDate - $lastDate;
switch ($timeElapsed) {
    case $timeElapsed < 60 && date('d-m-Y', $lastDate) == date('d-m-Y', $currentDate):
        $output .= '<p>Last active: <time>a few moments ago</time></p>';
        break;
    case $timeElapsed < 3600 && date('d-m-Y', $lastDate) == date('d-m-Y', $currentDate):
        $timeElapsed =floor($timeElapsed / 60);
        $output .= "<p>Last active: <time>$timeElapsed minute(s) ago</time></p>";
        break;
    case $timeElapsed < (3600 * 24) && date('d-m-Y', $lastDate) == date('d-m-Y', $currentDate):
        $timeElapsed = floor($timeElapsed / 3600);
        $output .= "<p>Last active: <time>$timeElapsed hour(s) ago</time></p>";
        break;
    case ($timeElapsed - (3600 * 24)) < (3600 * 24):
        $output .= "<p>Last active: <time>yesterday</time></p>";
        break;
    default:
        $date = date('d-m-Y', $lastDate);
        $output .= "<p>Last active: <time>$date</time></p>";
        break;
}

echo $output;