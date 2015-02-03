<?php

// $_GET['childName'] = 'Petyrcho';
// $_GET['wantedPresent'] = 'Big Truck';
// $_GET['riddles'] = 'What do you call bears with no ears?;What is black and white and red all over?;Why do bears have fur coats?';

$childName = preg_replace('/ /', '-', $_GET['childName']);
$wantedPresent = htmlspecialchars($_GET['wantedPresent']);
$riddles = preg_split('/\;/', $_GET['riddles']);

$pickedRiddle = -1;

for ($index = 0; $index < strlen($childName); $index++) {
    $pickedRiddle++;
    if ($pickedRiddle == count($riddles)) {
        $pickedRiddle = 0;
    }
}

$outputRiddle = htmlspecialchars($riddles[$pickedRiddle]);
$childName = htmlspecialchars($childName);

$output = '$giftOf' . $childName . ' = $[wasChildGood] ? ' . "'$wantedPresent'" . " : '$outputRiddle';";
echo $output;