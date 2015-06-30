--------------------------------------------------------------------------------------------------------
-- Problem 1.	Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.
--------------------------------------------------------------------------------------------------------

SELECT FirstName,LastName,Salary
FROM Employees
WHERE Salary =
(SELECT MIN(SALARY) FROM Employees)

--------------------------------------------------------------------------------------------------------
-- Problem 2.	Write a SQL query to find the names and salaries of the employees that have a salary
-- that is up to 10% higher than the minimal salary for the company.
--------------------------------------------------------------------------------------------------------

SELECT FirstName,LastName,Salary
FROM Employees
WHERE Salary <
(SELECT MIN(SALARY)+((Min(salary)/0.90)-min(salary))  FROM Employees)

--------------------------------------------------------------------------------------------------------
-- Problem 3.	Write a SQL query to find the full name, salary and department
-- of the employees that take the minimal salary in their department.
--------------------------------------------------------------------------------------------------------

SELECT FirstName + ' ' + LastName AS [Full Name], Name, Salary
FROM Employees e
Join Departments d
ON e.DepartmentID = d.DepartmentID
WHERE Salary = 
  (SELECT MIN(Salary) FROM Employees 
   WHERE DepartmentID = e.DepartmentID)

--------------------------------------------------------------------------------------------------------
-- Problem 4.	Write a SQL query to find the average salary in the department #1.
--------------------------------------------------------------------------------------------------------

SELECT AVG(Salary) AS AverageSalary 
FROM Employees
WHERE DepartmentID = 1

--------------------------------------------------------------------------------------------------------
-- Problem 5.	Write a SQL query to find the average salary in the "Sales" department.
--------------------------------------------------------------------------------------------------------

SELECT AVG(Salary) AS [Sales Employees Count]
FROM Employees e
Join Departments d
On e.DepartmentID =d.DepartmentID
Where d.Name = 'Sales'

--------------------------------------------------------------------------------------------------------
-- Problem 6.	Write a SQL query to find the number of employees in the "Sales" department.
--------------------------------------------------------------------------------------------------------

SELECT Count(FirstName) AS AverageSalary 
FROM Employees e
JOIN Departments d
ON e.DepartmentID =d.DepartmentID
WHERE d.Name = 'Sales'

--------------------------------------------------------------------------------------------------------
-- Problem 7.	Write a SQL query to find the number of all employees that have manager.
--------------------------------------------------------------------------------------------------------

SELECT Count(EmployeeID) AS [Employees with managers]
FROM Employees e
JOIN Departments d
ON e.DepartmentID =d.DepartmentID
WHERE.ManagerID IS NOT NULL

--------------------------------------------------------------------------------------------------------
-- Problem 8.	Write a SQL query to find the number of all employees that have no manager.
--------------------------------------------------------------------------------------------------------

SELECT Count(EmployeeID) AS [Employees without managers]
FROM Employees e
Join Departments d
On e.DepartmentID =d.DepartmentID
Where e.ManagerID IS NULL

--------------------------------------------------------------------------------------------------------
-- Problem 9.	Write a SQL query to find all departments and the average salary for each of them.
--------------------------------------------------------------------------------------------------------

SELECT d.Name , AVG(Salary) AS AvarageSalary
FROM Departments d
JOIN Employees e
ON e.DepartmentID = d.DepartmentID
GROUP by d.Name

--------------------------------------------------------------------------------------------------------
-- Problem 10.	Write a SQL query to find the count of all employees in each department and for each town. 
--------------------------------------------------------------------------------------------------------

SELECT t.Name,d.Name,COUNT(EmployeeID) AS EmployeesCount
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
JOIN Addresses a
ON e.AddressID = a.AddressID
JOIN Towns t
ON a.TownID = t.TownID
WHERE d.DepartmentID =d.DepartmentID
group by t.Name,d.Name

--------------------------------------------------------------------------------------------------------
-- Problem 11.	Write a SQL query to find all managers that have exactly 5 employees.
--------------------------------------------------------------------------------------------------------

SELECT m.FirstName,m.LastName,COUNT(e.EmployeeID) as [Employees Count]
FROM Employees e
JOIN Employees m
ON m.ManagerID = e.ManagerID
Group by m.FirstName,m.LastName
Having COUNT(e.EmployeeID) = 5 

--------------------------------------------------------------------------------------------------------
-- Problem 12.	Write a SQL query to find all employees along with their managers.
--------------------------------------------------------------------------------------------------------

select e.LastName as [Emp Last], ISNULL(m.LastName, '(no manager)') as [Man Last]
from Employees e
left join Employees m on e.ManagerID = m.EmployeeID

--------------------------------------------------------------------------------------------------------
-- Problem 13.	Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. 
--------------------------------------------------------------------------------------------------------

SELECT FirstName,LastName
FROM Employees
WHERE LEN(LastName) = 5

--------------------------------------------------------------------------------------------------------
-- Problem 14.	Write a SQL query to display the
-- current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds". 
--------------------------------------------------------------------------------------------------------

SELECT FORMAT( GETDATE(), 'dd.MM.yyyy hh:mm:ss:fff', 'en-US' )

--------------------------------------------------------------------------------------------------------
-- Problem 15.	Write a SQL statement to create a table Users. 
--------------------------------------------------------------------------------------------------------

-- DROP TABLE USERS

CREATE TABLE Users
	(UserID int NOT NULL PRIMARY KEY IDENTITY,
	 Username nvarchar(50) NOT NULL,
	 FullName nvarchar(50) NULL,
	 Password nvarchar(50) NULL,
	 LastLoginTime smalldatetime NULL DEFAULT GETDATE(),
	 UNIQUE(Username),
	 CHECK(LEN(Password) >= 5))
GO

--------------------------------------------------------------------------------------------------------
-- Problem 16.	Write a SQL statement to create a view that displays
-- the users from the Users table that have been in the system today.
--------------------------------------------------------------------------------------------------------

CREATE VIEW
AS
select Username, LastLoginTime
FROM Users
WHERE DATEPART(YEAR, LastLoginTime) = DATEPART(YEAR, GETDATE()) AND
	  DATEPART(MONTH, LastLoginTime) = DATEPART(MONTH, GETDATE()) AND
	  DATEPART(DAY, LastLoginTime) = DATEPART(DAY, GETDATE())

--------------------------------------------------------------------------------------------------------
-- Problem 17.	Write a SQL statement to create a table Groups. 
--------------------------------------------------------------------------------------------------------

-- DROP TABLE GROUPS

CREATE TABLE Groups
	(GroupID int NOT NULL PRIMARY KEY IDENTITY,
	 Name nvarchar(50) NOT NULL,
	 UNIQUE(Name))
GO

--------------------------------------------------------------------------------------------------------
-- Problem 18.	Write a SQL statement to add a column GroupID to the table Users.
--------------------------------------------------------------------------------------------------------

alter table Users
add GroupID int NOT NULL

ALTER TABLE Users
ADD FOREIGN KEY (GroupID)
REFERENCES Groups(GroupID) 

--------------------------------------------------------------------------------------------------------
-- Problem 19.	Write SQL statements to insert several records in the Users and Groups tables.
--------------------------------------------------------------------------------------------------------

-- delete from users where 1 = 1
-- delete from groups where 1 = 1
-- select * from groups
-- select * from users

insert into Groups (Name) values ('Admins')
insert into Groups (Name) values ('Normal')
insert into Groups (Name) values ('VIP')

insert into Users (Username, Password, GroupID) 
	values ('pesho', 'peshkata', 1)
insert into Users (Username, Password, GroupID) 
	values ('tosho', 'toshkata', 1)
insert into Users (Username, Password, GroupID) 
	values ('bosho', 'boshkata', 2)
insert into Users (Username, Password, GroupID) 
	values ('kesho', 'keshkata', 2)
insert into Users (Username, Password, GroupID) 
	values ('tedo', 'tedoshkata', 3)

--------------------------------------------------------------------------------------------------------
-- Problem 20.	Write SQL statements to update some of the records in the Users and Groups tables.
--------------------------------------------------------------------------------------------------------

update groups
set Name = 'Cool Admins'
where Name = 'Admins'

update groups
set Name = 'Normal Users'
where GroupID = 2

update users
set Password = 'toshkata1'
where Password = 'toshkata'

update users
set Password = 'peshkata1'
where Username = 'pesho'

select * from users

--------------------------------------------------------------------------------------------------------
-- Problem 21.	Write SQL statements to delete some of the records from the Users and Groups tables.
--------------------------------------------------------------------------------------------------------

delete from users
where GroupID = 3

delete from groups
where GroupID = 3

--------------------------------------------------------------------------------------------------------
-- Problem 22.	Write SQL statements to insert in the Users table the names of all employees from the Employees table.
--------------------------------------------------------------------------------------------------------

-- I am using a different specification for the username and password 
-- since taking the first letter of the first name and the rest of the last name produces duplicate usernames

insert into Users
(Username, Password, FullName, LastLoginTime, GroupID)
select 
	LOWER(FirstName + LastName),
	LOWER(FirstName + LastName), 
	FirstName + ' ' + LastName,
	NULL,
	2 
from Employees

-- This was my first Try. Keeping it because of the hard work I put in it.
insert into Users
(Username, Password, FullName, LastLoginTime, GroupID)
select 
	LEFT(
	Lower(LEFT(FirstName, 1)) + LOWER(LastName) + '11111', 
	IIF(
		LEN(Lower(LEFT(FirstName, 1)) + LOWER(LastName)) >= 5,
		    LEN(Lower(LEFT(FirstName, 1)) + LOWER(LastName)),
			5)
	), 
	LEFT(
	Lower(LEFT(FirstName, 1)) + LOWER(LastName) + '11111', 
	IIF(
		LEN(Lower(LEFT(FirstName, 1)) + LOWER(LastName)) >= 5,
		    LEN(Lower(LEFT(FirstName, 1)) + LOWER(LastName)),
			5)
	), 
	FirstName + ' ' + LastName,
	NULL,
	2 
from Employees

--------------------------------------------------------------------------------------------------------
-- Problem 23.	Write a SQL statement that changes the password to NULL 
-- for all users that have not been in the system since 10.03.2010.
--------------------------------------------------------------------------------------------------------

update users 
set password = NULL
where LastLoginTime < '10/03/2010'

--------------------------------------------------------------------------------------------------------
-- Problem 24.	Write a SQL statement that deletes all users without passwords (NULL password).
--------------------------------------------------------------------------------------------------------

delete from users
where password is null

--------------------------------------------------------------------------------------------------------
-- Problem 25.	Write a SQL query to display the average employee salary by department and job title.
--------------------------------------------------------------------------------------------------------

select d.Name as [Department Name], e.JobTitle, AVG(e.Salary) as [Average Salary], Count(e.EmployeeID) as [Count]
from Employees e
join Departments d on d.DepartmentID = e.DepartmentID
group by d.Name, e.JobTitle

--------------------------------------------------------------------------------------------------------
-- Problem 26.	Write a SQL query to display the minimal employee
-- salary by department and job title along with the name of some of the employees that take it.
--------------------------------------------------------------------------------------------------------

select d.Name as [Department Name], 
	e.JobTitle,  
	MIN(e.FirstName) as [First Name], 
	MIN(e.Salary) as [Min Salary]
from Employees e
join Departments d on d.DepartmentID = e.DepartmentID
group by d.Name, e.JobTitle

--------------------------------------------------------------------------------------------------------
-- Problem 27.	Write a SQL query to display the town where maximal number of employees work.
--------------------------------------------------------------------------------------------------------

select TOP 1 t.Name, COUNT(e.EmployeeID)
from Employees e
join Addresses a on a.AddressID = e.AddressID
join Towns t on t.TownID = a.TownID
group by t.Name
order by COUNT(e.EmployeeID) DESC

--------------------------------------------------------------------------------------------------------
-- Problem 28.	Write a SQL query to display the number of managers from each town.
--------------------------------------------------------------------------------------------------------
select COUNT(Managers.ManagerID) as [Count], Managers.Town
from
	(select m.EmployeeID as [ManagerID], t.Name as [Town]
	from Employees e
	join Employees m on e.ManagerID = m.EmployeeID
	join Addresses a on a.AddressID = m.AddressID
	join Towns t on t.TownID = a.TownID
	group by t.Name, m.EmployeeID) 
as Managers
group by Managers.Town
order by Count DESC

--------------------------------------------------------------------------------------------------------
-- Problem 29.	Write a SQL to create table WorkHours to store work reports for each employee.
--------------------------------------------------------------------------------------------------------

Create table WorkHours
	(ReportID int NOT NULL PRIMARY KEY IDENTITY,
	 EmployeeID int NOT NULL,
	 TaskDate smalldatetime DEFAULT GETDATE(),
	 Task nvarchar(50) NOT NULL,
	 Hours int NOT NULL,
	 Comments nvarchar(50) NULL,
	 foreign key (EmployeeID) references Employees(EmployeeID))
GO

--------------------------------------------------------------------------------------------------------
-- Problem 30.	Issue few SQL statements to insert, update and delete of some data in the table.
--------------------------------------------------------------------------------------------------------

insert into WorkHours (EmployeeID, Task, Hours, Comments)
	values (1, 'Cleaning', 5, 'Cool guy')
insert into WorkHours (EmployeeID, Task, Hours, Comments)
	values (2, 'Writing', 4, 'Cool guy')
insert into WorkHours (EmployeeID, Task, Hours, Comments)
	values (3, 'Crying', 3, 'Cool guy')
insert into WorkHours (EmployeeID, Task, Hours, Comments)
	values (4, 'Helping', 2, 'Cool guy')
insert into WorkHours (EmployeeID, Task, Hours, Comments)
	values (5, 'Helping', 3, 'Cool guy')
insert into WorkHours (EmployeeID, Task, Hours, Comments)
	values (6, 'Cleaning', 4, 'Cool guy')

update WorkHours
set EmployeeID = 11
where EmployeeID = 1

update WorkHours
set EmployeeID = 12
where EmployeeID = 2

update WorkHours
set EmployeeID = 13
where EmployeeID = 3

delete from WorkHours
where EmployeeID = 1

delete from WorkHours
where EmployeeID = 13

--------------------------------------------------------------------------------------------------------
-- Problem 31.	Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
--------------------------------------------------------------------------------------------------------

create table WorkHoursLog
	(LogID int NOT NULL PRIMARY KEY IDENTITY,
	 PerformedCommand nvarchar(15) NOT NULL,
	 OldEmployeeID int NULL,
	 OldTaskDate smalldatetime NULL,
	 OldTask nvarchar(50) NULL,
	 OldHours int NULL,
	 OldComments ntext NULL,
	 NewEmployeeID int NULL,
	 NewTaskDate smalldatetime NULL,
	 NewTask nvarchar(50) NULL,
	 NewHours int NULL,
	 NewComments ntext NULL)
GO

CREATE TRIGGER ReportLogsInsert
ON WorkHours
AFTER INSERT
AS 
INSERT INTO WorkHoursLog(PerformedCommand,
	NewEmployeeID, 
	NewTaskDate, NewTask, 
	NewHours, 
	NewComments)
select 'INSERT', EmployeeID, TaskDate, Task, Hours, Comments
	from inserted
GO

CREATE TRIGGER ReportLogsDelete
ON WorkHours
AFTER DELETE
AS 
INSERT INTO WorkHoursLog(PerformedCommand,
	OldEmployeeID, 
	OldTaskDate, 
	OldTask, 
	OldHours, 
	OldComments)
select 'DELETE', EmployeeID, TaskDate, Task, Hours, Comments
	from deleted
GO

CREATE TRIGGER ReportLogsUpdate
ON WorkHours
AFTER UPDATE
AS 
INSERT INTO WorkHoursLog(PerformedCommand,
	OldEmployeeID, 
	OldTaskDate, 
	OldTask, 
	OldHours, 
	OldComments,
	NewEmployeeID, 
	NewTaskDate, 
	NewTask, 
	NewHours, 
	NewComments)
select 'UPDATE', 
	d.EmployeeID, d.TaskDate, d.Task, d.Hours, d.Comments, 
	i.EmployeeID, i.TaskDate, i.Task, i.Hours, i.Comments
from deleted d
join inserted i on i.ReportID = d.ReportID
GO

--------------------------------------------------------------------------------------------------------
-- Problem 32.	Start a database transaction, delete all employees from the 'Sales' department along
-- with all dependent records from the pother tables. At the end rollback the transaction.
--------------------------------------------------------------------------------------------------------

begin tran

alter table Departments nocheck constraint all

delete 
from Employees
where DepartmentID = 
	(select MIN(d.DepartmentID)
	from Employees e
	join Departments d on d.DepartmentID = e.DepartmentID
	where d.Name = 'Sales')

alter table Departments check constraint all

-- Check whether the data is deleted or not
select d.Name, d.DepartmentID
from Employees e
join Departments d on d.DepartmentID = e.DepartmentID
where d.Name = 'Sales'

rollback

--------------------------------------------------------------------------------------------------------
-- Problem 33.	Start a database transaction and drop the table EmployeesProjects.
--------------------------------------------------------------------------------------------------------

begin tran

drop table EmployeesProjects

rollback

-- select * from EmployeesProjects

--------------------------------------------------------------------------------------------------------
-- Problem 34.	Find how to use temporary tables in SQL Server.
--------------------------------------------------------------------------------------------------------

select *
into TemporaryEmployeesProjects
from EmployeesProjects

drop table EmployeesProjects

select *
into EmployeesProjects
from TemporaryEmployeesProjects

drop table TemporaryEmployeesProjects