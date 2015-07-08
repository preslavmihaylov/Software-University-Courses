Use [Ads]
GO

------------------------------------------------------------------------------------------------------
-- Problem 1.	All Ad Titles
------------------------------------------------------------------------------------------------------

select Title
from Ads
order by Title

------------------------------------------------------------------------------------------------------
-- Problem 2.	Ads in Date Range
------------------------------------------------------------------------------------------------------

select Title, Date
from Ads
where Date > '2014-12-26 00:00:00:000' AND Date < '2015-01-01 23:59:59:000'
order by Date

------------------------------------------------------------------------------------------------------
-- Problem 3.	* Ads with "Yes/No" Images
------------------------------------------------------------------------------------------------------

CREATE FUNCTION dbo.fn_HasImage (@ImageURL nvarchar(50))
RETURNS nvarchar(50)
AS
BEGIN
	IF (@ImageURL is NULL)
	BEGIN
		RETURN N'no'
	END

	RETURN N'yes'
END
GO

Select Title, Date, dbo.fn_HasImage(ImageDataURL) as [Has Image]
from Ads
ORDER BY Id ASC

------------------------------------------------------------------------------------------------------
-- Problem 4.	Ads without Town, Category or Image
------------------------------------------------------------------------------------------------------

select * from Ads
where TownId is NULL OR CategoryId is NULL OR ImageDataURL is NULL
order by Id

------------------------------------------------------------------------------------------------------
-- Problem 5.	Ads with Their Town
------------------------------------------------------------------------------------------------------

select a.Title, t.Name as [Town]
from Ads a
left join Towns t on t.Id = a.TownId
order by a.Id

------------------------------------------------------------------------------------------------------
-- Problem 6.	Ads with Their Category, Town and Status
------------------------------------------------------------------------------------------------------

select a.Title, c.Name as [CategoryName], t.Name as [TownName], s.Status as [Status] 
from Ads a
left join Towns t on t.Id = a.TownId
left join Categories c on c.Id = a.CategoryId
left join AdStatuses s on s.Id = a.StatusId
order by a.Id

------------------------------------------------------------------------------------------------------
-- Problem 7.	Filtered Ads with Category, Town and Status
------------------------------------------------------------------------------------------------------

select a.Title, c.Name as [CategoryName], t.Name as [TownName], s.Status as [Status] 
from Ads a
join Towns t on t.Id = a.TownId
join Categories c on c.Id = a.CategoryId
join AdStatuses s on s.Id = a.StatusId
where s.Status = 'Published' AND 
	(t.Name = 'Sofia' OR t.Name = 'Blagoevgrad' OR t.Name = 'Stara Zagora')
order by a.Title

------------------------------------------------------------------------------------------------------
-- Problem 8.	Earliest and Latest Ads
------------------------------------------------------------------------------------------------------

select MIN(Date) as [MinDate], MAX(Date) as [MaxDate]
from Ads

------------------------------------------------------------------------------------------------------
-- Problem 9.	Latest 10 Ads
------------------------------------------------------------------------------------------------------

select TOP 10 a.Title, a.Date, s.Status
from Ads a
join AdStatuses s on s.Id = a.StatusId
order by a.Date desc

------------------------------------------------------------------------------------------------------
-- Problem 10.	Not Published Ads from the First Month
------------------------------------------------------------------------------------------------------



select a.Id, a.Title, a.Date, s.Status
from Ads a
join AdStatuses s on s.Id = a.StatusId
where s.Status <> 'Published' AND
	DATEPART(YEAR, a.Date) = DATEPART(YEAR, (select MIN(Date) from Ads)) AND
	DATEPART(MONTH, a.Date) = DATEPART(MONTH, (select MIN(Date) from Ads))
order by a.Id

------------------------------------------------------------------------------------------------------
-- Problem 11.	Ads by Status
------------------------------------------------------------------------------------------------------

select s.Status, Count(s.Status) as [Count]
from Ads a
join AdStatuses s on s.Id = a.StatusId
group by s.Status
order by s.Status

------------------------------------------------------------------------------------------------------
-- Problem 12.	Ads by Town and Status
------------------------------------------------------------------------------------------------------

select t.Name as [Town Name], s.Status, Count(a.Id) as [Count]
from Ads a
join Towns t on t.Id = a.TownId
join AdStatuses s on s.id = a.StatusId
group by t.Name, s.Status
having Count(a.Id) <> 0
order by t.Name, s.Status

------------------------------------------------------------------------------------------------------
-- Problem 13.	* Ads by Users
------------------------------------------------------------------------------------------------------

CREATE FUNCTION dbo.fn_IsAdministrator (@roleName nvarchar(50))
RETURNS nvarchar(50)
AS
BEGIN
	IF (@roleName = N'Administrator')
	BEGIN
		RETURN N'yes'
	END

	RETURN N'no'
END
GO

select u.UserName, 
	Count(a.Id) as [AdsCount],
	(CASE
		WHEN u.UserName IN (
			select u.UserName
			from AspNetUsers u
			join AspNetUserRoles ur on ur.UserId = u.Id
			join AspNetRoles r on r.Id = ur.RoleId
			where r.Name = 'Administrator'
		) THEN 'yes'
		ELSE 'no'
	 END) as [IsAdministrator]
from Ads a
right join AspNetUsers u on u.Id = a.OwnerId
group by u.UserName
order by u.UserName

------------------------------------------------------------------------------------------------------
-- Problem 14.	Ads by Town
------------------------------------------------------------------------------------------------------

select Count(a.Id) as [AdsCount], ISNULL(t.Name, '(no town)') as [Town]
from Ads a
left join Towns t on t.Id = a.TownId
group by t.Name
having Count(a.Id) = 2 OR Count(a.Id) = 3 OR Count(a.Id) = 0
order by t.Name

------------------------------------------------------------------------------------------------------
-- Problem 15.	Pairs of Dates within 12 Hours
------------------------------------------------------------------------------------------------------

select f.Date as [FirstDate], s.Date as [SecondDate]
from Ads f, Ads s
WHERE s.Date <= DATEADD(HOUR, 12, f.Date) AND f.Date < s.Date
order by f.Date, s.Date

------------------------------------------------------------------------------------------------------
-- Part 2
------------------------------------------------------------------------------------------------------
-- Problem 16.	Ads by Country
------------------------------------------------------------------------------------------------------

-- 1.	Create a table Countries(Id, Name). 

create table Countries
	(Id int NOT NULL PRIMARY KEY IDENTITY,
	 Name nvarchar(50));


-- Add a new column CountryId in the Towns table to link each town to some country 
-- (non-mandatory link). Create a foreign key between the Countries and Towns tables.

alter table Towns 
	add CountryId int;

alter table Towns
	add foreign key (CountryId) references Countries(Id);

-- 2.	Execute the following SQL script (it should pass without any errors)

INSERT INTO Countries(Name) VALUES ('Bulgaria'), ('Germany'), ('France')
UPDATE Towns SET CountryId = (SELECT Id FROM Countries WHERE Name='Bulgaria')
INSERT INTO Towns VALUES
('Munich', (SELECT Id FROM Countries WHERE Name='Germany')),
('Frankfurt', (SELECT Id FROM Countries WHERE Name='Germany')),
('Berlin', (SELECT Id FROM Countries WHERE Name='Germany')),
('Hamburg', (SELECT Id FROM Countries WHERE Name='Germany')),
('Paris', (SELECT Id FROM Countries WHERE Name='France')),
('Lyon', (SELECT Id FROM Countries WHERE Name='France')),
('Nantes', (SELECT Id FROM Countries WHERE Name='France'))

-- 3.	Write and execute a SQL command that changes the town to "Paris" for all ads created at Friday.

UPDATE a
SET 
	a.TownId = (select Id from Towns where Name = 'Paris')
FROM
Ads a
where DATEPART(DW, a.Date) = 6

-- 4.	Write and execute a SQL command that changes the town to "Hamburg" for all ads created at Thursday.

UPDATE a
SET 
	a.TownId = (select Id from Towns where Name = 'Hamburg')
FROM
Ads a
where DATEPART(DW, a.Date) = 5

-- 5.	Delete all ads created by user in role "Partner".
 
delete a
from Ads a
join AspNetUsers u on u.Id = a.OwnerId
where u.UserName IN
(
	select u.Name
	from AspNetUsers u
	join AspNetUserRoles ur on u.Id = ur.UserId
	join AspNetRoles r on r.Id = ur.RoleId
	where r.Name = 'Partner'
)

-- 6.	Add a new ad holding the following information: 
-- Title="Free Book", Text="Free C# Book", Date={current date and time}, Owner="nakov", Status="Waiting Approval".

-- The id of the owner
select Id
from AspNetUsers
where UserName = 'nakov'

-- The id of the status
select Id
from AdStatuses
where Status = 'Waiting Approval'

insert into Ads (Title, Text, Date, OwnerId, StatusId)
	values('Free Book', 
		'Free C# Book', 
		GETDATE(), 
		(
			select Id
			from AspNetUsers
			where UserName = 'nakov'
		),
		(
			select Id
			from AdStatuses
			where Status = 'Waiting Approval'
		))

-- 7.	Find the count of ads for each town. 
-- Display the ads count, the town name and the country name.
-- Include also the ads without a town and country.
-- Sort the results by town, then by country.

select t.Name as Town, c.Name as Country, Count(a.Id) as AdsCount
from Ads a
full join Towns t on t.Id = a.TownId
full join Countries c on c.Id = t.CountryId
group by t.Name, c.Name
order by t.Name, c.Name

------------------------------------------------------------------------------------------------------
-- Part 3
------------------------------------------------------------------------------------------------------
-- Problem 17.	Create a View and a Stored Function
------------------------------------------------------------------------------------------------------

-- Create a view "AllAds" in the database that holds information about ads:
-- id, title, author (username), date, town name, category name and status, sorted by id. 
CREATE VIEW AllAds
AS
Select a.Id, a.Title, u.UserName as [Author], a.Date, t.Name as [Town], c.Name as [Category], s.Status
from Ads a
join AspNetUsers u on u.Id = a.OwnerId
left join Towns t on t.Id = a.TownId
left join Categories c on c.Id = a.CategoryId
join AdStatuses s on s.Id = a.StatusId

-- Testing
select * from AllAds

-- 1.	Using the view above, create a stored function "fn_ListUsersAds" that returns a table,
-- holding all users in descending order as first column, along with all dates of their ads (in ascending order)
-- in format "yyyyMMdd", separated by "; " as second column.

CREATE FUNCTION fn_GetAdsByAuthor(@author nvarchar(50))
RETURNS nvarchar(max)
	BEGIN
		declare adsCursor CURSOR READ_ONLY FOR
		Select Date from AllAds where Author = @author order by Date asc

		OPEN adsCursor
		DECLARE @currentDate smalldatetime
		DECLARE @result nvarchar(max) = NULL
		FETCH NEXT FROM adsCursor INTO @currentDate

		WHILE @@FETCH_STATUS = 0
		BEGIN
			IF (@result is not NULL)
			BEGIN
				SET @result = @result + '; ' + FORMAT(@currentDate, 'yyyyMMdd', 'en-US')
			END
			ELSE
				SET @result = '' + FORMAT(@currentDate, 'yyyyMMdd', 'en-US')

			FETCH NEXT FROM adsCursor 
			INTO @currentDate
		END

		close adsCursor
		deallocate adsCursor
		RETURN @result
	END
GO

CREATE PROCEDURE usp_ListUsersAds
AS
	select DISTINCT UserName, dbo.fn_GetAdsByAuthor(UserName) as [AdDates] from AspNetUsers order by UserName desc
GO

exec usp_ListUsersAds