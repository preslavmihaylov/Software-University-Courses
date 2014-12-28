<?php

//$_GET['jsonTable'] = '[4,["Ping results:",
//"Reply from 95.101.195.91: bytes=32 time=115ms TTL=49",
//"Reply from 95.101.195.91: bytes=32 time=111ms TTL=49",
//"Reply from 95.101.195.91: bytes=32 time=102ms TTL=49",
//"Reply from 95.101.195.91: bytes=32 time=116ms TTL=49",
//"Reply from 95.101.195.91: bytes=32 time=117ms TTL=49",
//"Reply from 95.101.195.91: bytes=32 time=110ms TTL=49",
//"Reply from 95.101.195.91: bytes=32 time=105ms TTL=49"]]
//';

$data = json_decode($_GET['jsonTable']);
// var_dump($data);
$columns = $data[0];

$message = [];
for ($index = 0; $index < count($data[1]); $index++) {
    preg_match_all('/Reply from [0-9\.]+: bytes=[0-9]+ time=([0-9]+)ms TTL=[0-9]+/', $data[1][$index], $matches);
    if (!empty($matches[1])) {
        $char = chr($matches[1][0]);
        $message[] = $char;
    }
}

//var_dump($message);
// $message = ['s', 'o', 'f', 't', ' ', 'u', 'n','i'];

$table = [];
for ($index = 0; $index < count($message); $index++) {
    $table[count($table)] = array_fill(0, $columns, NULL);
    for ($col = 0; $col < $columns; $col++) {
        if ($message[$index] == ' ') {
            $message[$index] = '';
        } elseif ($message[$index] == '*') { // !!!
            if ($col == 0) {
                $index++;
            } else {
                break;
            }
        }
        $table[count($table) - 1][$col] = $message[$index];
        if ($col != $columns - 1) {
            $index++;
        }
        if ($index == count($message)) {
            break;
        }
    }
}

// var_dump($table);

echo "<table border='1' cellpadding='5'>";
for ($row = 0; $row < count($table); $row++) {
    echo '<tr>';
    for ($col = 0; $col < $columns; $col++) {
        if (empty($table[$row][$col])) {
            echo '<td></td>';
        } else {
            $element = $table[$row][$col];
            echo "<td style='background:#CAF'>$element</td>";
        }
    }
    echo '</tr>';
}
echo '</table>';


// Whitespace is considered as empty (<td></td>) table cell and the symbol '*' as end of a word.