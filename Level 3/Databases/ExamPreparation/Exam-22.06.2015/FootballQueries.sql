-----------------------------------------------------------------------------------------------------
-- Problem 1.	All Teams
-----------------------------------------------------------------------------------------------------

select TeamName
from Teams
order by TeamName asc

-----------------------------------------------------------------------------------------------------
-- Problem 2.	Biggest Countries by Population
-----------------------------------------------------------------------------------------------------

select TOP 50 CountryName, Population
from Countries
order by Population desc

-----------------------------------------------------------------------------------------------------
-- Problem 3.	Countries and Currency (Eurzone)
-----------------------------------------------------------------------------------------------------

select 
	CountryName, 
	CountryCode, 
	(CASE CurrencyCode
		WHEN 'EUR' THEN 'Inside'
		ELSE 'Outside'
	 END) as [Eurozone]
from Countries
order by CountryName asc

-----------------------------------------------------------------------------------------------------
-- Problem 4.	Teams Holding Numbers
-----------------------------------------------------------------------------------------------------

select 
	TeamName as [Team Name],
	CountryCode as [Country Code]
from Teams
where TeamName LIKE '%[0-9]%'
order by CountryCode

-----------------------------------------------------------------------------------------------------
-- Problem 5.	International Matches
-----------------------------------------------------------------------------------------------------

select 
	h.CountryName as [Home Team], 
	a.CountryName as [Away Team], 
	im.MatchDate as [Match Date]
from InternationalMatches im
join Countries h on h.CountryCode = im.HomeCountryCode
join Countries a on a.CountryCode = im.AwayCountryCode
order by im.MatchDate desc

-----------------------------------------------------------------------------------------------------
-- Problem 6.	*Teams with their League and League Country
-----------------------------------------------------------------------------------------------------

select
	t.TeamName as [Team Name], 
	l.LeagueName as [League],
	ISNULL(c.CountryName, 'International') as [League Country]
from Teams t
join Leagues_Teams lt on t.Id = lt.TeamId
join Leagues l on l.Id = lt.LeagueId 
left join Countries c on c.CountryCode = l.CountryCode
order by t.TeamName, l.LeagueName asc

-----------------------------------------------------------------------------------------------------
-- Problem 7.	* Teams with more than One Match
-----------------------------------------------------------------------------------------------------

select  
	t.TeamName as [Team], 
	(select COUNT(Id) from TeamMatches where HomeTeamId = t.Id OR AwayTeamId = t.Id) as [Matches Count]
from Teams t
where (select COUNT(Id) from TeamMatches where HomeTeamId = t.Id OR AwayTeamId = t.Id) > 1
order by t.TeamName

-----------------------------------------------------------------------------------------------------
-- Problem 8.	Number of Teams and Matches in Leagues
-----------------------------------------------------------------------------------------------------

CREATE FUNCTION fn_AverageGoalsByLeague (@LeagueId int)
RETURNS int
AS
BEGIN
	-- DECLARE @LeagueId int;
	-- SET @LeagueId = 1;
	DECLARE @totalGoals int;
	SET @totalGoals = 0;
	DECLARE @matchesCount int;
	SET @matchesCount = 0

	declare matchCursor CURSOR READ_ONLY FOR
		select HomeGoals, AwayGoals
		from TeamMatches
		where LeagueId = @LeagueId

	OPEN matchCursor
	DECLARE @homeGoals int
	DECLARE @awayGoals int

	FETCH NEXT FROM matchCursor 
	INTO @homeGoals, @awayGoals

	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @totalGoals = @totalGoals + @homeGoals + @awayGoals

		SET @matchesCount = @matchesCount + 1;

		FETCH NEXT FROM matchCursor INTO @homeGoals, @awayGoals
	END

	close matchCursor
	deallocate matchCursor

	-- PRINT (@result / @matchesCount)
	DECLARE @result int;

	IF (@matchesCount = 0)
	BEGIN
		SET @result = 0
	END
	ELSE IF (@totalGoals = 0)
	BEGIN
		SET @result = 0
	END
	ELSE
	BEGIN
		SET @result = @totalGoals / @matchesCount
	END

	RETURN @result
END

select 
	l.LeagueName as [League Name], 
	COUNT(t.TeamName) as [Teams],
	(SELECT COUNT(*) from TeamMatches where LeagueId = l.Id) as [Matches],
	ISNULL(dbo.fn_AverageGoalsByLeague(l.Id), 0) as [Average Goals]
from Leagues_Teams lt
full join Leagues l on l.Id = lt.LeagueId
full join Teams t on t.Id = lt.TeamId
group by l.LeagueName, l.Id
order by [Teams] desc

-----------------------------------------------------------------------------------------------------
-- Problem 9.	Total Goals per Team in all Matches
-----------------------------------------------------------------------------------------------------

ALTER FUNCTION fn_GetTotalGoalsForTeam (@teamId int)
RETURNS int
AS
BEGIN
	declare matchCursor CURSOR FOR
		select HomeTeamId, AwayTeamId, HomeGoals, AwayGoals
		from TeamMatches
		where HomeTeamId = @teamId OR AwayTeamId = @teamId

	OPEN matchCursor
	DECLARE @homeTeamId int, @awayTeamId int, @homeGoals int, @awayGoals int

	FETCH NEXT FROM matchCursor into
	@homeTeamId, @awayTeamId, @homeGoals, @awayGoals

	DECLARE @totalGoals int;
	SET @totalGoals = 0;

	while @@FETCH_STATUS = 0
	BEGIN
		IF @teamId = @homeTeamId
		BEGIN
			SET @totalGoals = @totalGoals + ISNULL(@homeGoals, 0)
		END
		ELSE
			SET @totalGoals = @totalGoals + ISNULL(@awayGoals, 0)
		
		FETCH NEXT FROM matchCursor into
		@homeTeamId, @awayTeamId, @homeGoals, @awayGoals
	END

	close matchCursor
	deallocate matchCursor

	RETURN @totalGoals
END

select TeamName as [TeamName], dbo.fn_GetTotalGoalsForTeam(Id) as [Total Goals]
from Teams
order by [Total Goals] desc, TeamName 

-----------------------------------------------------------------------------------------------------
-- Problem 10.	Pairs of Matches on the Same Day
-----------------------------------------------------------------------------------------------------

select
	f.MatchDate as [First Date], 
	s.MatchDate as [Second Date]
from TeamMatches f, TeamMatches s
where 
	DATEPART(YEAR, f.MatchDate) = DATEPART(YEAR, s.MatchDate) AND
	DATEPART(MONTH, f.MatchDate) = DATEPART(MONTH, s.MatchDate) AND
	DATEPART(DAY, f.MatchDate) = DATEPART(DAY, s.MatchDate) AND
	f.Id <> s.Id AND f.MatchDate < s.MatchDate
order by f.MatchDate desc, s.MatchDate desc

-----------------------------------------------------------------------------------------------------
-- Problem 11.	Mix of Team Names
-----------------------------------------------------------------------------------------------------

select LOWER(f.TeamName + RIGHT(REVERSE(s.TeamName), LEN(s.TeamName) - 1)) as [Mix]
from Teams f, Teams s
WHERE LEFT(REVERSE(f.TeamName), 1) = LEFT(REVERSE(s.TeamName), 1)
order by LOWER(f.TeamName + RIGHT(REVERSE(s.TeamName), LEN(s.TeamName) - 1))

-----------------------------------------------------------------------------------------------------
-- Problem 12.	Countries with International and Team Matches
-----------------------------------------------------------------------------------------------------
select 
	c.CountryName as [Country Name],
(
	select COUNT(Id) 
	from InternationalMatches
	where HomeCountryCode = c.CountryCode OR AwayCountryCode = c.CountryCode
) as [International Matches],
(
	select COUNT(tm.Id) 
	from TeamMatches tm
	join Teams h on h.Id = tm.HomeTeamId
	join Teams a on a.Id = tm.AwayTeamId
	join Leagues l on l.Id = tm.LeagueId
	where 
		(h.CountryCode = c.CountryCode OR a.CountryCode = c.CountryCode) AND
		l.CountryCode is not NULL 
) as [Team Matches]
from Countries c
where 
(
	select COUNT(Id) 
	from InternationalMatches
	where HomeCountryCode = c.CountryCode OR AwayCountryCode = c.CountryCode
) > 0 OR
(
	select COUNT(tm.Id) 
	from TeamMatches tm
	join Teams h on h.Id = tm.HomeTeamId
	join Teams a on a.Id = tm.AwayTeamId
	join Leagues l on l.Id = tm.LeagueId
	where 
		(h.CountryCode = c.CountryCode OR a.CountryCode = c.CountryCode) AND
		l.CountryCode is not NULL 
) > 0
order by [International Matches] desc, [Team Matches] desc, c.CountryName

-----------------------------------------------------------------------------------------------------
-- Part 2
-----------------------------------------------------------------------------------------------------
-- Problem 13.	Non-international Matches
-----------------------------------------------------------------------------------------------------

-- 1.	Create a table FriendlyMatches(Id, HomeTeamID, AwayTeamId, MatchDate). 
-- Use auto-increment for the primary key. 
-- Create a foreign keys between the tables FriendlyMatches and Teams.

create table FriendlyMatches
	(Id int PRIMARY KEY IDENTITY,
	 HomeTeamId int,
	 AwayTeamId int,
	 MatchDate smalldatetime
	)

alter table FriendlyMatches
	add foreign key(HomeTeamId) references Teams(Id);
	
alter table FriendlyMatches
	add foreign key(AwayTeamId) references Teams(Id);

-- 2.	Execute the following SQL script 

INSERT INTO Teams(TeamName) VALUES
 ('US All Stars'),
 ('Formula 1 Drivers'),
 ('Actors'),
 ('FIFA Legends'),
 ('UEFA Legends'),
 ('Svetlio & The Legends')
GO

INSERT INTO FriendlyMatches(
  HomeTeamId, AwayTeamId, MatchDate) VALUES
  
((SELECT Id FROM Teams WHERE TeamName='US All Stars'), 
 (SELECT Id FROM Teams WHERE TeamName='Liverpool'),
 '30-Jun-2015 17:00'),
 
((SELECT Id FROM Teams WHERE TeamName='Formula 1 Drivers'), 
 (SELECT Id FROM Teams WHERE TeamName='Porto'),
 '12-May-2015 10:00'),
 
((SELECT Id FROM Teams WHERE TeamName='Actors'), 
 (SELECT Id FROM Teams WHERE TeamName='Manchester United'),
 '30-Jan-2015 17:00'),

((SELECT Id FROM Teams WHERE TeamName='FIFA Legends'), 
 (SELECT Id FROM Teams WHERE TeamName='UEFA Legends'),
 '23-Dec-2015 18:00'),

((SELECT Id FROM Teams WHERE TeamName='Svetlio & The Legends'), 
 (SELECT Id FROM Teams WHERE TeamName='Ludogorets'),
 '22-Jun-2015 21:00')

GO

-- 3.	Write a query to display all non-international matches along with the given team names, 
-- starting from the newest date and ending with games with no date.

select 
	h.TeamName as [Home Team], 
	a.TeamName as [Away Team], 
	tm.MatchDate as [Match Date]
from TeamMatches tm
join Teams h on h.Id = tm.HomeTeamId
join Teams a on a.Id = tm.AwayTeamId
UNION
select 
	h.TeamName as [Home Team], 
	a.TeamName as [Away Team], 
	fm.MatchDate as [Match Date]
from FriendlyMatches fm
join Teams h on h.Id = fm.HomeTeamId
join Teams a on a.Id = fm.AwayTeamId
order by MatchDate desc

-----------------------------------------------------------------------------------------------------
-- Problem 14.	Seasonal Matches
-----------------------------------------------------------------------------------------------------

-- 1.	Write a SQL command to add a new Boolean column IsSeasonal in the Leagues table (defaults to false). 
-- Note that there is no "Boolean" type in SQL server, so you should use an alternative.

alter table Leagues
	add IsSeasonal bit NOT NULL
	CONSTRAINT Default_Seasonal DEFAULT 0 WITH VALUES

-- 2.	Add a new team match holding the following information: 
-- HomeTeam="Empoli", AwayTeam="Parma", HomeGoals=2, AwayGoals=2, Date= '19-Apr-2015 16:00', League= 'Italian Serie A'.

insert into TeamMatches(HomeTeamId, AwayTeamId, HomeGoals, AwayGoals, MatchDate, LeagueId)
	values(
		(select Id from Teams where TeamName = 'Empoli'),
		(select Id from Teams where TeamName = 'Parma'),
		2,
		2,
		'2015-04-19 16:00:00:000',
		(select Id from Leagues where LeagueName = 'Italian Serie A')
	)

-- 3.	Add a new team match holding the following information: 
-- HomeTeam=" Internazionale", AwayTeam="AC Milan", HomeGoals=0, AwayGoals=0, Date= '19-Apr-2015 21:45, League= 'Italian Serie A'.

insert into TeamMatches(HomeTeamId, AwayTeamId, HomeGoals, AwayGoals, MatchDate, LeagueId)
	values(
		(select Id from Teams where TeamName = 'Internazionale'),
		(select Id from Teams where TeamName = 'AC Milan'),
		0,
		0,
		'2015-04-19 21:45:00:000',
		(select Id from Leagues where LeagueName = 'Italian Serie A')
	)

-- 4.	Write and execute a SQL command to mark as seasonal all leagues that have at least one team match.

UPDATE Leagues
SET IsSeasonal = 1
where
Id IN (select DISTINCT l.Id
	   from TeamMatches tm
	   join Leagues l on l.Id = tm.LeagueId)

-- 5.	Find all seasonal matches strictly after 10th April 2015. 
-- Display the home team name and score, the away team name and score and the league. 
-- Sort the results by league name (alphabetically), 
-- then by home team score count and away team score count (from largest to lowest). 

select 
	h.TeamName as [Home Team],
	tm.HomeGoals as [Home Goals],
	a.TeamName as [Away Team],
	tm.AwayGoals as [Away Goals],
	l.LeagueName as [League Name]
from TeamMatches tm
join Leagues l on l.Id = tm.LeagueId
join Teams h on h.Id = tm.HomeTeamId
join Teams a on a.Id = tm.AwayTeamId
where l.IsSeasonal = 1 AND tm.MatchDate > Convert(smalldatetime, '2015-04-10' )
order by l.LeagueName, tm.HomeGoals desc, tm.AwayGoals desc

-----------------------------------------------------------------------------------------------------
-- Part 3
-----------------------------------------------------------------------------------------------------
-- Problem 15.	Stored Function: Bulgarian Teams with Matches JSON
-----------------------------------------------------------------------------------------------------

select h.TeamName, a.TeamName, tm.HomeGoals, tm.AwayGoals, CONVERT(VARCHAR(50), tm.MatchDate, 3) from TeamMatches tm
join Teams h on h.Id = tm.HomeTeamId
join Teams a on a.Id = tm.AwayTeamId
where h.CountryCode = 'BG' or a.CountryCode = 'BG'

select TeamName
from Teams
where CountryCode = 'BG'
order by TeamName