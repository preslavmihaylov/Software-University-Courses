<?php

// $_GET['students'] = 'Pesho, aaa@gmail.com, onsite, 400
// Mariika, aaa@gmail.com, online, 350
// Geri, aaa@gmail.com, online, 50
// Pesho, aaa@gmail.com, onsite, 0
// Gosho & Kiro, aaa@aaa.com, onsite, 400
// Mincho, aaa@vremeto.bg, online, 50';
//
// $_GET['column'] = 'email';
// $_GET['order'] = 'descending';

$lines = preg_split('/\r?\n\r?/', $_GET['students']);
$column = $_GET['column'];
$order = $_GET['order'];
// var_dump($lines);
$data = [];
$count = 1;
foreach ($lines as $line) {
    if (empty($line)) {
        continue;
    }
    $elements = explode(',', $line);
    $name = trim($elements[0]);
    $email = trim($elements[1]);
    $type = trim($elements[2]);
    $result = (int)trim($elements[3]);
    $id = $count++;

    $data[] = new stdClass();
    $data[count($data) - 1]->id = $id;
    $data[count($data) - 1]->username = $name;
    $data[count($data) - 1]->email = $email;
    $data[count($data) - 1]->type = $type;
    $data[count($data) - 1]->result = $result;
}

usort($data, function($a, $b) use ($column, $order) {
   if ($column == 'result' || $column == 'id') {
       if ($order == 'ascending') {
           if ($a->$column - $b->$column == 0) {
            return $a->id - $b->id;
           } else {
               return $a->$column - $b->$column;
           }
       } else {
           if ($a->$column - $b->$column == 0) {
               return $b->id - $a->id;
           } else {
               return $b->$column - $a->$column;
           }
       }
   }   else {
       if ($order == 'ascending') {
           if (strcmp($a->$column, $b->$column) == 0) {
               return $a->id - $b->id;
           } else {
               return strcmp($a->$column, $b->$column);
           }
       } else {
           if (strcmp($a->$column, $b->$column) == 0) {
               return $b->id - $a->id;
           } else {
               return strcmp($b->$column, $a->$column);
           }
       }
   }
});

echo '<table><thead><tr><th>Id</th><th>Username</th><th>Email</th><th>Type</th><th>Result</th></tr></thead>';
foreach ($data as $field) {
    $id = $field->id;
    $username = htmlspecialchars($field->username);
    $email = htmlspecialchars($field->email);
    $type = htmlspecialchars($field->type);
    $result = $field->result;
    echo "<tr><td>$id</td><td>$username</td><td>$email</td><td>$type</td><td>$result</td></tr>";
}
echo '</table>';

