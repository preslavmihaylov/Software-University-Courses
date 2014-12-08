<html>
    <head>
        <title>Generated CV</title>
        <link rel="stylesheet" type="text/css" href="05.CVGenerator.css">
    </head>
    <body>

    <?php
    $firstName = htmlspecialchars($_POST['firstName']);
    $lastName = htmlspecialchars($_POST['lastName']);
    $email = htmlspecialchars($_POST['email']);
    $phone = htmlspecialchars($_POST['phone']);
    $gender = htmlspecialchars($_POST['gender']);
    $birthDate = htmlspecialchars($_POST['date']);
    $nationality = htmlspecialchars($_POST['nationality']);
    $companyName = htmlspecialchars($_POST['companyName']);
    $from = htmlspecialchars($_POST['from']);
    $to = htmlspecialchars($_POST['to']);
    $programmingLangs = $_POST['programmingLangs'];
    $levels = $_POST['levels'];
    $languages = $_POST['languages'];
    $comprehension = $_POST['comprehension'];
    $reading = $_POST['reading'];
    $writing = $_POST['writing'];

    if (!preg_match('/[a-zA-Z]{2,20}/', $firstName) || !preg_match('/[a-zA-Z]{2,20}/', $lastName)) {
        echo 'Invalid first or last name';
        return;
    }

    if (!preg_match('/\w+@\w+\.[a-zA-Z]+/', $email)) {
        echo 'Invalid email';
        return;
    }

    if (!preg_match('/[0-9\+\- ]+/', $phone)) {
        echo 'Invalid phone number';
        return;
    }

    if (!preg_match('/[a-zA-Z0-9]{2,20}/', $companyName)) {
        echo 'Invalid company name';
        return;
    }

    foreach ($programmingLangs as $lang) {
        if (!preg_match('/[a-zA-Z]{2,20}/', $lang)) {
            echo 'Invalid programming language';
            return;
        }
    }

    foreach ($languages as $lang) {
        if (!preg_match('/[a-zA-Z]{2,20}/', $lang)) {
            echo 'Invalid language';
            return;
        }
    }


    // Personal Information
    echo '<table>' . "\n" .
        '<tr><th colspan="2">Personal Information</th></tr>' . "\n" .
        '<tr><td>First Name</td>' . "<td>$firstName</td></tr>" . "\n" .
        '<tr><td>Last Name</td>' . "<td>$lastName</td></tr>" . "\n" .
        '<tr><td>Email</td>' . "<td>$email</td></tr>" . "\n" .
        '<tr><td>Phone</td>' . "<td>$phone</td></tr>" . "\n" .
        '<tr><td>Gender</td>' . "<td>$gender</td></tr>" . "\n" .
        '<tr><td>Birth Date</td>' . "<td>$birthDate</td></tr>" . "\n" .
        '<tr><td>Nationality</td>' . "<td>$nationality</td></tr>" . "\n" .
        '</table>' . "\n";


    // Last Work Position
    echo '<table>' . "\n" .
        '<tr><th colspan="2">Last Work Position</th></tr>' . "\n" .
        '<tr><td>Company Name</td>' . "<td>$companyName</td></tr>" . "\n" .
        '<tr><td>From</td>' . "<td>$from</td></tr>" . "\n" .
        '<tr><td>To</td>' . "<td>$to</td></tr>" . "\n" .
        '</table>' . "\n";


    // Computer Skills
    echo '<table>' . "\n" .
        '<tr><th colspan="2">Computer Skills</th></tr>' . "\n" .
        '<tr><td>Programming Languages</td>' . "<td>" . "\n";

    echo '<table>' . "\n" .
        '<tr><th>Language</th><th>Skill Level</th></tr>' . "\n";

    for ($index = 0; $index < count($programmingLangs); $index++) {
        $programmingLang = htmlspecialchars($programmingLangs[$index]);
        $level = htmlspecialchars($levels[$index]);
        echo "<tr><td>$programmingLang</td><td>$level</td></tr>" . "\n";
    }

    echo '</table>' . "\n" .
        '</td></tr>' . "\n" .
        '</table>' . "\n";


    // Other Skills
    echo '<table>' . "\n" .
        '<tr><th colspan="2">Other Skills</th></tr>' . "\n" .
        '<tr><td>Languages</td>' . "<td>" . "\n";

    echo '<table>' . "\n" .
        '<tr><th>Language</th><th>Comprehension</th><th>Reading</th><th>Writing</th></tr>' . "\n";

    for ($index = 0; $index < count($languages); $index++) {
        $language = htmlspecialchars($languages[$index]);
        $currentComprehension = htmlspecialchars($comprehension[$index]);
        $currentReading = htmlspecialchars($reading[$index]);
        $currentWriting = htmlspecialchars($writing[$index]);
        echo "<tr><td>$language</td><td>$currentComprehension</td>" .
            "<td>$currentReading</td><td>$currentWriting</td></tr>" . "\n";
    }

    echo '</table>' . "\n" .
        '</td></tr>' . "\n";

    // Driver's License

    $driverLicense = [];

    if (isset($_POST['B'])) {
        $driverLicense[] = 'B';
    }
    if (isset($_POST['A'])) {
        $driverLicense[] = 'A';
    }
    if (isset($_POST['C'])) {
        $driverLicense[] = 'C';
    }


    $output = implode(', ', $driverLicense);
    echo '<tr><td>Driver\'s License</td>' . "<td>$output</td></tr>" . "\n" .
        '</table>' . "\n";

    ?>

    </body>
</html>