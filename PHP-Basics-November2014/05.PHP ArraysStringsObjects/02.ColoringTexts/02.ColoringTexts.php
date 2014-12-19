<html>
    <head>
        <title>Coloring Texts</title>

        <style>
            .red {
                color: red;
            }

            .blue {
                color: blue;
            }
        </style>
    </head>
    <body>
        <form action="" method="get">
            <input type="text" name="input" />
            <input type="submit"/>
        </form>

        <?php
        if (isset($_GET['input'])) {
            $input = htmlspecialchars($_GET['input']);
            $elements = preg_split('//', $input, -1, PREG_SPLIT_NO_EMPTY);
            foreach ($elements as $element) {
                if ($element != ' ') {
                    if (ord($element) % 2 == 0) {
                        echo "<span class='red'>$element </span>";
                    } else {
                        echo "<span class='blue'>$element </span>";
                    }
                }
            }

        }
        ?>
    </body>
</html>