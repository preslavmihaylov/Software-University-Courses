<html>
    <head>
        <title>Modify String</title>
    </head>
    <body>
        <form action="" method="get">
            <input type="text" name="input" required />
            <input type="radio" name="choice" value="palindrome" id="palindrome" checked />
            <label for="palindrome">Check Palindrome</label>

            <input type="radio" name="choice" value="reverse" id="reverse" />
            <label for="reverse">Reverse String</label>

            <input type="radio" name="choice" value="split" id="split" />
            <label for="split">Split</label>

            <input type="radio" name="choice" value="hash" id="hash" />
            <label for="hash">Hash String</label>

            <input type="radio" name="choice" value="shuffle" id="shuffle" />
            <label for="shuffle">Shuffle String</label>

            <input type="submit" value="Submit" />
        </form>

        <?php
        if (isset($_GET['input']) && isset($_GET['choice'])) {
            $input = $_GET['input'];
            $choice = htmlspecialchars($_GET['choice']);

            switch ($choice) {
                case 'palindrome':
                    checkPalindrome($input);
                    break;
                case 'reverse':
                    echo strrev($input);
                    break;
                case 'split':
                    splitString($input);
                    break;
                case 'hash':
                    echo hash('md5', $input);
                    break;
                case 'shuffle':
                    echo str_shuffle($input);
                    break;
                default:
                    echo 'Invalid choice';
                    break;
            }
        }
        ?>

        <?php
        function checkPalindrome($input) {
            if (strlen($input) == 1) {
                echo $input . ' is a palindrome!';
                return;
            } else {
                for ($index = 0; $index < (int)(strlen($input) / 2); $index++) {
                    if ($input[$index] != $input[strlen($input) - 1 - $index]) {
                        echo $input . ' is not a palindrome!';
                        return;
                    }
                }

                echo $input . ' is a palindrome!';
            }
        }

        function splitString($input) {
            $elements = explode(" ", $input);
            $elements = implode($elements);

            for ($index = 0; $index < strlen($elements); $index++) {
                echo $elements[$index] . ' ';
            }

        }
        ?>
    </body>
</html>