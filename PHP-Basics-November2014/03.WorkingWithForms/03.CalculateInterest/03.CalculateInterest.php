<html>
    <head>
        <title>Calculate Interest</title>
    </head>
    <body>
    <?php
    echo '<form action="" method="post">' . "<br/>\n" .
        '<div>Enter Amount <input type="number" name="amount" required></div>' . "<br/>\n" .
        '<input type="radio" name="currency" value="USD" id="USD" checked><label for="USD">USD</label>' . "\n" .
        '<input type="radio" name="currency" value="EUR" id="EUR"><label for="EUR">EUR</label>' . "\n" .
        '<input type="radio" name="currency" value="BGN" id="BGN"><label for="BGN">BGN</label>' . "<br/>\n" .
        '<div>Compound Interest Amount <input type="number" name="interest" required></div>' . "<br/>\n" .
        '<select name="time">' . "\n" .
        '<option value="6">6 Months</option>' . "\n" .
        '<option value="12">1 Year</option>' . "\n" .
        '<option value="24">2 Years</option>' . "\n" .
        '<option value="60">5 Years</option>' . "\n" .
        '</select>' . "\n" .
        '<input type="submit" value="Calculate">' . "\n" .
        '</form>' . "<br/>\n";
    ?>

    <?php
    $_POST['amount'] = 1000;
    $_POST['interest'] = 12;
    $_POST['currency'] = 'USD';
    if (isset($_POST['amount']) && isset($_POST['interest']) &&
        isset($_POST['time'])) {
        $time = (int)$_POST['time'];
        $amount = (double)$_POST['amount'];
        $currency = getCurrency(htmlspecialchars($_POST['currency']));
        if ($currency == 'Invalid') {
            echo 'Invalid currency' . "<br/>\n";
            return;
        }

        $interest = (double)$_POST['interest'];

        $interestPerMonth = $interest / 12;

        for ($index = 0; $index < $time; $index++) {
            $amount += $amount * $interestPerMonth / 100;
        }

        echo $currency . ' ' . round($amount, 2);
    }
    ?>

    <?php
    function getCurrency($currency) {
        switch ($currency) {
            case 'USD':
            return '$';
            break;
            case 'EUR':
                return '€';
                break;
            case 'BGN':
                return 'лв.';
                break;
            default:
                return 'Invalid';
                break;
        }
    }
    ?>
    </body>
</html>