<?php
    $currentDate = new DateTime();
    $month = $currentDate->format('m');
    $initialDate = new DateTime("01-$month-2014");

    // echo date('Y-m-d', strtotime($Date. ' + 1 days'));

    for ($index = 0; $index < 31; $index++) {
        $tempDate = new DateTime(date('Y-m-d', strtotime(date_format($initialDate, 'Y-m-d') . " + $index days")));
        $currentMonth = $tempDate->format('m');
        if ($currentMonth != $month) {
            break;
        }

        $dayOfWeek = date('l', strtotime(date_format($tempDate, 'Y-m-d')));

        if ($dayOfWeek == "Sunday") {
            echo date_format($tempDate, 'jS ') .
                date_format($tempDate, 'F o') . "<br/>\n";
        }
    }
?>