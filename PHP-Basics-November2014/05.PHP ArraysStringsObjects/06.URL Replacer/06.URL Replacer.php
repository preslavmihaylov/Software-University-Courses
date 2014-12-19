<html>
    <head>
        <title>URL Replacer</title>
    </head>
    <body>
        <form action="" method="get">
            <textarea name="input" id="" cols="30" rows="10"></textarea>
            <input type="submit"/>
        </form>

        <?php
        // <a href="http://softuni.bg">the Software University</a>
        if (isset($_GET['input'])) {
            $input = $_GET['input'];
            $pattern = '/<a\s+href=\"([^\"]+)">([^<]+)<\/a>/';
            $replacement = '<b>[URL=$1]$2[/URL]</b>';
            $input = preg_replace($pattern, $replacement, $input);
            echo "<div>$input</div>";
        }
        ?>
    </body>
</html>