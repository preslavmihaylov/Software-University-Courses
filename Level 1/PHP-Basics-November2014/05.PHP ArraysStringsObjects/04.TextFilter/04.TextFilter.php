<html>
    <head>
        <title>Text Filter</title>
    </head>
    <body>
    <?php
    $banList = 'Linux, Windows';
    ?>

        <form action="" method="get">
            <textarea name="input" id="" cols="30" rows="10"></textarea>
            <input type="submit"/>
            <div>Ban list: <?php echo $banList ?></div>
        </form>

    <?php
    if (isset($_GET['input'])) {
        $bannedWords = explode(', ', $banList);
        $input = htmlspecialchars($_GET['input']);
        foreach ($bannedWords as $word) {
            $replacement = array_fill(0, strlen($word), "*");
            $input = str_replace("$word", implode($replacement), $input);
        }

        echo $input;
    }
    ?>

    </body>
</html>