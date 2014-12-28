<?php

// $_GET['text'] = 'Krali Marko | Rock | Nakov, Joro, Pesho | 1250 | 4.8
// Sladkarnica Malinka | Jazz | Pencho, Nakov, Gero | 728 | 4.3
// Hvani me Minke | Rock | Kaloqn, Tosho | 1930 | 4.4
// V starite Karpati | Rock | Nakov | 1029 | 4.1
// Rakiichice | Rock | Ceco, Joro, Nakov, Preslav, Petya | 453 | 4.2';
//
// $_GET['artist'] = 'Nakov';
// $_GET['property'] = 'rating';
// $_GET['order'] = 'ascending';

$artist = $_GET['artist'];
$property = $_GET['property'];
$order = $_GET['order'];

$elements = preg_split('/\r?\n+/', $_GET['text']);
$data = [];

foreach ($elements as $element) {
    $splitElements = preg_split('/[|]+/', $element);
    if (preg_match('/' . $artist . '/', $splitElements[2])) { // possible error
        $data[] = [];
        $data[count($data) - 1] = new stdClass();
        $data[count($data) - 1]->name = trim($splitElements[0]);
        $data[count($data) - 1]->genre = trim($splitElements[1]);
        $data[count($data) - 1]->artists = preg_split('/\,\s/', trim(htmlspecialchars($splitElements[2])));
        $data[count($data) - 1]->downloads = (int)trim($splitElements[3]);
        $data[count($data) - 1]->rating = (double)trim($splitElements[4]);
    }
}

if ($property == 'rating' || $property == 'downloads') {
    usort($data, function($a, $b) use ($order, $property) {
        if ($order == 'ascending') {
            if ($a->$property > $b->$property) {
                return 1;
            } else if ($a->$property < $b->$property) {
                return -1;
            } else {
                return strcmp($a->name, $b->name);
            }
        } else {
            if ($a->$property < $b->$property) {
                return 1;
            } else if ($a->$property > $b->$property) {
                return -1;
            } else {
                return strcmp($a->name, $b->name);
            }
        }
    });
} else {
    usort($data, function($a, $b) use ($order, $property) {
        if ($order == 'ascending') {
            if (strcmp($a->$property, $b->$property) == 1 || strcmp($a->$property, $b->$property) == -1) {
                return strcmp($a->$property, $b->$property);
            } else {
                return strcmp($a->name, $b->name);
            }
        } else {
            if (strcmp($b->$property, $a->$property) == 1 || strcmp($b->$property, $a->$property) == -1) {
                return strcmp($b->$property, $a->$property);
            } else {
                return strcmp($a->name, $b->name);
            }
        }
    });
}

// var_dump($data);
echo "<table>\n<tr><th>Name</th><th>Genre</th><th>Artists</th><th>Downloads</th><th>Rating</th></tr>\n";
foreach ($data as $song) {
    usort($song->artists, function($a, $b) {
        return strcmp($a, $b);
    });
    $name = htmlspecialchars($song->name);
    $genre = htmlspecialchars($song->genre);
    $artists = implode(', ', $song->artists);
    echo "<tr><td>$name</td><td>$genre</td><td>$artists</td><td>$song->downloads</td><td>$song->rating</td></tr>\n";
}
echo '</table>';


// <table>
// <tr><th>Name</th><th>Genre</th><th>Artists</th><th>Downloads</th><th>Rating</th></tr>
// <tr><td>V starite Karpati</td><td>Rock</td><td>Nakov</td><td>1029</td><td>4.1</td></tr>
// <tr><td>Rakiichice</td><td>Rock</td><td>Ceco, Joro, Nakov, Petya, Preslav</td><td>453</td><td>4.2</td></tr>
// <tr><td>Sladkarnica Malinka</td><td>Jazz</td><td>Gero, Nakov, Pencho</td><td>728</td><td>4.3</td></tr>
// <tr><td>Krali Marko</td><td>Rock</td><td>Joro, Nakov, Pesho</td><td>1250</td><td>4.8</td></tr>
// </table>



