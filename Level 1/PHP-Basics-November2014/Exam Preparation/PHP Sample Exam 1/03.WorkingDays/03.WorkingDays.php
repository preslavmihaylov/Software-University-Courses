<?php
//$_GET['dateOne'] = '17-12-2014';
//$_GET['dateTwo'] = '31-12-2014';
//$_GET['holidays'] = '31-12-2014
//24-12-2014
//08-12-2014';


date_default_timezone_set('Europe/Sofia');

$dateOne = date_create_from_format('d-m-Y', $_GET['dateOne']);
$dateTwo = date_create_from_format('d-m-Y', $_GET['dateTwo']);
$holidays = preg_split('/[\s]+/', $_GET['holidays']);
$output = [];

date_add($dateTwo, date_interval_create_from_date_string('1 days'));

while (date_format($dateOne, 'd-m-Y') != date_format($dateTwo, 'd-m-Y')) {
    $isWorkDay = true;
    foreach ($holidays as $holiday) {
        if (date_format($dateOne, 'd-m-Y') == $holiday) {
            $isWorkDay = false;
            break;
        }
    }

    $dayOfWeek = date_format($dateOne, 'N');
    if ($dayOfWeek == '6' || $dayOfWeek == '7') {
        $isWorkDay = false;
    }

    if ($isWorkDay == true) {
        $output[] = date_format($dateOne, 'd-m-Y');
    }

    date_add($dateOne, date_interval_create_from_date_string('1 days'));
}

if (count($output) > 0) {
    echo '<ol>';
    foreach ($output as $date) {
        echo '<li>' . $date . '</li>';
    }
    echo '</ol>';
} else {
    echo '<h2>No workdays</h2>';
}


