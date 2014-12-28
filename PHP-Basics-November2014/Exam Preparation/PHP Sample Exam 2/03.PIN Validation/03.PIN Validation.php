<?php

//$_GET['name'] = 'Ana Ivanova';
//$_GET['gender'] = 'male';
//$_GET['pin'] = '4008262703';

date_default_timezone_set('Europe/Sofia');

$name = $_GET['name'];
$gender = $_GET['gender'];
$pin = $_GET['pin'];

$elements = str_split($pin, 2);

switch ($elements[1]) {
    case (int)$elements[1] >= 21 && (int) $elements[1] <= 32:
        $elements[0] = '18' . $elements[0];
        $elements[1] = (string)((int)$elements[1] - 20);
        break;
    case (int)$elements[1] >= 41 && (int) $elements[1] <= 52:
        $elements[0] = '20' . $elements[0];
        $elements[1] = (string)((int)$elements[1] - 40);
        break;
    default:
        $elements[0] = '19' . $elements[0];
        break;
}

if (preg_match('[0-9]', $name) || preg_match('[a-zA-Z]', $pin)) {
    echo '<h2>Incorrect data</h2>';
    return;
}

if (count(explode(' ', $name)) != 2) {
    echo '<h2>Incorrect data</h2>';
    return;
}

$upperLetterCheck = explode(' ', $name);

if (!(preg_match('/[A-Z]/', $upperLetterCheck[0][0]) &&
    preg_match('/[A-Z]/', $upperLetterCheck[1][0]))) {

    echo '<h2>Incorrect data</h2>';
    return;
}

if (!((int)$elements[1] >= 1 && (int)$elements[1] <= 12)
    || !((int)$elements[2] >= 1 && (int)$elements[2] <= 31)) {
    echo '<h2>Incorrect data</h2>';
    return;
}

if (strlen($pin) != 10) {
    echo '<h2>Incorrect data</h2>';
    return;
}

$checksum = $elements[4][1];
$genderCheck = $elements[4][0];

if (!(($genderCheck % 2 == 0 && $gender == 'male') ||
    ($genderCheck % 2 == 1 && $gender == 'female'))) {
    echo '<h2>Incorrect data</h2>';
    return;
}

$checkValues = [2,4,8,5,10,9,7,3,6];

$elements = str_split($pin);

$sum = 0;
for ($index = 0; $index < 9; $index++) {
    $sum += (int)$elements[$index] * $checkValues[$index];
}

$sum %= 11;
if ($sum == 10) {
    $sum = 0;
}

if ($checksum != $sum) {
    echo '<h2>Incorrect data</h2>';
    return;
}

$data = new stdClass();

$data->name = $name;
$data->gender = $gender;
$data->pin = $pin;

echo json_encode($data);

