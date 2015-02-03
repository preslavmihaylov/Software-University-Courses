<?php
    $input = "hello";

    if (gettype($input) == "double" || gettype($input) == "integer") {
        var_dump($input);
    } else {
        echo gettype($input);
    }
?>