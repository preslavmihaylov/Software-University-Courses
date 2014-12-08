<html>
    <head>
        <title>Rich People's Problems</title>
        <style>
            table {
                border-collapse: collapse;
            }

            td, th {
                border: 1px solid black;
                width: 75px;
            }
        </style>
    </head>
    <body>

        <form action="" method="get">
            <input type="text" name="cars" />
            <input type="submit" value="Show Result" />
        </form>

        <?php
        if (isset($_GET['cars'])) {
            $cars = explode(', ', htmlspecialchars($_GET['cars']));
            $colors = ['green', 'yellow', 'black', 'red', 'magenta', 'white', 'blue'];

            echo '<table>' .
                '<tr><th>Car</th><th>Color</th><th>Count</th></tr>';

            foreach ($cars as $car) {
                $color = $colors[rand(0, count($colors) - 1)];
                $quantity = rand(1, 5);
                echo "<tr><td>$car</td><td>$color</td><td>$quantity</td></tr>";
            }

            echo '</table>';
        }
        ?>
    </body>
</html>