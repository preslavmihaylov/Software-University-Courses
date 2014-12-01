<html>
    <head>
        <title>Information Table</title>

        <style>
            table {
                border-collapse: collapse;
            }

            table * {
                border: 1px solid black;
            }

            td {
                width: 100px;
                height: 50px;
                padding-left: 20px;
            }
        </style>
    </head>

    <body>
        <table>
            <?php
            $name = 'Pesho';
            $phone = '0882-321-423';
            $age = 24;
            $address = 'Hadji Dimitur';

            echo "<tr>\n" .
                '<td style="background: orange; font-weight: bold; ">Name</td>' .
                "<td>$name</td>\n" .
                "</tr>\n";

            echo "<tr>\n" .
                '<td style="background: orange; font-weight: bold; ">Phone number</td>' .
                "<td>$phone</td>\n" .
                "</tr>\n";

            echo "<tr>\n" .
                '<td style="background: orange; font-weight: bold; ">Age</td>' .
                "<td>$age</td>\n" .
                "</tr>\n";

            echo "<tr>\n" .
                '<td style="background: orange; font-weight: bold; ">Address</td>' .
                "<td>$address</td>\n" .
                "</tr>\n";
            ?>
        </table>
    </body>
</html>