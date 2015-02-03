<?php

// $_GET['luggage'] = 'aaac;aaaa;aaaa;300.85kgC|_|aaab;aaaa;pink couch couch;10.85kgC|_|aaab;living room;pink couch;40.85kgC|_|furniture;bedroom;night table;5.12kgC|_|boxes;kitchen;plates;10.36kgC|_|boxes;kitchen;cups;10.36kgC|_|boxes;kitchen;tableware;7.6kgC|_|boxes;living room;glasses;3.32kgC|_|boxes;living room;dresses;4.32kgC|_|bags;hall;shoes;5.9kgC|_|';
// $_GET['minWeight'] = '20';
// $_GET['maxWeight'] = '500';
// $_GET['typeLuggage'] = ['aaaa', 'aaac', 'aaab'];
// $_GET['room'] = 'aaaa';

$luggage = preg_split('/C\|_\|/', $_GET['luggage']);
$minWeight = (int)$_GET['minWeight']; // !!!
$maxWeight = (int)$_GET['maxWeight']; // !!!
$luggageType = $_GET['typeLuggage'];
$room = htmlspecialchars($_GET['room']);

$data = [];

for ($index = 0; $index < count($luggage); $index++) {
    if (empty($luggage[$index])) {
        continue;
    }

    $elements = preg_split('/\;/', $luggage[$index]);
    for ($el = 0; $el < count($elements); $el++) {
        if (empty($elements[$el])) {
            unset($elements[$el]);
        }
    }

    $elementLuggageType = htmlspecialchars(trim($elements[0]));
    $elementRoom = htmlspecialchars(trim($elements[1]));
    $elementName = htmlspecialchars(trim($elements[2]));

    $elements[3] = preg_replace('/kg/', '', $elements[3]);
    $elements[3] = (double)$elements[3];

    $elementWeight = (int)$elements[3]; // !!!!

    if (in_array($elementLuggageType, $luggageType, true)) {
        if ($elementRoom === $room) {
            if (!isset($data[$elementLuggageType])) {
                $data[$elementLuggageType] = [];
                $data[$elementLuggageType][$elementRoom] = [];
                $data[$elementLuggageType][$elementRoom][] = [];
                $data[$elementLuggageType][$elementRoom][count($data[$elementLuggageType][$elementRoom]) - 1][$elementName] = $elementWeight;
            } else {
                if (!isset($data[$elementLuggageType][$elementRoom])) {
                    $data[$elementLuggageType][$elementRoom] = [];
                    $data[$elementLuggageType][$elementRoom][] = [];
                    $data[$elementLuggageType][$elementRoom][count($data[$elementLuggageType][$elementRoom]) - 1][$elementName] = $elementWeight;
                } else {
                    $data[$elementLuggageType][$elementRoom][] = [];
                    $data[$elementLuggageType][$elementRoom][count($data[$elementLuggageType][$elementRoom]) - 1][$elementName] = $elementWeight;
                }
            }
        }
    }

}

ksort($data);

echo '<ul>';
foreach ($data as $type => $typeValue) {
    $names = [];
    $values = 0;
    for ($index = 0; $index < count($data[$type][$room]); $index++) {
        foreach ($data[$type][$room][$index] as $key => $value) {
            $values += $value;
            $names[] = $key;
        }
    }
    if ($values >= $minWeight && $values <= $maxWeight) {
        echo '<li>';
        echo "<p>$type</p>";

        echo '<ul>';
        foreach ($data[$type] as $room => $roomValue) {
            echo '<li>';
            echo "<p>$room</p>";

            echo '<ul>';
            $names = [];
            $values = 0;
            for ($index = 0; $index < count($data[$type][$room]); $index++) {
                foreach ($data[$type][$room][$index] as $key => $value) {
                    $values += $value;
                    $names[] = $key;
                }
            }
            sort($names);
            $names = implode(', ', $names);
            if ($values >= $minWeight && $values <= $maxWeight) {
                echo '<li>';
                echo "<p>$names" .' - '."${values}kg</p>";
                echo '</li>';
            }

            echo '</ul>';
            echo '</li>';
    }

        echo '</ul>';

        echo '</li>';
    }
}
echo '</ul>';

//<ul>
//    <li>
//        <p></p>
//        <ul>
//            <li>
//                <p></p>
//                <ul>
//                </ul>
//            </li>
//        </ul>
//    </li>
//</ul>
