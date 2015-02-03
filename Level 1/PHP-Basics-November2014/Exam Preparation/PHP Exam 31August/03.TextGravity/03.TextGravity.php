<?php

// $_GET['text'] = 'The Milky Way is the galaxy that contains our star system';
// $_GET['lineLength'] = '10';

$text = $_GET['text'];
$lineLength = (int)$_GET['lineLength'];

$field = [];

$count = 0;

while ($count < strlen($text)) {
    $field[] = new SplFixedArray($lineLength);
    for ($index = 0; $index < $lineLength; $index++) {
        $field[count($field) - 1][$index] = $text[$count++];
        if ($count >= strlen($text)) {
            for ($col = $index + 1; $col < $lineLength; $col++) {
                $field[count($field) - 1][$col] = " ";
            }
            break;
        }
    }
}

for ($row = count($field) - 1; $row >= 0; $row--) {
    for ($col = $lineLength - 1; $col >= 0; $col--) {
        if ($field[$row][$col] == ' ') {
            $swapPos = $row;
            while ($field[$swapPos][$col] == ' ') {
                $swapPos--;
                if ($swapPos == -1) {
                    break;
                }
            }

            if ($swapPos != -1) {
                $field[$row][$col] = $field[$swapPos][$col];
                $field[$swapPos][$col] = ' ';
            }
        }
    }
}

echo '<table>';
for ($row = 0; $row < count($field); $row++) {
    echo '<tr>';
    for ($col = 0; $col < $lineLength; $col++) {
        echo '<td>' . htmlspecialchars($field[$row][$col]) . '</td>';
    }
    echo '</tr>';
}
echo '<table>';