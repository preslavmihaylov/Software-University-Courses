<html>
    <head>
        <title>Square Root Sum</title>
        <style>
            table {
                border-collapse: collapse;
            }

            td, th {
                border: 1px solid black;
                width: 75px;
            }

            table tr:last-child td:first-child {
                font-weight: bold;
            }
        </style>
    </head>
    <body>

    <table>
        <tr><th>Number</th><th>Square</th></tr>
    <?php
    $sum = 0;
    for ($index = 0; $index <= 100; $index+=2) {
        $sqrtRoot = round(sqrt($index), 2);
        $sum += $sqrtRoot;
        echo "<tr><td>$index</td><td>$sqrtRoot</td></tr>";
    }

    echo "<tr><td>Total:</td><td>$sum</td></tr>";
    ?>
    </table>

    </body>
</html>