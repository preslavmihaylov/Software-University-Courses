<html>
    <head>
        <title>CV Generator</title>
        <link rel="stylesheet" type="text/css" href="05.CVGenerator.css">
        <script src="05.CVGenerator.js" defer></script>
    </head>
    <body>
    <?php
    echo '<form action="generateCV.php" method="post">' . "<br/>\n" .
        '<fieldset>' . "\n" .
        '<legend>Personal Information</legend>' . "\n" .
        '<input type="text" name="firstName" placeholder="First Name">' . "<br/>\n" .
        '<input type="text" name="lastName" placeholder="Last Name">' . "<br/>\n" .
        '<input type="text" name="email" placeholder="Email">' . "<br/>\n" .
        '<input type="text" name="phone" placeholder="Phone Number">' . "<br/>\n" .
        '<input type="radio" name="gender" value="Female" id="Female" checked>' . "\n" .
        '<label for="Female">Female</label>' . "\n" .
        '<input type="radio" name="gender" value="Male" id="Male">' . "\n" .
        '<label for="Male">Male</label>' . "\n" .
        '<div>Birth Date</div>' . "\n" .
        '<input type="date" name="date" required>' . "<br/>\n" .
        '<div>Nationality</div>' . "\n" .
        '<select name="nationality">' . "\n" .
        '<option value="Bulgarian">Bulgarian</option>' . "\n" .
        '<option value="Indian">Indian</option>' . "\n" .
        '<option value="American">American</option>' . "\n" .
        '</select>' . "\n" .
        '</fieldset>' . "\n" .
        '<fieldset>' . "\n" .
        '<legend>Last Work Position</legend>' . "\n" .
        '<span>Company Name </span>' .
        '<input type="text" name="companyName">' . "<br/>\n" .
        '<span>From </span>' .
        '<input type="date" name="from" required>' . "<br/>\n" .
        '<span>To </span>' .
        '<input type="date" name="to" required>' . "\n" .
        '</fieldset>' . "\n" .
        '<fieldset>' . "\n" .
        '<legend>Computer Skills</legend>' . "\n" .
        '<div>Programming Languages</div>' . "\n" .
        '<div id="parentProgramming">' . "\n" .
        '<div>' . "\n" .
        '<input type="text" name="programmingLangs[]">' . "\n" .
        '<select name="levels[]">' . "\n" .
        '<option value="Beginner">Beginner</option>' . "\n" .
        '<option value="Intermediate">Intermediate</option>' . "\n" .
        '<option value="Professional">Professional</option>' . "\n" .
        '</select>' . "\n" .
        '</div>' . "\n" .
        '</div>' . "\n" .
        '<button type="button" onclick="removeProgrammingLang()">Remove Language</button>' . "\n" .
        '<button type="button" onclick="addProgrammingLang()">Add Language</button>' . "\n" .
        '</fieldset>' . "\n" .
        '<fieldset>' . "\n" .
        '<legend>Other Skills</legend>' . "\n" .
        '<div>Languages</div>' . "\n" .
        '<div id="parentLanguages">' . "\n" .
        '<div>' . "\n" .
        '<input type="text" name="languages[]">' . "\n" .
        '<select name="comprehension[]">' . "\n" .
        '<option value="Beginner" selected>-Comprehension-</option>' . "\n" .
        '<option value="Beginner">Beginner</option>' . "\n" .
        '<option value="Intermediate">Intermediate</option>' . "\n" .
        '<option value="Professional">Professional</option>' . "\n" .
        '</select>' . "\n" .
        '<select name="reading[]">' . "\n" .
        '<option value="Beginner" selected>-Reading-</option>' . "\n" .
        '<option value="Beginner">Beginner</option>' . "\n" .
        '<option value="Intermediate">Intermediate</option>' . "\n" .
        '<option value="Professional">Professional</option>' . "\n" .
        '</select>' . "\n" .
        '<select name="writing[]">' . "\n" .
        '<option value="Beginner" selected>-Writing-</option>' . "\n" .
        '<option value="Beginner">Beginner</option>' . "\n" .
        '<option value="Intermediate">Intermediate</option>' . "\n" .
        '<option value="Professional">Professional</option>' . "\n" .
        '</select>' . "\n" .
        '</div>' . "\n" .
        '</div>' . "\n" .
        '<button type="button" onclick="removeLang()">Remove Language</button>' . "\n" .
        '<button type="button" onclick="addLang()">Add Language</button>' . "\n" .
        '<div>Driver\'s License</div>' . "\n" .
        '<label for="B">B</label>' . '<input type="checkbox" name="B" id="B">' . "\n" .
        '<label for="A">A</label>' . '<input type="checkbox" name="A" id="A">' . "\n" .
        '<label for="C">C</label>' . '<input type="checkbox" name="C" id="C">' . "\n" .
        '</fieldset>' . "\n" .
        '<input type="submit" value="Generate CV">' . "\n" .
        '</form>' . "\n";
    ?>
    </body>
</html>