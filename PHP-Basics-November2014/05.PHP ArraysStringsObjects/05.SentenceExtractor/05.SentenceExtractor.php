<html>
    <head>
        <title>Sentence Extractor</title>
    </head>
    <body>
        <form action="" method="get">
            <textarea name="input" id="" cols="30" rows="10"></textarea>
            <div>Word to check: <input type="text" name="word" /></div>
            <input type="submit"/>
        </form>

        <?php
        if (isset($_GET['input']) && isset($_GET['word'])) {
            $input = htmlspecialchars($_GET['input']);
            $word = htmlspecialchars($_GET['word']);
            preg_match_all('/\s?([^.!?]+[.!?])/', $input, $output);

            foreach ($output[1] as $sentence) {
                if (preg_match("/\s$word\s/", $sentence)) {
                    echo "<div>$sentence</div>";
                }
            }


        }
        ?>
    </body>
</html>