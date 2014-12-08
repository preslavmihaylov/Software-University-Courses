<html>
    <head>
        <title>Student Sorting</title>
        <script src="StudentSorting.js"></script>
    </head>
    <body>
    <form action="sortStudents.php" method="post">
        <table id="data">
            <tr><th>First Name:</th><th>Last Name:</th><th>Email:</th><th>Exam Score:</th></tr>
            <tr>
                <td><input type="text" name="firstNames[]" /></td>
                <td><input type="text" name="lastNames[]" /></td>
                <td><input type="text" name="emails[]" /></td>
                <td><input type="number" name="scores[]" /><button type="button" onclick="removeStudent()">-</button></td>
            </tr>
        </table>

        <div>
            <button type="button" onclick="addStudent()">+</button>
            <span>Sort By:</span>
            <select name="sort">
                <option value="firstName">First Name</option>
                <option value="lastName">Last Name</option>
                <option value="email">Email</option>
                <option value="score">Exam Score</option>
            </select>
            <span>Order:</span>
            <select name="order">
                <option value="ascending">Ascending</option>
                <option value="descending">Descending</option>
            </select>
            <input type="submit" value="Submit" />
        </div>

    </form>
    </body>
</html>