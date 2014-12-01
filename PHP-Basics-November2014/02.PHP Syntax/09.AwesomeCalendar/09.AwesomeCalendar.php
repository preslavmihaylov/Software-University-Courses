<html>
    <head>
        <title>Awesome Calendar</title>
        <style>
            h1 {
                text-align: center;
            }

            table {
                display: inline-block;
                border: 1px solid black;
                height: 230px;
                margin: 10px;
                margin-left: 25px;
            }
            td {
                width: 35px;
                text-align: center;
            }

            tr th {
                text-align: center;
            }

            table tr:nth-child(2) td {
                border-top: 1px solid gray;
                border-bottom: 1px solid gray;
                font-weight: bold;
            }

            table tr:nth-child(2) td:nth-child(7) {
                color: red;
            }
        </style>
    </head>
    <body>

    <?php
    $date = new DateTime();
    $year = (int)date_format($date, 'Y');
    $nextYear = $year + 1;
    $date = new DateTime("01.01.$year");
    $month = "";
    $output = "";

    echo '<h1>' . $year . "</h1>\n";
    while ($year != $nextYear) {
        $currentMonth = date_format($date, 'F');
        $month = $currentMonth;
        $output = initializeMonth($output, $month);

        while ($currentMonth == $month) {
            $output = populateTable($output, $date);

            date_add($date, date_interval_create_from_date_string('1 days'));

            $currentMonth = date_format($date, 'F');
        }
        $output = encloseTable($output, $date);
        echo $output;
        $year = (int)date_format($date, 'Y');
    }

    // date_add($date, date_interval_create_from_date_string('10 days'));
    ?>

    <?php
    function initializeMonth($output, $month) {
        $output = "<table>\n" .
            '<tr><th colspan="7">' . "$month</th></tr>" . "\n" .
            "<tr><td>Mon</td><td>Tue</td><td>Wed</td>" .
            "<td>Thu</td><td>Fri</td><td>Sat</td><td>Sun</td></tr>\n";

        return $output;
    }

    function populateTable($output, $date) {
        $dayOfWeek = date_format($date, 'N');
        $day = date_format($date, 'd');
        if ($day == "01") {
            $output = $output . '<tr>';
            for ($index = 1; $index < (int)$dayOfWeek; $index++) {
                $output = $output . '<td></td>';
            }
        }

        $output = $output . "<td>$day</td>";
        if ($dayOfWeek == "7") {
            $output = $output . "</tr>\n<tr>";
        }

        return $output;
    }

    function encloseTable($output, $date)
    {
        $dayOfWeek = date_format($date, 'N');
        if ($dayOfWeek != "01") {
            for ($index = (int)$dayOfWeek; $index <= 7; $index++) {
                $output = $output . "<td></td>";
            }
        }

        $output = $output . "</tr>\n" .
            "</table>\n";

        return $output;
    }
    ?>

    </body>
</html>