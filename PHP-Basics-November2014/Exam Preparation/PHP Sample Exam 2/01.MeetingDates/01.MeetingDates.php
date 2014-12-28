<?php

date_default_timezone_set('Europe/Sofia');

$dateOne = date_create_from_format('d-m-Y', $_GET['dateOne']);
$dateTwo = date_create_from_format('d-m-Y', $_GET['dateTwo']);

if (date_timestamp_get($dateOne) > date_timestamp_get($dateTwo)) {
    $temp = $dateOne;
    $dateOne = $dateTwo;
    $dateTwo = $temp;
}

$output = "<ol>";
$resultFound = false;

date_add($dateTwo, date_interval_create_from_date_string('1 days'));

while (date_format($dateOne, 'd-m-Y') != date_format($dateTwo, 'd-m-Y')) {
    $dayOfWeek = date_format($dateOne, 'N');
    if ($dayOfWeek == '4') {
        $output .= "<li>" . date_format($dateOne, 'd-m-Y') . "</li>";
        $resultFound = true;
    }

    date_add($dateOne, date_interval_create_from_date_string('1 days'));
}
$output .= '</ol>';

if ($resultFound) {
    echo $output;
} else {
    echo '<h2>No Thursdays</h2>';
}
