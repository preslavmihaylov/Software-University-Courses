<html>
    <head>
        <title>Print Tags</title>
    </head>
    <body>
        <?php
        echo '<div>Enter Tags</div>';
        echo '<form action="" method="post">' . "\n" .
            '<input type="text" name="input">' .
            '<input type="submit" value="Submit">' . "<br/>\n";
        ?>

        <?php
        if (isset($_POST['input'])) {
            $input = preg_split('/, /' ,htmlspecialchars($_POST['input']));

            for ($index = 0; $index < count($input); $index++) {
                echo $index . ' : ' . "$input[$index]" . "<br/>\n";
            }
        }
        ?>
    </body>
</html>