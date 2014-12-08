<html>
    <head>
        <title>Find Primes In Range</title>
        <style>
            .prime {
                font-weight: bold;
            }
        </style>
    </head>
    <body>
        <form action="" method="get">
            <div>Find Primes in Range:</div>
            <input type="number" name="start" placeholder="Start" />
            <input type="number" name="end" placeholder="End" />
            <input type="submit" value="Find Primes" />
        </form>

        <?php
        if (isset($_GET['start']) && isset($_GET['end'])) {
            $start = (int)$_GET['start'];
            $end = (int)$_GET['end'];

            echo '<div>';
            for ($index = $start; $index <= $end; $index++) {
                if (isPrime($index)) {
                    echo '<span class="prime">' . $index . ', </span>';
                } else {
                    echo "<span>$index, </span>";
                }
            }

            echo '</div';
        }
        ?>

        <?php
        function isPrime($number) {
            if ($number < 2) {
                return false;
            }
            for ($index = 2; $index <= sqrt($number); $index++) {
                if ($number % $index == 0) {
                    return false;
                }
            }

            return true;
        }
        ?>
    </body>
</html>