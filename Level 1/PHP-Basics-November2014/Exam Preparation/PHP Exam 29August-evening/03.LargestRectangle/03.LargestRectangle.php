<?php

// $_GET['jsonTable'] = '[["xx","a","a","a","a","a","a"],["a","a","z","z","a","php","a"],["a","a","x","x","a","a","a"],["xx","a","sql","a","a","js","a"],["xx","a","a","a","a","a","a"],["xx","a","z","z","a","php","w"]]';

$table = json_decode($_GET['jsonTable']);

function isValidRectangleHorizontal($start, $end, $row) {
    global $table;
    for ($index = $start; $index < $end; $index++) {
        if ($table[$row][$index] != $table[$row][$index + 1]) {
            return false;
        }
    }
    return true;
}
function isValidRectangleVertical($start, $end, $col) {
    global $table;
    for ($index = $start; $index < $end; $index++) {
        if ($table[$index][$col] != $table[$index + 1][$col]) {
            return false;
        }
    }
    return true;
}

function calculateArea($width, $height) {
    return $width * $height;
}
$count = 0;
$topRow = 0;
$largestArea = 0;
$resultTopLeft = 0;
$resultRight = 0;
$resultBottomLeft = 0;
$resultTopRow = 0;

while ($topRow != count($table)) {
    for ($topLeft = 0; $topLeft < count($table[$topRow]); $topLeft++) {
        for ($bottomLeft = $topRow; $bottomLeft < count($table); $bottomLeft++) {
            if (!isValidRectangleVertical($topRow, $bottomLeft, $topLeft)) {
                break;
            }
            for ($right = $topLeft; $right < count($table[$topRow]); $right++) {
                if (!isValidRectangleHorizontal($topLeft, $right, $topRow) ||
                    !isValidRectangleHorizontal($topLeft, $right, $bottomLeft)) {
                    continue;
                } elseif (!isValidRectangleVertical($topRow, $bottomLeft, $right)) {
                    continue;
                }

                $currentArea = calculateArea(($right - $topLeft) + 1, ($bottomLeft - $topRow) + 1);
                if ($largestArea < $currentArea) {
                    $largestArea = $currentArea;
                    $resultTopLeft = $topLeft;
                    $resultRight = $right;
                    $resultBottomLeft = $bottomLeft;
                    $resultTopRow = $topRow;
                }
                // 'topLeft: ' . $topRow . $topLeft .
                // " topRight: " . $topRow . $right .
                // " bottomLeft: " . $bottomLeft . $topLeft .
                // " bottomRight: " . $bottomLeft . $right . "</br>";
                $count++;
            }
        }
    }

    $topRow++;
}

// echo $count . "</br>";
// echo $largestArea;

echo "<table border='1' cellpadding='5'>";
for ($row = 0; $row < count($table); $row++) {
    echo '<tr>';
    for ($col = 0; $col < count($table[0]); $col++) {
        $result = htmlspecialchars($table[$row][$col]);
        if ($row == $resultTopRow && $col >= $resultTopLeft && $col <= $resultRight) { // top
            // <td style='background:#CCC'>a</td>
            echo "<td style='background:#CCC'>$result</td>";
        } elseif ($row == $resultBottomLeft && $col >= $resultTopLeft && $col <= $resultRight) { // bottom
            echo "<td style='background:#CCC'>$result</td>";
        } elseif ($col == $resultTopLeft && $row >= $resultTopRow && $row <= $resultBottomLeft) { // left
            echo "<td style='background:#CCC'>$result</td>";
        } elseif ($col == $resultRight && $row >= $resultTopRow && $row <= $resultBottomLeft) { // right
            echo "<td style='background:#CCC'>$result</td>";
        } else {
            echo "<td>$result</td>";
        }
    }
    echo '</tr>';
}
echo '</table>';
