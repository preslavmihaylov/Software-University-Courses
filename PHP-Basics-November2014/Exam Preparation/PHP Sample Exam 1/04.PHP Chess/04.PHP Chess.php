<?php
//$_GET['board'] = 'R-H-B-K-Q-B-H-R/P-P- -P-P- -P-P/ - -P- - - - - / - - - - -P- - / - - - - - - - / -P- - - - - -H/P- -P-P-P-P-P-P/R-H-B-K-Q-B- -R';

$pieces = preg_split('/[\/]+/', $_GET['board']); // !!

foreach ($pieces as $piece) {
    if (strlen($piece) != 15) {
        echo '<h1>Invalid chess board</h1>';
        return;
    }

    $rowElements = preg_split('/[\-]+/', $piece);
    if (count($rowElements) != 8) {
        echo '<h1>Invalid chess board</h1>';
        return;
    }
}

$data = new stdClass();
//{"Bishop":4,"Horseman":4,"King":2,"Pawn":16,"Queen":2,"Rook":4}
$data->Bishop = 0;
$data->Horseman = 0;
$data->King = 0;
$data->Pawn = 0;
$data->Queen = 0;
$data->Rook = 0;

$output = '<table>';
foreach ($pieces as $piece) {
    $rowElements = preg_split('/[\-]+/', $piece);
    $output .= '<tr>';
    foreach ($rowElements as $element) {
        $output .= "<td>$element</td>";

        switch ($element) {
            case 'R':
                $data->Rook += 1;
                break;
            case 'Q':
                $data->Queen += 1;
                break;
            case 'B':
                $data->Bishop += 1;
                break;
            case 'H':
                $data->Horseman += 1;
                break;
            case 'P':
                $data->Pawn += 1;
                break;
            case 'K':
                $data->King += 1;
                break;
            case ' ':
                break;
            default:
                echo '<h1>Invalid chess board</h1>';
                return;
        }
    }
    $output .= '</tr>';
}

$output .= '</table>';
foreach ($data as $key => $value) {
    if ($value == 0) {
        unset($data->$key);
    }
}

echo $output;
echo json_encode($data);


