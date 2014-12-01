<html>
    <head>
        <title>Form Data</title>
    </head>
    <body>
        <section>
            <form action="" method="get">
                <input type="text" name="name" placeholder="Name..."/><br/>
                <input type="text" name="age" placeholder="Age..."/><br/>
                <input type="radio" name="sex" value="male">Male<br/>
                <input type="radio" name="sex" value="female">Female<br/>
                <input type="submit"/> <br/>
            </form>

            <?php
            if (isset($_GET["name"]) && isset($_GET["age"])
                && isset($_GET["sex"])) {

                echo "<div>" . 'My name is ' . htmlspecialchars($_GET["name"]) .
                    '. I am ' . htmlentities($_GET["age"]) . ' years old. ' .
                    'I am ' . htmlentities($_GET["sex"]) . "</div>";
            }
            ?>

        </section>
    </body>
</html>