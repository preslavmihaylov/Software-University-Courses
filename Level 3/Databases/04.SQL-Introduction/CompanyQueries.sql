-- Problem 4.	Write a SQL query to find all information about all departments (use "SoftUni" database).

------------------------------------------------------------------------------------------------------------------------

SELECT * FROM Departments

------------------------------------------------------------------------------------------------------------------------
-- Problem 5.	Write a SQL query to find all department names.
------------------------------------------------------------------------------------------------------------------------

SELECT Name FROM Departments

------------------------------------------------------------------------------------------------------------------------
-- Problem 6.	Write a SQL query to find the salary of each employee. 
------------------------------------------------------------------------------------------------------------------------

SELECT FirstName, LastName, Salary FROM Employees

------------------------------------------------------------------------------------------------------------------------
-- Problem 7.	Write a SQL to find the full name of each employee. 
------------------------------------------------------------------------------------------------------------------------

SELECT FirstName, MiddleName, LastName FROM Employees

------------------------------------------------------------------------------------------------------------------------
-- Problem 8.	Write a SQL query to find the email addresses of each employee.
------------------------------------------------------------------------------------------------------------------------

SELECT (FirstName + '.' + LastName + '@softuni.bg') AS [Full Email Address] FROM Employees

------------------------------------------------------------------------------------------------------------------------
-- Problem 9.	Write a SQL query to find all different employee salaries. 
------------------------------------------------------------------------------------------------------------------------

SELECT DISTINCT Salary FROM Employees

------------------------------------------------------------------------------------------------------------------------
-- Problem 10.	Write a SQL query to find all information about the employees whose job title is “Sales Representative“. 
------------------------------------------------------------------------------------------------------------------------

SELECT * FROM Employees WHERE JobTitle = 'Sales Representative'

------------------------------------------------------------------------------------------------------------------------
-- Problem 11.	Write a SQL query to find the names of all employees whose first name starts with "SA". 
------------------------------------------------------------------------------------------------------------------------

SELECT FirstName, LastName FROM Employees WHERE FirstName LIKE 'SA%'

------------------------------------------------------------------------------------------------------------------------
-- Problem 12.	Write a SQL query to find the names of all employees whose last name contains "ei". 
------------------------------------------------------------------------------------------------------------------------

SELECT FirstName, LastName FROM Employees WHERE LastName LIKE '%ei%'

------------------------------------------------------------------------------------------------------------------------
-- Problem 13.	Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000]. 
------------------------------------------------------------------------------------------------------------------------

SELECT FirstName, LastName, Salary FROM Employees WHERE Salary >= 20000 AND Salary <= 30000

------------------------------------------------------------------------------------------------------------------------
-- Problem 14.	Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
------------------------------------------------------------------------------------------------------------------------

SELECT FirstName, LastName, Salary FROM Employees WHERE Salary = 25000 OR Salary = 23600 OR Salary = 14000 OR Salary = 12500

------------------------------------------------------------------------------------------------------------------------
-- Problem 15.	Write a SQL query to find all employees that do not have manager.
------------------------------------------------------------------------------------------------------------------------

SELECT FirstName, LastName FROM Employees WHERE ManagerID is NULL

------------------------------------------------------------------------------------------------------------------------
-- Problem 16.	Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.
------------------------------------------------------------------------------------------------------------------------

SELECT FirstName, LastName, Salary FROM Employees WHERE Salary > 50000 ORDER BY Salary DESC

------------------------------------------------------------------------------------------------------------------------
-- Problem 17.	Write a SQL query to find the top 5 best paid employees.
------------------------------------------------------------------------------------------------------------------------

SELECT TOP 5 FirstName, LastName, Salary FROM Employees ORDER BY Salary DESC

------------------------------------------------------------------------------------------------------------------------
-- Problem 18.	Write a SQL query to find all employees along with their address.
------------------------------------------------------------------------------------------------------------------------

SELECT e.FirstName, e.LastName, a.AddressText FROM Employees e
JOIN Addresses a 
ON e.AddressID = a.AddressID

------------------------------------------------------------------------------------------------------------------------
-- Problem 19.	Write a SQL query to find all employees and their address with equijoin.
------------------------------------------------------------------------------------------------------------------------

SELECT e.FirstName, e.LastName, a.AddressText 
FROM Employees e, Addresses a
WHERE e.AddressID = a.AddressID

------------------------------------------------------------------------------------------------------------------------
-- Problem 20.	Write a SQL query to find all employees along with their manager.
------------------------------------------------------------------------------------------------------------------------

SELECT e.FirstName, e.LastName, m.LastName AS [Manager Last Name] 
FROM Employees e
JOIN Employees m
ON e.ManagerID = m.EmployeeID

------------------------------------------------------------------------------------------------------------------------
-- Problem 21.	Write a SQL query to find all employees, along with their manager and their address.
------------------------------------------------------------------------------------------------------------------------

SELECT e.FirstName, e.LastName, a.AddressText, m.LastName AS [Manager Last Name] 
FROM Employees e
JOIN Addresses a
ON e.AddressID = a.AddressID
JOIN Employees m
ON e.ManagerID = m.EmployeeID

------------------------------------------------------------------------------------------------------------------------
-- Problem 22.	Write a SQL query to find all departments and all town names as a single list.
------------------------------------------------------------------------------------------------------------------------

SELECT Name FROM Departments 
UNION
SELECT Name FROM Towns

------------------------------------------------------------------------------------------------------------------------
-- Problem 23.	Write a SQL query to find all the employees and the manager
-- for each of them along with the employees that do not have manager. 
------------------------------------------------------------------------------------------------------------------------

-- Example with left JOIN

SELECT e.FirstName, e.LastName, m.LastName AS [Manager Last Name] FROM Employees e
LEFT JOIN Employees m
ON e.ManagerID = m.EmployeeID

-- Example with Right JOIN

SELECT e.FirstName, e.LastName, m.LastName AS [Manager Last Name] FROM Employees m
RIGHT JOIN Employees e
ON e.ManagerID = m.EmployeeID

------------------------------------------------------------------------------------------------------------------------
-- Problem 24.	Write a SQL query to find the names of all employees from
-- the departments "Sales" and "Finance" whose hire year is between 1995 and 2005.
------------------------------------------------------------------------------------------------------------------------

SELECT e.FirstName, e.LastName, e.HireDate, d.Name FROM Employees e
JOIN Departments d
ON e.DepartmentID = e.DepartmentID
WHERE e.HireDate BETWEEN '19950101 00:00:00.000'
                          AND '20050101 23:59:59.997'

------------------------------------------------------------------------------------------------------------------------