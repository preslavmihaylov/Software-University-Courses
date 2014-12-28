<?php

// $_GET['list'] = 'Java is an object-oriented programming language.
//     PHP is a server-side scripting language.
//     HTML is the standard markup language used to create web pages.
//
//     To define a table in HTML use <table>, <td> and <tr> tags.
// ';
// $_GET['maxSize'] = '50';

$list = preg_split('/[\n\r]+/', $_GET['list']);

$maxSize = (int)$_GET['maxSize'];

echo '<ul>';
foreach ($list as $sentence) {
    if (empty($sentence)) {
        continue;
    }

    $output = substr(trim($sentence), 0, $maxSize);
    if ($output != trim($sentence)) {
        $output .= '...';
    }
    $output = htmlspecialchars($output);
    echo "<li>$output</li>";
}

echo '</ul>';
