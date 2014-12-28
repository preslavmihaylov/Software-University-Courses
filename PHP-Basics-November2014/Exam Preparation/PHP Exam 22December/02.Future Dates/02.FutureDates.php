<?php

date_default_timezone_set('Europe/Sofia');

// $_GET['numbersString'] = 'Th1s a12# is _a43$ just %a2^ random5text!!a1!';
//
// $_GET['dateString'] = '2000-03-20-1900-02-01-';

$numbersString = $_GET['numbersString'];
$dateString = $_GET['dateString'];

preg_match_all('/[^a-zA-Z0-9]([0-9]+)[^a-zA-Z0-9]/', $numbersString, $numbers);

$sum = 0;
for ($index = 0; $index < count($numbers[1]); $index++) {
    $sum += (int)$numbers[1][$index];
}

$sum = strrev((string)$sum);
// var_dump($sum);

preg_match_all('/([0-9]{4}-[0-9]{2}-[0-9]{2})/', $dateString, $dates);
// var_dump($dates);

if (empty($dates[0])) {
    echo '<p>No dates</p>';
    return;
}

echo '<ul>';
for ($index = 0; $index < count($dates[1]); $index++) {
    $date = date_create_from_format('Y-m-d', $dates[1][$index]);
    // var_dump($date);
    date_add($date, date_interval_create_from_date_string($sum . ' days'));
    $output = date_format($date, 'Y-m-d');
    echo "<li>$output</li>";
}
echo '</ul>';