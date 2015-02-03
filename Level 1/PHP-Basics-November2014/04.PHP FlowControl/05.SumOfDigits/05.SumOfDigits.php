<html>
    <head>
        <title>Sum Of Digits</title>
        <style>
            table {
                border: 1px solid black;
            }

            td {
                border: 1px solid black;
                width: 150px;
            }
        </style>
    </head>
    <body>
        <form action="" method="post">
            <input type="text" name="input" />
            <input type="submit" value="Submit" />
        </form>

        <?php
        if (isset($_POST['input'])) {
            $input = explode(', ', $_POST['input']);

            echo '<table>';
            for ($index = 0; $index < count($input); $index++) {
                if (!is_numeric($input[$index])) {
                    echo "<tr><td>$input[$index]</td><td>I cannot sum that</td></tr>";
                } else {
                    $digitSum = 0;
                    for ($digit = 0; $digit < strlen($input[$index]); $digit++) {
                        $currentDigit = (int)$input[$index][$digit];
                        $digitSum += $currentDigit;
                    }

                    echo "<tr><td>$input[$index]</td><td>$digitSum</td></tr>";
                }
            }

            echo '</table>';
        }
        ?>
    </body>
</html>