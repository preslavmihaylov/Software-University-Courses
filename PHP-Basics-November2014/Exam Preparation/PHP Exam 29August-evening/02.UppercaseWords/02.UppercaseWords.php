<?php

// $_GET['text'] = 'ABA.AbA.AbA.ABA.BCAAbc   IBM announced it delivered the first shipment of its Enterprise Cloud system to a U.K.-based managed service provider. PHP5 is the latest PHP currently, YES';

$text = htmlspecialchars($_GET['text']);

$text = preg_replace_callback('/([^a-zA-Z]|^)([A-Z]+)([^a-zA-Z]|$)([A-Z]+(?=[^a-zA-Z]))?/', function($matches) {
    $result = strrev($matches[2]);
    if ($result == $matches[2]) {
        $newResult = "";
        for ($index = 0; $index < strlen($result); $index++) {
            $newResult .= $result[$index] . $result[$index];
        }
        $result = $newResult;
    }

    $nextResult = "";
    if (isset($matches[4])) {
        $nextResult = strrev($matches[4]);
        if ($nextResult == $matches[4]) {
            $newResult = "";
            for ($index = 0; $index < strlen($nextResult); $index++) {
                $newResult .= $nextResult[$index] . $nextResult[$index];
            }
            $nextResult = $newResult;
        }
    }
    // var_dump($matches);
    return $matches[1] . $result . $matches[3] . $nextResult;
},
$text);

$output = '<p>' . $text .'</p>';
echo $output;