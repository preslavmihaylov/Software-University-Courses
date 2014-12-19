<html>
    <head>
        <title>Sidebar Builder</title>

        <style>
            aside {
                float: right;
                margin: 50px;
                width: 200px;
                border-radius: 25px;
                color: white;
                display: block;
                background: darkcyan;
                border: 1px solid black;
            }

            h1 {
                margin: 20px;
            }
        </style>
    </head>
    <body>
        <form action="" method="get">
            <div>Categories: <input type="text" name="categories"/></div>
            <div>Tags: <input type="text" name="tags"/></div>
            <div>Months: <input type="text" name="months"/></div>
            <input type="submit"/>
        </form>

        <?php
        if (isset($_GET['categories']) && isset($_GET['tags']) && isset($_GET['months'])):
            $categories = preg_split('/\W+/', htmlspecialchars($_GET['categories']), -1, PREG_SPLIT_NO_EMPTY);
            $tags = preg_split('/\W+/', htmlspecialchars($_GET['tags']), -1, PREG_SPLIT_NO_EMPTY);
            $months = preg_split('/\W+/', htmlspecialchars($_GET['months']), -1, PREG_SPLIT_NO_EMPTY);

        ?>
          <aside>
              <h1>Categories:</h1>
              <ul>
                  <?php
                  foreach ($categories as $category) {
                      echo "<li>$category</li>";
                  }
                  ?>
              </ul>
          </aside>
        <aside>
            <h1>Tags:</h1>
            <ul>
                <?php
                foreach ($tags as $tag) {
                    echo "<li>$tag</li>";
                }
                ?>
            </ul>
        </aside>
        <aside>
            <h1>Months:</h1>
            <ul>
                <?php
                foreach ($months as $month) {
                    echo "<li>$month</li>";
                }
                ?>
            </ul>
        </aside>

        <?php
        endif;
        ?>
    </body>
</html>