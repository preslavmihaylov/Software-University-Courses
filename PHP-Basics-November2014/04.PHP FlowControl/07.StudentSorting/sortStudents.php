<html>
    <head>
        <title>Student Sorting</title>

        <link rel="stylesheet" type="text/css" href="StudentSorting.css">
    </head>
    <body>
        <?php
        if (isset($_POST['firstNames']) && isset($_POST['lastNames']) && isset($_POST['emails']) &&
            isset($_POST['scores'])) {

            $firstNames = $_POST['firstNames'];
            $lastNames = $_POST['lastNames'];
            $emails = $_POST['emails'];
            $scores = $_POST['scores'];
            $sortChoice = $_POST['sort'];
            $order = $_POST['order'];

            $data = [];
            for ($index = 0; $index < count($firstNames); $index++) {
                $firstName = htmlspecialchars($firstNames[$index]);
                $lastName = htmlspecialchars($lastNames[$index]);
                $email = htmlspecialchars($emails[$index]);
                $score = htmlspecialchars($scores[$index]);
                $data[] = new stdClass();

                $data[count($data) - 1]->firstName = $firstName;
                $data[count($data) - 1]->lastName = $lastName;
                $data[count($data) - 1]->email = $email;
                $data[count($data) - 1]->score = $score;
            }

            $data = sortByChoice($sortChoice, $order, $data);

            echo '<table>' . "\n" .
                '<tr><th>First Name</th><th>Last Name</th><th>Email</th><th>Exam Score</th></tr>';

            for ($index = 0; $index < count($data); $index++) {
                $firstName = $data[$index]->firstName;
                $lastName = $data[$index]->lastName;
                $email = $data[$index]->email;
                $score = $data[$index]->score;

                echo "<tr><td>$firstName</td><td>$lastName</td><td>$email</td><td>$score</td></tr>";
            }

            echo '</table>';

        }
        ?>

        <?php
        function sortByChoice($property, $order, $data) {
            usort($data, function($a, $b) use ($property, $order)
            {
                if ($order == 'ascending') {
                    if ($property == 'score') {
                        return $a->$property - $b->$property;
                    } else {
                        return strcmp($a->$property, $b->$property);
                    }
                } else {
                    if ($property == 'score') {
                        return $b->$property - $a->$property;
                    } else {
                        return strcmp($b->$property, $a->$property);
                    }
                }

            });

            return $data;
        }
        ?>
    </body>
</html>