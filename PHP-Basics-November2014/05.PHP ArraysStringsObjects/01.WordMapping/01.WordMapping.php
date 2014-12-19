<html>
    <head>
        <title>Word Mapping</title>

        <style>
            table {
                border: 1px solid black;
            }

            td {
                border: 1px solid black;
            }
        </style>
    </head>
    <body>
        <form action="" method="get">
            <input type="text" name="input" />
            <input type="submit"/>
        </form>

        <?php
        $_GET['input'] = 'The quick brows fox.!!! jumped over..// the lazy dog.!';
        if (isset($_GET['input'])) {
            $words = preg_split('/\W+/', htmlspecialchars($_GET['input']), -1, PREG_SPLIT_NO_EMPTY);
            $elements = [];

            foreach ($words as $word) {
                if (array_key_exists(strtolower($word), $elements)) {
                    $elements[strtolower($word)]++;
                } else {
                    $elements[strtolower($word)] = 1;
                }
            }

            echo '<table>';
            foreach ($elements as $key => $value) {
                echo "<tr><td>$key</td><td>$value</td></tr>";
            }
            echo '</table>';
        }
        ?>
    </body>
</html>

