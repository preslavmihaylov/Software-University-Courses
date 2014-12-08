<html>
<head>
<title>HTMLTagsCounter</title>
</head>
<body>
<?php
session_start();

if (!isset($_SESSION['elements'])) {
    $_SESSION['elements']=['!DOCTYPE','a','abbr','acronym2','address','applet3','area','article','aside',
        'audio','b','base','basefont4','bdi','bdo','big4','blockquote','body','br','button',
        'canvas','caption','center4','cite','code','col','colgroup','command','datalist',
        'dd','del','details','dfn','dir','div','dl', 'dt','em','embed','fieldset',
        'figcaption','figure','font','footer','form','frame','frameset','h1-h6','head',
        'header','hgroup','hr','html','i', 'iframe','img','input','ins'];
}

echo '<div>Enter HTML tags:</div>' . "<br/>\n" .
    '<form action="" method="post">' . "<br/>\n" .
    '<input type="text" name="input"><input type="submit" value="Submit" required>' . "<br/>\n" .
    '</form>' . "<br/>\n" . "<br/>\n";
?>

<?php
if (!isset($_SESSION['count'])) {
    $_SESSION['count'] = 0;
}

if (isset($_POST['input'])) {
    $input = htmlspecialchars($_POST['input']);
    if (in_array($input, $_SESSION['elements'])) {
        $element = array_search($input, $_SESSION['elements']);
        unset($_SESSION['elements'][$element]);
        $_SESSION['count']++;

        echo 'Valid HTML Tag!' . "<br/>\n" .
            'Score: ' . $_SESSION['count'] . "<br/>\n";
    } else {
        echo 'Invalid or already submitted HTML Tag!' . "<br/>\n" .
            'Score: ' . $_SESSION['count'] . "<br/>\n";
    }
}
?>
</body>
</html>