----------------------------------------------------------------------------------------------------
-- Part 1
--------------------------------------------------------------------------------------------------
-- Problem 1.	All Question Titles
--------------------------------------------------------------------------------------------------

-- Display all question titles in ascending order. 

select Title 
from Questions
order by Title asc

--------------------------------------------------------------------------------------------------
-- Problem 2.	Answers in Date Range
--------------------------------------------------------------------------------------------------

-- Find all answers created between 15-June-2012 (00:00:00) and 21-Mart-2013 (23:59:59) sorted by date.

select Content, CreatedOn
from Answers
where CreatedOn BETWEEN '2012-06-15 00:00:00:000' AND '2013-03-21 23:59:59:000'
order by CreatedOn

--------------------------------------------------------------------------------------------------
-- Problem 3.	Users with "1/0" Phones
--------------------------------------------------------------------------------------------------

-- Display usernames and last names along with a column named "Has Phone" 
-- holding "1" or "0" for all users sorted by their last name, then by id.

select Username, 
	LastName, 
	(CASE 
		WHEN PhoneNumber is NULL THEN 0
        ELSE 1
     END) as [Has Phone]
from Users
order by LastName

--------------------------------------------------------------------------------------------------
-- Problem 4.	Questions with their Author
--------------------------------------------------------------------------------------------------

-- Find all questions along with their user sorted by Id. Display the question title and author username. 

select q.Title as [Question Title],
	u.Username as [Author]
from questions q
join Users u on q.UserId = u.Id
order by q.Title asc

--------------------------------------------------------------------------------------------------
-- Problem 5.	Answers with their Question with their Category and User 
--------------------------------------------------------------------------------------------------

select TOP 50
	a.Content as [Answer Content],
	a.CreatedOn as [CreatedOn],
	u.Username as [Answer Author],
	q.Title as [Question Title],
	c.Name as [Category Name]
from Answers a
join Questions q on a.QuestionId = q.Id
join Users u on a.UserId = u.Id
join Categories c on q.CategoryId = c.Id
order by c.Name, u.Username, a.CreatedOn

--------------------------------------------------------------------------------------------------
-- Problem 6.	Category with Questions
--------------------------------------------------------------------------------------------------

-- Find all categories along with their questions sorted by category name and question title. 
-- Display the category name, question title and created on columns. 

select 
	c.Name as [Category], 
	q.Title as [Question],
	q.CreatedOn as [CreatedOn]
from Categories c
left join Questions q on q.CategoryId = c.Id
order by c.Name, q.Title

--------------------------------------------------------------------------------------------------
-- Problem 7.	*Users without PhoneNumber and Questions
--------------------------------------------------------------------------------------------------

-- Find all users that have no phone and no questions sorted by RegistrationDate. Show all user data. 

select 
	u.Id as [Id],
	u.Username as [Username],
	u.FirstName as [FirstName],
	u.PhoneNumber as [PhoneNumber],
	u.RegistrationDate as [RegistrationDate],
	u.Email as [Email]
from Questions q
right join Users u on u.Id = q.UserId
where q.Title is NULL and u.PhoneNumber is NULL
order by u.RegistrationDate
  
----------------------------------------------------------------------------------------------------
-- Problem 8.	Earliest and Latest Answer Date
----------------------------------------------------------------------------------------------------

-- Find the dates of the earliest answer for 2012 year and the latest answer for 2014 year. 

select TOP 1
	( select MIN(CreatedOn) from Answers where DATEPART(YEAR, CreatedOn) = '2012') as [MinDate],
	( select MAX(CreatedOn) from Answers where DATEPART(YEAR, CreatedOn) = '2014') as [MaxDate]
from Answers
	 
----------------------------------------------------------------------------------------------------
-- Problem 9.	Find the last ten answers
----------------------------------------------------------------------------------------------------

-- Find the last 10 answers sorted by date of creation in ascending order. 
-- Display for each ad its content, date and author. 

select * from 
(select TOP 10
	a.Content as [Answer], 
	a.CreatedOn as [CreatedOn], 
	u.Username as [Username]
from Answers a
join Users u on u.Id = a.UserId
order by a.CreatedOn desc) a order by a.CreatedOn asc

----------------------------------------------------------------------------------------------------
-- Problem 10.	Not Published Answers from the First and Last Month
----------------------------------------------------------------------------------------------------

-- Find the answers which is hidden from the first and last month where there are 
-- any published answer, from the last year where there are any published answers. 
-- Display for each ad its answer content, question title and category name. 
-- Sort the results by category name.

select 
	a.Content as [Answer Content],
	q.Title as [Question],
	c.Name as [Category]
from Answers a
join Questions q on a.QuestionId = q.Id
join Categories c on c.Id = q.CategoryId
where 
	( a.IsHidden = 1 AND
	DATEPART(YEAR, a.CreatedOn) = (select DATEPART(YEAR, MAX(CreatedOn)) from Answers) ) AND
	( DATEPART(MONTH, a.CreatedOn) = 
		(
			select DATEPART(MONTH, MIN(CreatedOn))
			from Answers
			where DATEPART(YEAR, CreatedOn) = (select DATEPART(YEAR, MAX(CreatedOn)) from Answers)) OR 
	 DATEPART(MONTH, a.CreatedOn) =
		(
			select DATEPART(MONTH, MAX(CreatedOn))
			from Answers
			where DATEPART(YEAR, CreatedOn) = (select DATEPART(YEAR, MAX(CreatedOn)) from Answers)))
order by c.Name

----------------------------------------------------------------------------------------------------
-- Problem 11.	Answers count for Category
----------------------------------------------------------------------------------------------------

-- Display the count of answers in each category. Sort the results by answers count in descending order. 

select 
	c.Name as [Category], 
	COUNT(a.Id) as [Answers Count]
from Answers a
right join Questions q on a.QuestionId = q.Id
right join Categories c on q.CategoryId = c.Id
group by c.Name
order by COUNT(a.Id) desc

----------------------------------------------------------------------------------------------------
-- Problem 12.	Answers Count by Category and Username
----------------------------------------------------------------------------------------------------

-- Display the count of answers for category and each username. 
-- Sort the results by Answers count, then by Username. 
-- Display only non-zero counts. Display only users with phone number. 

select 
	c.Name as [Category], 
	u.Username as [Username], 
	u.PhoneNumber as [PhoneNumber], 
	COUNT(a.Id) as [Answers Count]
from Answers a
join Users u on a.UserId = u.Id
join Questions q on a.QuestionId = q.Id
join Categories c on q.CategoryId = c.Id
group by c.Name, u.Username, u.PhoneNumber
having COUNT(a.Id) <> 0 AND u.PhoneNumber is not null
order by COUNT(a.Id) desc, u.Username

----------------------------------------------------------------------------------------------------
-- Part 2
----------------------------------------------------------------------------------------------------
-- Problem 13.	Answers for the users from town
----------------------------------------------------------------------------------------------------

-- 1.	Create a table Towns(Id, Name). Use auto-increment for the primary key. 
-- Add a new column TownId in the Users table to link each user to some town (non-mandatory link). 
-- Create a foreign key between the Users and Towns tables.

Create table Towns
	(Id int not null PRIMARY KEY IDENTITY,
	 Name nvarchar(50) not null
	);

alter table Users
	add TownId int;

alter table Users
	add foreign key (TownId) references Towns(Id);

-- 2.	Execute the following SQL script (it should pass without any errors)

INSERT INTO Towns(Name) VALUES ('Sofia'), ('Berlin'), ('Lyon')
UPDATE Users SET TownId = (SELECT Id FROM Towns WHERE Name='Sofia')
INSERT INTO Towns VALUES
('Munich'), ('Frankfurt'), ('Varna'), ('Hamburg'), ('Paris'), ('Lom'), ('Nantes')

-- 3.	Write and execute a SQL command that changes the town to "Paris" for all users with registration date at Friday.

update Users
set TownId = (select MIN(Id) from Towns where Name = 'Paris')
where DATEPART(dw, RegistrationDate) = 6


-- 4.	Write and execute a SQL command that changes the question to “Java += operator” of Answers, 
-- answered at Monday or Sunday in February.

update q
	set q.Title = 'Java += operator'
from Questions q
	join Answers a on a.QuestionId = q.Id
where 
	DATEPART(MONTH, a.CreatedOn) = 2 AND 
	(DATEPART(dw, a.CreatedOn) = 1 OR DATEPART(dw, a.CreatedOn) = 2)

-- 5.	Delete all answers with negative sum of votes.

select a.Id
into #answersToRemove
from Answers a
join Votes v on v.AnswerId = a.Id
group by a.Id
having SUM(v.Value) < 0

delete from Answers
where Id in (select * from #answersToRemove)

delete from Votes
where AnswerId in (select * from #answersToRemove)

drop table #answersToRemove

-- 6.	Add a new question holding the following information: Title="Fetch NULL values in PDO query", 
-- Content="When I run the snippet, NULL values are converted to empty strings. How can fetch NULL values?", 
-- CreatedOn={current date and time}, Owner="darkcat", Category="Databases".

insert into Questions (Title, Content, CreatedOn, UserId, CategoryId)
	values(
		'Fetch NULL values in PDO query',
		'When I run the snippet, NULL values are converted to empty strings. How can fetch NULL values?',
		GETDATE(),
		(select MIN(Id) from Users where Username = 'darkcat'),
		(select MIN(Id) from Categories where Name = 'Databases'));

-- 7.	Find the count of the answers for the users from town. Display the town name, username and answers count. 
-- Sort the results by answers count in descending order, then by username. 

select 
	t.Name as [Town], 
	u.Username as [Username], 
	COUNT(a.Id) as [AnswersCount]
from Answers a
full join Users u on u.Id = a.UserId
full join Towns t on t.Id = u.TownId
group by t.Name, u.Username
order by COUNT(a.Id) desc, u.Username

----------------------------------------------------------------------------------------------------
-- Part 3
----------------------------------------------------------------------------------------------------
-- Problem 14.	Create a View and a Stored Function
----------------------------------------------------------------------------------------------------

-- 1.	Create a view "AllQuestions" in the database that holds information about questions and users (use RIGHT OUTER JOIN)

create view AllQuestions
as
select 
	u.Id as [UId],
	u.Username as [Username],
	u.FirstName as [FirstName],
	u.LastName as [LastName],
	u.Email as [Email],
	u.PhoneNumber as [PhoneNumber],
	u.RegistrationDate as [RegistrationDate],
	q.Id as [QId],
	q.Title as [Title],
	q.Content as [Content],
	q.CategoryId as [CategoryId],
	q.UserId as [UserId],
	q.CreatedOn as [CreatedOn]
from Questions q
right join Users u on u.Id = q.UserId
go

-- Testing
select * from AllQuestions

-- 2.	Using the view above, create a stored function "fn_ListUsersQuestions" that returns a table,
-- holding all users in descending order as first column, along with all titles 
-- of their questions (in ascending order), separated by ", " as second column.


CREATE FUNCTION fn_GetQuestionsByAuthor(@authorId int)
RETURNS nvarchar(max)
	BEGIN
		declare questionCursor CURSOR READ_ONLY FOR
		Select Title from Questions where UserId = @authorId order by Title desc

		OPEN questionCursor
		DECLARE @currentTitle nvarchar(max)
		DECLARE @result nvarchar(max) = NULL
		FETCH NEXT FROM questionCursor INTO @currentTitle

		WHILE @@FETCH_STATUS = 0
		BEGIN
			IF (@result is not NULL)
			BEGIN
				SET @result = @result + ', ' + @currentTitle
			END
			ELSE
				SET @result = '' + @currentTitle

			FETCH NEXT FROM questionCursor 
			INTO @currentTitle
		END

		close questionCursor
		deallocate questionCursor
		RETURN @result
	END
GO

select DISTINCT Username as [UserName], dbo.fn_GetQuestionsByAuthor(UId) as [Questions]
from AllQuestions
order by Username
