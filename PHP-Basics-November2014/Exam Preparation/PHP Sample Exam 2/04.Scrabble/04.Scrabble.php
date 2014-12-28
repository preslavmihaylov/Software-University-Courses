<?php
// $_GET['mainWord'] = '{"row $# asdasdsa4": "operator"}';
// $_GET['words'] = '["generally", "objects","system","like","needs"]';

$mainWord = json_decode($_GET['mainWord']);

$words = json_decode($_GET['words']);
$output = [];

foreach ($words as $word) {
    if (isset($output[$word])) {
        $output[$word]++;
    } else {
        $output[$word] = 1;
    }
}

$mainRow;
$main;
foreach ($mainWord as $key => $value) {
    $mainRow = (int)preg_split('/[^0-9]/', $key, -1, PREG_SPLIT_NO_EMPTY)[0];
    $main = $value;
}

$mainRow--;

$matrix = [];

for ($row = 0; $row < strlen($main); $row++) {
    $matrix[$row] = [];
    for ($col = 0; $col < strlen($main); $col++) {
        if ($row != $mainRow) {
            $matrix[$row][$col] = '';
        } else {
            $matrix[$row][$col] = $main[$col];
        }
    }
}

$longestWord = "";
$row = 0;
$col = 0;

foreach ($words as $word) {
    if (strlen($word) > strlen($main)) {
        continue;
    }

    $match = false;

    for ($firstCh = 0; $firstCh < strlen($word); $firstCh++) {
        if ($match) {
            break;
        }
        for ($secondCh = 0; $secondCh < strlen($main); $secondCh++) {
            if ($word[$firstCh] == $main[$secondCh]) {
                $tempRow = $mainRow - $firstCh;

                if (!($tempRow < 0 || $tempRow + strlen($word) > strlen($main))) {
                    if (strlen($word) > strlen($longestWord)) {
                        $longestWord = $word;
                        $row = $tempRow;
                        $col = $secondCh;
                        $match = true;
                        break;
                    }
                }
            }
        }
    }
}

for ($index = 0; $index < strlen($longestWord); $index++) {
    $matrix[$row++][$col] = $longestWord[$index];
}

unset($output[$longestWord]);

foreach ($output as $key => $value) {
    $asciiSum = 0;
    for ($index = 0; $index < strlen($key); $index++) {
        $asciiSum += ord($key[$index]);
    }

    $output[$key] = $asciiSum * $value;
}

ksort($output);

$output = json_encode($output);
if ($output != '[]') {
    preg_replace('/\[([^\]]+)\]/', '\{$1\}', $output);
}

echo '<table>';
for ($row = 0; $row < strlen($main); $row++) {
    echo '<tr>';
    for ($col = 0; $col < strlen($main); $col++) {
        $element = $matrix[$row][$col];
        echo "<td>$element</td>";
    }
    echo '</tr>';
}
echo '</table>';

echo $output;