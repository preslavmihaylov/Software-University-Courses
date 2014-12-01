<?php
    $input = 950;
    $resultFound = false;

    for ($index = 100; $index < min($input, 1000); $index++) {
        $currentNumber = (string)$index;
        $first = (string) $currentNumber[0];
        $second = (string) $currentNumber[1];
        $third = (string) $currentNumber[2];

        if ($first != $second && $second != $third && $first != $third) {
            echo $currentNumber . "<br>\n";
            $resultFound = true;
        }
    }

    if (!$resultFound) {
        echo "No";
    }
?>