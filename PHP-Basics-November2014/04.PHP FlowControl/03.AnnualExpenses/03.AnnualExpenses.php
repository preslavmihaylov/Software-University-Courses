<html>
    <head>
        <title>Annual Expenses</title>
        <style>
            table {
                border-collapse: collapse;
            }

            td, th {
                border: 1px solid black;
                width: 100px;
            }
        </style>
    </head>
    <body>
        <form action="" method="get">
            <input type="number" name="years" />
            <input type="submit" value="Submit" />
        </form>

        <?php
        if (isset($_GET['years'])) {
            $years = (int)$_GET['years'];
            $currentYear = (int)date_format(new DateTime(), 'Y');

            echo '<table>' .
                '<tr><th>Year</th><th>January</th><th>February</th><th>March</th><th>April</th><th>May</th><th>June</th>' .
                '<th>July</th><th>August</th><th>September</th><th>October</th><th>November</th><th>December</th><th>Total</th></tr>';

            for ($year = $currentYear; $year >= $currentYear - $years + 1; $year--) {
                echo "<tr><td>$year</td>";

                $totalExpenses = 0;
                for ($index = 0; $index < 12; $index++) {
                    $randomNumber = rand(1, 999);
                    $totalExpenses += $randomNumber;

                    echo "<td>$randomNumber</td>";
                }

                echo "<td>$totalExpenses</td></tr>";
            }

            echo '</table>';
        }
        ?>
    </body>
</html>