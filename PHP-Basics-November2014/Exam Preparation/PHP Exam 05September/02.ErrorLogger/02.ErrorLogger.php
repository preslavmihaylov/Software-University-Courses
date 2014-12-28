<?php

// $_GET['errorLog'] = 'Strange Exception in thread "main" here in at Java_Basics.calc(Java_Basics.java:22) what does it mean? :
// Exception in thread "main" java.lang.ArrayIndexOutOfBoundsException: 1
//     at Java_Basics.calc(Java_Basics.java:22)
//     at Java_Basics.main(Java_Basics.java:13)
//
//     Exception in thread "main" java.lang.oracle.sun.NullPointerException: 4
//     at Java_Basics.getResources(Java_Basics.java:55)
//     at Java_Basics.calc(Java_Basics.java:22)
//     at Java_Basics.main(Java_Basics.java:13)
// sudo chmod 777 -R /path/to/Dir/Java_Basics.java';

$errorLog = $_GET['errorLog'];

$pattern = '/Exception in thread "[a-zA-Z]+" [a-zA-Z\.]+\.([a-zA-Z]+):[\s\d]+at [^\.]+.([^(]+)\(([^:]+):([0-9]+)\)/';
preg_match_all($pattern, $errorLog, $matches);

// var_dump($matches);

echo '<ul>';
for ($inner = 0; $inner < count($matches[0]); $inner++) {
    $data = [];
    for ($outer = 1; $outer < count($matches); $outer++) {
        $data[] = $matches[$outer][$inner];
    }

    $exception = htmlspecialchars($data[0]);
    $method = htmlspecialchars($data[1]);
    $filename = htmlspecialchars($data[2]);
    $line = htmlspecialchars($data[3]);

    echo "<li>line <strong>$line</strong> - <strong>$exception</strong> in <em>$filename:$method</em></li>";
}

echo '</ul>';

// <ul><li>line <strong>22</strong> - <strong>ArrayIndexOutOfBoundsException</strong> in <em>Java_Basics.java:calc</em></li></ul>