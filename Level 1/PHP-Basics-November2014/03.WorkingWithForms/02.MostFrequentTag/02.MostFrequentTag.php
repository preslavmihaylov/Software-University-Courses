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
    $elements = [];
    $count = 0;
    $maxCount = 0;
    $mostFrequentElement = "";

    for ($index = 0; $index < count($input); $index++) {
        if (in_array($input[$index], $elements)) {
            continue;
        } else {
            $elements[] = $input[$index];
        }

        for ($nextIndex = $index; $nextIndex < count($input); $nextIndex++) {
            if ($input[$nextIndex] == $input[$index]) {
                $count++;
            }
        }

        echo '<div>' . "$input[$index] : $count times" . "</div>\n";

        if ($maxCount < $count) {
            $maxCount = $count;
            $mostFrequentElement = $input[$index];
        }

        $count = 0;
    }

    echo '<div>' . "Most Frequent Tag : $mostFrequentElement" . "</div>\n";
}
?>
</body>
</html>