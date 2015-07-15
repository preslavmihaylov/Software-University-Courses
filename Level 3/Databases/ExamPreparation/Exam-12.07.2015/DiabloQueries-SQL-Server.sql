--------------------------------------------------------------------------------------------------------
-- Problem 1.	All Diablo Characters
--------------------------------------------------------------------------------------------------------

select Name from Characters
order by Name

--------------------------------------------------------------------------------------------------------
-- Problem 2.	Games from 2011 and 2012 year
--------------------------------------------------------------------------------------------------------

select TOP 50 
	Name as [Game], 
	CONVERT(NVARCHAR(10), Start, 120) as [Start] 
	from Games
where DATEPART(YEAR, Start) = 2011 OR DATEPART(YEAR, Start) = 2012 
order by Start

--------------------------------------------------------------------------------------------------------
-- Problem 3.	User Email Providers
--------------------------------------------------------------------------------------------------------

select 
	Username, 
	REPLACE(
		PARSENAME(
			REPLACE(
				REPLACE(Email, '.', '/'), '@', '.'), 1), '/', '.') as [Email Provider]
from Users
order by [Email Provider], Username

--------------------------------------------------------------------------------------------------------
-- Problem 4.	Get users with IPAddress like pattern
--------------------------------------------------------------------------------------------------------

select 
	Username, 
	IpAddress as [IP Address] 
from Users
where IpAddress LIKE '___.1%.%.___'
order by Username

--------------------------------------------------------------------------------------------------------
-- Problem 5.	Show All Games with Duration and Part of the Day
--------------------------------------------------------------------------------------------------------

select 
	Name as [Game],
	(CASE 
		WHEN DATEPART(HOUR,Start) >= 0 AND DATEPART(HOUR,Start) < 12 THEN 'Morning'
		WHEN DATEPART(HOUR,Start) >= 12 AND DATEPART(HOUR,Start) < 18 THEN 'Afternoon'
		ELSE 'Evening'
	 END) as [Part of the Day],
	(CASE
		WHEN Duration <= 3 THEN 'Extra Short'
		WHEN Duration > 3 AND Duration <= 6 THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		ELSE 'Extra Long'
	 END) as [Duration]
from Games
order by [Game], Duration, Start

--------------------------------------------------------------------------------------------------------
-- Problem 6.	Number of Users for Email Provider
--------------------------------------------------------------------------------------------------------

select  
	REPLACE(
		PARSENAME(
			REPLACE(
				REPLACE(Email, '.', '/'), '@', '.'), 1), '/', '.') as [Email Provider], 
	COUNT(Username) as [Number Of Users]
from Users
group by REPLACE(
		PARSENAME(
			REPLACE(
				REPLACE(Email, '.', '/'), '@', '.'), 1), '/', '.')
order by [Number Of Users] desc, [Email Provider]
--------------------------------------------------------------------------------------------------------
-- Problem 7.	All User in Games
--------------------------------------------------------------------------------------------------------

select 
	g.Name as [Game],
	gt.Name as [Game Type],
	u.Username as [Username],
	ug.Level as [Level],
	REPLACE(CONVERT(nvarchar(max), ug.Cash), ',', '.') as [Cash],
	c.Name as [Character]
from UsersGames ug
join Users u on u.Id = ug.UserId
join Games g on g.Id = ug.GameId
join Characters c on c.Id = ug.CharacterId
join GameTypes gt on gt.Id = g.GameTypeId
order by [Level] desc, u.Username, g.Name

--------------------------------------------------------------------------------------------------------
-- Problem 8.	Users in Games with Their Items
--------------------------------------------------------------------------------------------------------

select 
	u.Username as [Username],
	g.Name as [Game],
	COUNT(i.Name) as [Items Count],
	REPLACE(
		CONVERT(
			nvarchar(50), SUM(i.Price)), ',', '.') as [Items Price]
from UserGameItems ugi
join Items i on i.Id = ugi.ItemId
join UsersGames ug on ug.Id = ugi.UserGameId
join Users u on u.Id = ug.UserId
join Games g on g.Id = ug.GameId
group by u.Username, g.Name
having COUNT(i.Name) >= 10
order by [Items Count] desc, [Items Price] desc, [Username]

--------------------------------------------------------------------------------------------------------
-- Problem 9.	* User in Games with Their Statistics
--------------------------------------------------------------------------------------------------------

select 
	u.Username as [Username],
	g.Name as [Game],\
	MAX(c.Name) as [Character],
	(MAX(cs.Strength) + MAX(gts.Strength) + SUM(its.Strength)) as [Strength],
	(MAX(cs.Defence) + MAX(gts.Defence) + SUM(its.Defence)) as [Defence],
	(MAX(cs.Speed) + MAX(gts.Speed) + SUM(its.Speed)) as [Speed],
	(MAX(cs.Mind) + MAX(gts.Mind) + SUM(its.Mind)) as [Mind],
	(MAX(cs.Luck) + MAX(gts.Luck) + SUM(its.Luck)) as [Luck]
from UsersGames ug
join Users u on u.Id = ug.UserId
join Games g on g.Id = ug.GameId
join Characters c on c.Id = ug.CharacterId
join [Statistics] cs on cs.Id = c.StatisticId
join GameTypes gt on gt.Id = g.GameTypeId
join [Statistics] gts on gts.Id = gt.BonusStatsId 
join UserGameItems ugi on ugi.UserGameId = ug.Id
join Items i on i.Id = ugi.ItemId
join [Statistics] its on its.Id = i.StatisticId 
group by 
	u.Username, 
	g.Name 
	-- c.Name 
	-- cs.Strength,
	-- gts.Strength
order by [Strength] desc, [Defence] desc, [Speed] desc, [Mind] desc, [Luck] desc

-- TEST
select 
	u.Username, 
	g.Name, 
	MIN(c.Name), 
	gt.Name,
	MIN(cs.Strength) as [Character Str],  
	MIN(gts.Strength) as [Game Type Str],
	COUNT(i.Name) as [Item Name],  
	SUM(its.Strength) as [IT Strength]
from UsersGames ug
join Users u on u.Id = ug.UserId
join Games g on g.Id = ug.GameId
join Characters c on c.Id = ug.CharacterId
join [Statistics] cs on cs.Id = c.StatisticId
join GameTypes gt on gt.Id = g.GameTypeId
join [Statistics] gts on gts.Id = gt.BonusStatsId 
join UserGameItems ugi on ugi.UserGameId = ug.Id
join Items i on i.Id = ugi.ItemId
join [Statistics] its on its.Id = i.StatisticId 
group by u.Username, g.Name, gt.Name, gts.Strength
having u.Username = 'skippingside' AND g.Name = 'Rose Fire & Ice'
order by [IT Strength]

--------------------------------------------------------------------------------------------------------
-- Problem 10.	All Items with Greater than Average Statistics
--------------------------------------------------------------------------------------------------------

select 
	i.Name as [Name],
	REPLACE(CONVERT(nvarchar(max), i.Price), ',', '.') as [Price],
	i.MinLevel as [MinLevel],
	its.Strength as [Strength],
	its.Defence as [Defence],
	its.Speed as [Speed],
	its.Luck as [Luck],
	its.Mind as [Mind]
from Items i
join [Statistics] its on its.Id = i.StatisticId
where its.Mind > (SELECT AVG(its.Mind) from Items i join [Statistics] its on its.Id = i.StatisticId) AND
 its.Speed > (SELECT AVG(its.Speed) from Items i join [Statistics] its on its.Id = i.StatisticId) AND 
 its.Luck > (SELECT AVG(its.Luck) from Items i join [Statistics] its on its.Id = i.StatisticId)
order by i.Name

--------------------------------------------------------------------------------------------------------
-- Problem 11.	Display All Items with Information about Forbidden Game Type
--------------------------------------------------------------------------------------------------------

select 
	i.Name as [Item],
	REPLACE(CONVERT(nvarchar(max), i.Price), ',', '.') as [Price],
	i.MinLevel as [MinLevel],
	gt.Name as [Forbidden Game Type]
from Items i
left join GameTypeForbiddenItems gtfi on gtfi.ItemId = i.Id
left join GameTypes gt on gt.Id = gtfi.GameTypeId
order by [Forbidden Game Type] desc, i.Name

--------------------------------------------------------------------------------------------------------
-- Part 2
--------------------------------------------------------------------------------------------------------
-- Problem 12.	Buy items for user in game
--------------------------------------------------------------------------------------------------------

-- 1.	User Alex is in the shop in the game “Edinburgh” and she wants to buy some items. 
-- She likes Blackguard, Bottomless Potion of Amplification, Eye of Etlich (Diablo III), 
-- Gem of Efficacious Toxin, Golden Gorget of Leoric and Hellfire Amulet. 
-- Buy the items. You should add the data in the right tables. Get the money for the items from user in game Cash.

select *
from Items 
where Id = 51

select * from UsersGames ug
join Users u on u.Id = ug.UserId
join Games g on g.Id = ug.GameId
where g.Name = 'Edinburgh' and u.Username = 'Alex'

insert into UserGameItems(UserGameId, ItemId)
	values (235, 51)

insert into UserGameItems(UserGameId, ItemId)
	values (235, 71)

insert into UserGameItems(UserGameId, ItemId)
	values (235, 157)

insert into UserGameItems(UserGameId, ItemId)
	values (235, 184)

insert into UserGameItems(UserGameId, ItemId)
	values (235, 197)

insert into UserGameItems(UserGameId, ItemId)
	values (235, 223)

UPDATE UsersGames
SET Cash = 4702
where UserId = 5 AND GameId = 221

select 
	u.Username as [Username],
	g.Name as [Name],
	REPLACE(CONVERT(nvarchar(max), ug.Cash), ',', '.') as [Cash],
	i.Name as [Item Name]
from UsersGames ug
join Users u on u.Id = ug.UserId
join Games g on g.Id = ug.GameId
join UserGameItems ugi on ugi.UserGameId = ug.Id
join Items i on i.Id = ugi.ItemId
where g.Id = 221
order by i.Name

select *
from Games
where Id = 221

select *
from UserGameItems
where UserGameId = 221

--------------------------------------------------------------------------------------------------------
-- Problem 13.	Massive shopping
--------------------------------------------------------------------------------------------------------

select Id
from Items 
where (MinLevel >= 11 AND MinLevel <= 12) 

select * from Items where Name = 'Ahavarion, Spear of Lycander'
-- UserGame ID - 110
select i.Name, i.MinLevel
from UserGameItems ugi
join Items i on i.Id = ugi.ItemId
join UsersGames ug on ug.Id = ugi.UserGameId
join Games g on g.Id = ug.GameId
where UserGameId = 110

insert into UserGameItems(UserGameId, ItemId) values(110, 16)
insert into UserGameItems(UserGameId, ItemId) values(110, 45)
insert into UserGameItems(UserGameId, ItemId) values(110, 108)
insert into UserGameItems(UserGameId, ItemId) values(110, 111)
insert into UserGameItems(UserGameId, ItemId) values(110, 176)
insert into UserGameItems(UserGameId, ItemId) values(110, 184)
insert into UserGameItems(UserGameId, ItemId) values(110, 191)
insert into UserGameItems(UserGameId, ItemId) values(110, 194)
insert into UserGameItems(UserGameId, ItemId) values(110, 195)
insert into UserGameItems(UserGameId, ItemId) values(110, 247)
insert into UserGameItems(UserGameId, ItemId) values(110, 280)
insert into UserGameItems(UserGameId, ItemId) values(110, 475)
insert into UserGameItems(UserGameId, ItemId) values(110, 500)
insert into UserGameItems(UserGameId, ItemId) values(110, 552)

select i.Name as [Item Name]
from UsersGames ug
join Users u on u.Id = ug.UserId
join Games g on g.Id = ug.GameId
join UserGameItems ugi on ugi.UserGameId = ug.Id
join Items i on i.Id = ugi.ItemId
where g.Name = 'Safflower'
order by i.Name

--------------------------------------------------------------------------------------------------------
-- Part 3
--------------------------------------------------------------------------------------------------------
-- Problem 14.	Scalar Function: Cash in User Games Odd Rows
--------------------------------------------------------------------------------------------------------

ALTER FUNCTION fn_CashInGame (@GameId int)
RETURNS money
BEGIN

	declare cashCursor CURSOR READ_ONLY FOR
	select ug.Cash
	from UsersGames ug
	where ug.GameId = @GameId
	order by ug.Cash desc
	
	-- select * from Games where Id = 212

	DECLARE @totalCash money
	DECLARE @currentRow int
	SET @currentRow = 1;
	SET @totalCash = 0;

	DECLARE @currentCash money

	OPEN cashCursor
	FETCH NEXT FROM cashCursor INTO @currentCash

	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF @currentRow % 2 = 1
		BEGIN
			SET @totalCash = @totalCash + @currentCash
		END

		SET @currentRow = @currentRow + 1;

		FETCH NEXT FROM cashCursor INTO @currentCash
	END

	close cashCursor
	deallocate cashCursor
	
	return @totalCash;
END

select *
from Games
where Name = 'Bali' -- 212 ID

select REPLACE(CONVERT(nvarchar(max), dbo.fn_CashInGame(Id)), ',', '.') as [SumCash]
from Games
where Id = 212 OR Id = 48 OR Id = 49 OR Id = 50 OR Id = 51
order by dbo.fn_CashInGame(Id)

select * from 
Games where Name = 'Lily Stargazer' -- 48

select * from 
Games where Name = 'Love in a mist' -- 49

select * from 
Games where Name = 'Mimosa' -- 50

select * from 
Games where Name = 'Ming fern' -- 51

--------------------------------------------------------------------------------------------------------
-- Problem 15.	Trigger
--------------------------------------------------------------------------------------------------------

CREATE TRIGGER ItemBuyTrigger
ON UserGameItems
AFTER INSERT 
AS 
	DECLARE @minLevel money
	SET @minLevel = (select i.MinLevel
				 from inserted ins
				 join Items i on i.Id = ins.ItemId
				 join UsersGames ug on ug.Id = ins.UserGameId)

	DECLARE @cash money
	SET @cash = (select ug.Cash
				 from inserted ins
				 join Items i on i.Id = ins.ItemId
				 join UsersGames ug on ug.Id = ins.UserGameId)

	DECLARE @itemPrice money
	SET @itemPrice = (select i.Price
				 from inserted ins
				 join Items i on i.Id = ins.ItemId
				 join UsersGames ug on ug.Id = ins.UserGameId)

	DECLARE @userLevel int
	SET @userLevel = (select ug.Level
					  from inserted ins
					  join Items i on i.Id = ins.ItemId
					  join UsersGames ug on ug.Id = ins.UserGameId)

	IF (@minLevel > @userLevel)
	BEGIN
		PRINT 'Error'
		DELETE from UserGameItems
		where ItemId = (select ItemId from inserted) AND UserGameId = (select UserGameId from inserted)
	END
	ELSE
		UPDATE UsersGames
		SET Cash = @cash - @itemPrice
		where Id = (select UserGameId from inserted)
GO

-- Add bonus cash of 50000 to users: baleremuda, loosenoise, inguinalself, buildingdeltoid, monoxidecos in the game “Bali”.

select ug.Id, u.Username, ug.Cash
from UsersGames ug
join Games g on g.Id = ug.GameId
join Users u on u.Id = ug.UserId
where g.Name = 'Bali' AND 
	(u.Username = 'baleremuda' OR 
	 u.Username = 'loosenoise' OR
	 u.Username = 'inguinalself' OR
	 u.Username = 'buildingdeltoid' OR
	 u.Username = 'monoxidecos')

UPDATE UsersGames
SET Cash = Cash + 50000
where Id = 26 OR Id = 115 OR Id = 146 OR Id = 177 OR Id = 296

-- There are two groups of items that you should buy for the above users in the game.
-- First group is with id between 251 and 299 including. Second group is with id between 501 and 539 including.

select Id
from Items 
where Id >= 501 AND Id <= 539

-- First Tran

insert into UserGameItems(UserGameId, ItemId) values(26, 251)
insert into UserGameItems(UserGameId, ItemId) values(26, 252)
insert into UserGameItems(UserGameId, ItemId) values(26, 253)
insert into UserGameItems(UserGameId, ItemId) values(26, 254)
insert into UserGameItems(UserGameId, ItemId) values(26, 255)
insert into UserGameItems(UserGameId, ItemId) values(26, 256)
insert into UserGameItems(UserGameId, ItemId) values(26, 257)
insert into UserGameItems(UserGameId, ItemId) values(26, 258)
insert into UserGameItems(UserGameId, ItemId) values(26, 259)
insert into UserGameItems(UserGameId, ItemId) values(26, 260)
insert into UserGameItems(UserGameId, ItemId) values(26, 261)
insert into UserGameItems(UserGameId, ItemId) values(26, 262)
insert into UserGameItems(UserGameId, ItemId) values(26, 263)
insert into UserGameItems(UserGameId, ItemId) values(26, 264)
insert into UserGameItems(UserGameId, ItemId) values(26, 265)
insert into UserGameItems(UserGameId, ItemId) values(26, 266)
insert into UserGameItems(UserGameId, ItemId) values(26, 267)
insert into UserGameItems(UserGameId, ItemId) values(26, 268)
insert into UserGameItems(UserGameId, ItemId) values(26, 269)
insert into UserGameItems(UserGameId, ItemId) values(26, 270)
insert into UserGameItems(UserGameId, ItemId) values(26, 271)
insert into UserGameItems(UserGameId, ItemId) values(26, 272)
insert into UserGameItems(UserGameId, ItemId) values(26, 273)
insert into UserGameItems(UserGameId, ItemId) values(26, 274)
insert into UserGameItems(UserGameId, ItemId) values(26, 275)
insert into UserGameItems(UserGameId, ItemId) values(26, 276)
insert into UserGameItems(UserGameId, ItemId) values(26, 277)
insert into UserGameItems(UserGameId, ItemId) values(26, 278)
insert into UserGameItems(UserGameId, ItemId) values(26, 279)
insert into UserGameItems(UserGameId, ItemId) values(26, 280)
insert into UserGameItems(UserGameId, ItemId) values(26, 281)
insert into UserGameItems(UserGameId, ItemId) values(26, 282)
insert into UserGameItems(UserGameId, ItemId) values(26, 283)
insert into UserGameItems(UserGameId, ItemId) values(26, 284)
insert into UserGameItems(UserGameId, ItemId) values(26, 285)
insert into UserGameItems(UserGameId, ItemId) values(26, 286)
insert into UserGameItems(UserGameId, ItemId) values(26, 287)
insert into UserGameItems(UserGameId, ItemId) values(26, 288)
insert into UserGameItems(UserGameId, ItemId) values(26, 289)
insert into UserGameItems(UserGameId, ItemId) values(26, 290)
insert into UserGameItems(UserGameId, ItemId) values(26, 291)
insert into UserGameItems(UserGameId, ItemId) values(26, 292)
insert into UserGameItems(UserGameId, ItemId) values(26, 293)
insert into UserGameItems(UserGameId, ItemId) values(26, 294)
insert into UserGameItems(UserGameId, ItemId) values(26, 295)
insert into UserGameItems(UserGameId, ItemId) values(26, 296)
insert into UserGameItems(UserGameId, ItemId) values(26, 297)
insert into UserGameItems(UserGameId, ItemId) values(26, 298)
insert into UserGameItems(UserGameId, ItemId) values(26, 299)

-- SECOND
insert into UserGameItems(UserGameId, ItemId) values(115, 251)
insert into UserGameItems(UserGameId, ItemId) values(115, 252)
insert into UserGameItems(UserGameId, ItemId) values(115, 253)
insert into UserGameItems(UserGameId, ItemId) values(115, 254)
insert into UserGameItems(UserGameId, ItemId) values(115, 255)
insert into UserGameItems(UserGameId, ItemId) values(115, 256)
insert into UserGameItems(UserGameId, ItemId) values(115, 257)
insert into UserGameItems(UserGameId, ItemId) values(115, 258)
insert into UserGameItems(UserGameId, ItemId) values(115, 259)
insert into UserGameItems(UserGameId, ItemId) values(115, 260)
insert into UserGameItems(UserGameId, ItemId) values(115, 261)
insert into UserGameItems(UserGameId, ItemId) values(115, 262)
insert into UserGameItems(UserGameId, ItemId) values(115, 263)
insert into UserGameItems(UserGameId, ItemId) values(115, 264)
insert into UserGameItems(UserGameId, ItemId) values(115, 265)
insert into UserGameItems(UserGameId, ItemId) values(115, 266)
insert into UserGameItems(UserGameId, ItemId) values(115, 267)
insert into UserGameItems(UserGameId, ItemId) values(115, 268)
insert into UserGameItems(UserGameId, ItemId) values(115, 269)
insert into UserGameItems(UserGameId, ItemId) values(115, 270)
insert into UserGameItems(UserGameId, ItemId) values(115, 271)
insert into UserGameItems(UserGameId, ItemId) values(115, 272)
insert into UserGameItems(UserGameId, ItemId) values(115, 273)
insert into UserGameItems(UserGameId, ItemId) values(115, 274)
insert into UserGameItems(UserGameId, ItemId) values(115, 275)
insert into UserGameItems(UserGameId, ItemId) values(115, 276)
insert into UserGameItems(UserGameId, ItemId) values(115, 277)
insert into UserGameItems(UserGameId, ItemId) values(115, 278)
insert into UserGameItems(UserGameId, ItemId) values(115, 279)
insert into UserGameItems(UserGameId, ItemId) values(115, 280)
insert into UserGameItems(UserGameId, ItemId) values(115, 281)
insert into UserGameItems(UserGameId, ItemId) values(115, 282)
insert into UserGameItems(UserGameId, ItemId) values(115, 283)
insert into UserGameItems(UserGameId, ItemId) values(115, 284)
insert into UserGameItems(UserGameId, ItemId) values(115, 285)
insert into UserGameItems(UserGameId, ItemId) values(115, 286)
insert into UserGameItems(UserGameId, ItemId) values(115, 287)
insert into UserGameItems(UserGameId, ItemId) values(115, 288)
insert into UserGameItems(UserGameId, ItemId) values(115, 289)
insert into UserGameItems(UserGameId, ItemId) values(115, 290)
insert into UserGameItems(UserGameId, ItemId) values(115, 291)
insert into UserGameItems(UserGameId, ItemId) values(115, 292)
insert into UserGameItems(UserGameId, ItemId) values(115, 293)
insert into UserGameItems(UserGameId, ItemId) values(115, 294)
insert into UserGameItems(UserGameId, ItemId) values(115, 295)
insert into UserGameItems(UserGameId, ItemId) values(115, 296)
insert into UserGameItems(UserGameId, ItemId) values(115, 297)
insert into UserGameItems(UserGameId, ItemId) values(115, 298)
insert into UserGameItems(UserGameId, ItemId) values(115, 299)

-- THIRD

insert into UserGameItems(UserGameId, ItemId) values(146, 251)
insert into UserGameItems(UserGameId, ItemId) values(146, 252)
insert into UserGameItems(UserGameId, ItemId) values(146, 253)
insert into UserGameItems(UserGameId, ItemId) values(146, 254)
insert into UserGameItems(UserGameId, ItemId) values(146, 255)
insert into UserGameItems(UserGameId, ItemId) values(146, 256)
insert into UserGameItems(UserGameId, ItemId) values(146, 257)
insert into UserGameItems(UserGameId, ItemId) values(146, 258)
insert into UserGameItems(UserGameId, ItemId) values(146, 259)
insert into UserGameItems(UserGameId, ItemId) values(146, 260)
insert into UserGameItems(UserGameId, ItemId) values(146, 261)
insert into UserGameItems(UserGameId, ItemId) values(146, 262)
insert into UserGameItems(UserGameId, ItemId) values(146, 263)
insert into UserGameItems(UserGameId, ItemId) values(146, 264)
insert into UserGameItems(UserGameId, ItemId) values(146, 265)
insert into UserGameItems(UserGameId, ItemId) values(146, 266)
insert into UserGameItems(UserGameId, ItemId) values(146, 267)
insert into UserGameItems(UserGameId, ItemId) values(146, 268)
insert into UserGameItems(UserGameId, ItemId) values(146, 269)
insert into UserGameItems(UserGameId, ItemId) values(146, 270)
insert into UserGameItems(UserGameId, ItemId) values(146, 271)
insert into UserGameItems(UserGameId, ItemId) values(146, 272)
insert into UserGameItems(UserGameId, ItemId) values(146, 273)
insert into UserGameItems(UserGameId, ItemId) values(146, 274)
insert into UserGameItems(UserGameId, ItemId) values(146, 275)
insert into UserGameItems(UserGameId, ItemId) values(146, 276)
insert into UserGameItems(UserGameId, ItemId) values(146, 277)
insert into UserGameItems(UserGameId, ItemId) values(146, 278)
insert into UserGameItems(UserGameId, ItemId) values(146, 279)
insert into UserGameItems(UserGameId, ItemId) values(146, 280)
insert into UserGameItems(UserGameId, ItemId) values(146, 281)
insert into UserGameItems(UserGameId, ItemId) values(146, 282)
insert into UserGameItems(UserGameId, ItemId) values(146, 283)
insert into UserGameItems(UserGameId, ItemId) values(146, 284)
insert into UserGameItems(UserGameId, ItemId) values(146, 285)
insert into UserGameItems(UserGameId, ItemId) values(146, 286)
insert into UserGameItems(UserGameId, ItemId) values(146, 287)
insert into UserGameItems(UserGameId, ItemId) values(146, 288)
insert into UserGameItems(UserGameId, ItemId) values(146, 289)
insert into UserGameItems(UserGameId, ItemId) values(146, 290)
insert into UserGameItems(UserGameId, ItemId) values(146, 291)
insert into UserGameItems(UserGameId, ItemId) values(146, 292)
insert into UserGameItems(UserGameId, ItemId) values(146, 293)
insert into UserGameItems(UserGameId, ItemId) values(146, 294)
insert into UserGameItems(UserGameId, ItemId) values(146, 295)
insert into UserGameItems(UserGameId, ItemId) values(146, 296)
insert into UserGameItems(UserGameId, ItemId) values(146, 297)
insert into UserGameItems(UserGameId, ItemId) values(146, 298)
insert into UserGameItems(UserGameId, ItemId) values(146, 299)

-- FOURTH

insert into UserGameItems(UserGameId, ItemId) values(177, 251)
insert into UserGameItems(UserGameId, ItemId) values(177, 252)
insert into UserGameItems(UserGameId, ItemId) values(177, 253)
insert into UserGameItems(UserGameId, ItemId) values(177, 254)
insert into UserGameItems(UserGameId, ItemId) values(177, 255)
insert into UserGameItems(UserGameId, ItemId) values(177, 256)
insert into UserGameItems(UserGameId, ItemId) values(177, 257)
insert into UserGameItems(UserGameId, ItemId) values(177, 258)
insert into UserGameItems(UserGameId, ItemId) values(177, 259)
insert into UserGameItems(UserGameId, ItemId) values(177, 260)
insert into UserGameItems(UserGameId, ItemId) values(177, 261)
insert into UserGameItems(UserGameId, ItemId) values(177, 262)
insert into UserGameItems(UserGameId, ItemId) values(177, 263)
insert into UserGameItems(UserGameId, ItemId) values(177, 264)
insert into UserGameItems(UserGameId, ItemId) values(177, 265)
insert into UserGameItems(UserGameId, ItemId) values(177, 266)
insert into UserGameItems(UserGameId, ItemId) values(177, 267)
insert into UserGameItems(UserGameId, ItemId) values(177, 268)
insert into UserGameItems(UserGameId, ItemId) values(177, 269)
insert into UserGameItems(UserGameId, ItemId) values(177, 270)
insert into UserGameItems(UserGameId, ItemId) values(177, 271)
insert into UserGameItems(UserGameId, ItemId) values(177, 272)
insert into UserGameItems(UserGameId, ItemId) values(177, 273)
insert into UserGameItems(UserGameId, ItemId) values(177, 274)
insert into UserGameItems(UserGameId, ItemId) values(177, 275)
insert into UserGameItems(UserGameId, ItemId) values(177, 276)
insert into UserGameItems(UserGameId, ItemId) values(177, 277)
insert into UserGameItems(UserGameId, ItemId) values(177, 278)
insert into UserGameItems(UserGameId, ItemId) values(177, 279)
insert into UserGameItems(UserGameId, ItemId) values(177, 280)
insert into UserGameItems(UserGameId, ItemId) values(177, 281)
insert into UserGameItems(UserGameId, ItemId) values(177, 282)
insert into UserGameItems(UserGameId, ItemId) values(177, 283)
insert into UserGameItems(UserGameId, ItemId) values(177, 284)
insert into UserGameItems(UserGameId, ItemId) values(177, 285)
insert into UserGameItems(UserGameId, ItemId) values(177, 286)
insert into UserGameItems(UserGameId, ItemId) values(177, 287)
insert into UserGameItems(UserGameId, ItemId) values(177, 288)
insert into UserGameItems(UserGameId, ItemId) values(177, 289)
insert into UserGameItems(UserGameId, ItemId) values(177, 290)
insert into UserGameItems(UserGameId, ItemId) values(177, 291)
insert into UserGameItems(UserGameId, ItemId) values(177, 292)
insert into UserGameItems(UserGameId, ItemId) values(177, 293)
insert into UserGameItems(UserGameId, ItemId) values(177, 294)
insert into UserGameItems(UserGameId, ItemId) values(177, 295)
insert into UserGameItems(UserGameId, ItemId) values(177, 296)
insert into UserGameItems(UserGameId, ItemId) values(177, 297)
insert into UserGameItems(UserGameId, ItemId) values(177, 298)
insert into UserGameItems(UserGameId, ItemId) values(177, 299)

-- FIFTH

insert into UserGameItems(UserGameId, ItemId) values(296, 251)
insert into UserGameItems(UserGameId, ItemId) values(296, 252)
insert into UserGameItems(UserGameId, ItemId) values(296, 253)
insert into UserGameItems(UserGameId, ItemId) values(296, 254)
insert into UserGameItems(UserGameId, ItemId) values(296, 255)
insert into UserGameItems(UserGameId, ItemId) values(296, 256)
insert into UserGameItems(UserGameId, ItemId) values(296, 257)
insert into UserGameItems(UserGameId, ItemId) values(296, 258)
insert into UserGameItems(UserGameId, ItemId) values(296, 259)
insert into UserGameItems(UserGameId, ItemId) values(296, 260)
insert into UserGameItems(UserGameId, ItemId) values(296, 261)
insert into UserGameItems(UserGameId, ItemId) values(296, 262)
insert into UserGameItems(UserGameId, ItemId) values(296, 263)
insert into UserGameItems(UserGameId, ItemId) values(296, 264)
insert into UserGameItems(UserGameId, ItemId) values(296, 265)
insert into UserGameItems(UserGameId, ItemId) values(296, 266)
insert into UserGameItems(UserGameId, ItemId) values(296, 267)
insert into UserGameItems(UserGameId, ItemId) values(296, 268)
insert into UserGameItems(UserGameId, ItemId) values(296, 269)
insert into UserGameItems(UserGameId, ItemId) values(296, 270)
insert into UserGameItems(UserGameId, ItemId) values(296, 271)
insert into UserGameItems(UserGameId, ItemId) values(296, 272)
insert into UserGameItems(UserGameId, ItemId) values(296, 273)
insert into UserGameItems(UserGameId, ItemId) values(296, 274)
insert into UserGameItems(UserGameId, ItemId) values(296, 275)
insert into UserGameItems(UserGameId, ItemId) values(296, 276)
insert into UserGameItems(UserGameId, ItemId) values(296, 277)
insert into UserGameItems(UserGameId, ItemId) values(296, 278)
insert into UserGameItems(UserGameId, ItemId) values(296, 279)
insert into UserGameItems(UserGameId, ItemId) values(296, 280)
insert into UserGameItems(UserGameId, ItemId) values(296, 281)
insert into UserGameItems(UserGameId, ItemId) values(296, 282)
insert into UserGameItems(UserGameId, ItemId) values(296, 283)
insert into UserGameItems(UserGameId, ItemId) values(296, 284)
insert into UserGameItems(UserGameId, ItemId) values(296, 285)
insert into UserGameItems(UserGameId, ItemId) values(296, 286)
insert into UserGameItems(UserGameId, ItemId) values(296, 287)
insert into UserGameItems(UserGameId, ItemId) values(296, 288)
insert into UserGameItems(UserGameId, ItemId) values(296, 289)
insert into UserGameItems(UserGameId, ItemId) values(296, 290)
insert into UserGameItems(UserGameId, ItemId) values(296, 291)
insert into UserGameItems(UserGameId, ItemId) values(296, 292)
insert into UserGameItems(UserGameId, ItemId) values(296, 293)
insert into UserGameItems(UserGameId, ItemId) values(296, 294)
insert into UserGameItems(UserGameId, ItemId) values(296, 295)
insert into UserGameItems(UserGameId, ItemId) values(296, 296)
insert into UserGameItems(UserGameId, ItemId) values(296, 297)
insert into UserGameItems(UserGameId, ItemId) values(296, 298)
insert into UserGameItems(UserGameId, ItemId) values(296, 299)

-- NEXT ITEMS


-- FIRST

insert into UserGameItems(UserGameId, ItemId) values(26, 501)
insert into UserGameItems(UserGameId, ItemId) values(26, 502)
insert into UserGameItems(UserGameId, ItemId) values(26, 503)
insert into UserGameItems(UserGameId, ItemId) values(26, 504)
insert into UserGameItems(UserGameId, ItemId) values(26, 505)
insert into UserGameItems(UserGameId, ItemId) values(26, 506)
insert into UserGameItems(UserGameId, ItemId) values(26, 507)
insert into UserGameItems(UserGameId, ItemId) values(26, 508)
insert into UserGameItems(UserGameId, ItemId) values(26, 509)
insert into UserGameItems(UserGameId, ItemId) values(26, 510)
insert into UserGameItems(UserGameId, ItemId) values(26, 511)
insert into UserGameItems(UserGameId, ItemId) values(26, 512)
insert into UserGameItems(UserGameId, ItemId) values(26, 513)
insert into UserGameItems(UserGameId, ItemId) values(26, 514)
insert into UserGameItems(UserGameId, ItemId) values(26, 515)
insert into UserGameItems(UserGameId, ItemId) values(26, 516)
insert into UserGameItems(UserGameId, ItemId) values(26, 517)
insert into UserGameItems(UserGameId, ItemId) values(26, 518)
insert into UserGameItems(UserGameId, ItemId) values(26, 519)
insert into UserGameItems(UserGameId, ItemId) values(26, 520)
insert into UserGameItems(UserGameId, ItemId) values(26, 521)
insert into UserGameItems(UserGameId, ItemId) values(26, 522)
insert into UserGameItems(UserGameId, ItemId) values(26, 523)
insert into UserGameItems(UserGameId, ItemId) values(26, 524)
insert into UserGameItems(UserGameId, ItemId) values(26, 525)
insert into UserGameItems(UserGameId, ItemId) values(26, 526)
insert into UserGameItems(UserGameId, ItemId) values(26, 527)
insert into UserGameItems(UserGameId, ItemId) values(26, 528)
insert into UserGameItems(UserGameId, ItemId) values(26, 529)
insert into UserGameItems(UserGameId, ItemId) values(26, 530)
insert into UserGameItems(UserGameId, ItemId) values(26, 531)
insert into UserGameItems(UserGameId, ItemId) values(26, 532)
insert into UserGameItems(UserGameId, ItemId) values(26, 533)
insert into UserGameItems(UserGameId, ItemId) values(26, 534)
insert into UserGameItems(UserGameId, ItemId) values(26, 535)
insert into UserGameItems(UserGameId, ItemId) values(26, 536)
insert into UserGameItems(UserGameId, ItemId) values(26, 537)
insert into UserGameItems(UserGameId, ItemId) values(26, 538)
insert into UserGameItems(UserGameId, ItemId) values(26, 539)

-- SECOND

insert into UserGameItems(UserGameId, ItemId) values(115, 501)
insert into UserGameItems(UserGameId, ItemId) values(115, 502)
insert into UserGameItems(UserGameId, ItemId) values(115, 503)
insert into UserGameItems(UserGameId, ItemId) values(115, 504)
insert into UserGameItems(UserGameId, ItemId) values(115, 505)
insert into UserGameItems(UserGameId, ItemId) values(115, 506)
insert into UserGameItems(UserGameId, ItemId) values(115, 507)
insert into UserGameItems(UserGameId, ItemId) values(115, 508)
insert into UserGameItems(UserGameId, ItemId) values(115, 509)
insert into UserGameItems(UserGameId, ItemId) values(115, 510)
insert into UserGameItems(UserGameId, ItemId) values(115, 511)
insert into UserGameItems(UserGameId, ItemId) values(115, 512)
insert into UserGameItems(UserGameId, ItemId) values(115, 513)
insert into UserGameItems(UserGameId, ItemId) values(115, 514)
insert into UserGameItems(UserGameId, ItemId) values(115, 515)
insert into UserGameItems(UserGameId, ItemId) values(115, 516)
insert into UserGameItems(UserGameId, ItemId) values(115, 517)
insert into UserGameItems(UserGameId, ItemId) values(115, 518)
insert into UserGameItems(UserGameId, ItemId) values(115, 519)
insert into UserGameItems(UserGameId, ItemId) values(115, 520)
insert into UserGameItems(UserGameId, ItemId) values(115, 521)
insert into UserGameItems(UserGameId, ItemId) values(115, 522)
insert into UserGameItems(UserGameId, ItemId) values(115, 523)
insert into UserGameItems(UserGameId, ItemId) values(115, 524)
insert into UserGameItems(UserGameId, ItemId) values(115, 525)
insert into UserGameItems(UserGameId, ItemId) values(115, 526)
insert into UserGameItems(UserGameId, ItemId) values(115, 527)
insert into UserGameItems(UserGameId, ItemId) values(115, 528)
insert into UserGameItems(UserGameId, ItemId) values(115, 529)
insert into UserGameItems(UserGameId, ItemId) values(115, 530)
insert into UserGameItems(UserGameId, ItemId) values(115, 531)
insert into UserGameItems(UserGameId, ItemId) values(115, 532)
insert into UserGameItems(UserGameId, ItemId) values(115, 533)
insert into UserGameItems(UserGameId, ItemId) values(115, 534)
insert into UserGameItems(UserGameId, ItemId) values(115, 535)
insert into UserGameItems(UserGameId, ItemId) values(115, 536)
insert into UserGameItems(UserGameId, ItemId) values(115, 537)
insert into UserGameItems(UserGameId, ItemId) values(115, 538)
insert into UserGameItems(UserGameId, ItemId) values(115, 539)

-- THIRD

insert into UserGameItems(UserGameId, ItemId) values(146, 501)
insert into UserGameItems(UserGameId, ItemId) values(146, 502)
insert into UserGameItems(UserGameId, ItemId) values(146, 503)
insert into UserGameItems(UserGameId, ItemId) values(146, 504)
insert into UserGameItems(UserGameId, ItemId) values(146, 505)
insert into UserGameItems(UserGameId, ItemId) values(146, 506)
insert into UserGameItems(UserGameId, ItemId) values(146, 507)
insert into UserGameItems(UserGameId, ItemId) values(146, 508)
insert into UserGameItems(UserGameId, ItemId) values(146, 509)
insert into UserGameItems(UserGameId, ItemId) values(146, 510)
insert into UserGameItems(UserGameId, ItemId) values(146, 511)
insert into UserGameItems(UserGameId, ItemId) values(146, 512)
insert into UserGameItems(UserGameId, ItemId) values(146, 513)
insert into UserGameItems(UserGameId, ItemId) values(146, 514)
insert into UserGameItems(UserGameId, ItemId) values(146, 515)
insert into UserGameItems(UserGameId, ItemId) values(146, 516)
insert into UserGameItems(UserGameId, ItemId) values(146, 517)
insert into UserGameItems(UserGameId, ItemId) values(146, 518)
insert into UserGameItems(UserGameId, ItemId) values(146, 519)
insert into UserGameItems(UserGameId, ItemId) values(146, 520)
insert into UserGameItems(UserGameId, ItemId) values(146, 521)
insert into UserGameItems(UserGameId, ItemId) values(146, 522)
insert into UserGameItems(UserGameId, ItemId) values(146, 523)
insert into UserGameItems(UserGameId, ItemId) values(146, 524)
insert into UserGameItems(UserGameId, ItemId) values(146, 525)
insert into UserGameItems(UserGameId, ItemId) values(146, 526)
insert into UserGameItems(UserGameId, ItemId) values(146, 527)
insert into UserGameItems(UserGameId, ItemId) values(146, 528)
insert into UserGameItems(UserGameId, ItemId) values(146, 529)
insert into UserGameItems(UserGameId, ItemId) values(146, 530)
insert into UserGameItems(UserGameId, ItemId) values(146, 531)
insert into UserGameItems(UserGameId, ItemId) values(146, 532)
insert into UserGameItems(UserGameId, ItemId) values(146, 533)
insert into UserGameItems(UserGameId, ItemId) values(146, 534)
insert into UserGameItems(UserGameId, ItemId) values(146, 535)
insert into UserGameItems(UserGameId, ItemId) values(146, 536)
insert into UserGameItems(UserGameId, ItemId) values(146, 537)
insert into UserGameItems(UserGameId, ItemId) values(146, 538)
insert into UserGameItems(UserGameId, ItemId) values(146, 539)

-- FOURTH

insert into UserGameItems(UserGameId, ItemId) values(177, 501)
insert into UserGameItems(UserGameId, ItemId) values(177, 502)
insert into UserGameItems(UserGameId, ItemId) values(177, 503)
insert into UserGameItems(UserGameId, ItemId) values(177, 504)
insert into UserGameItems(UserGameId, ItemId) values(177, 505)
insert into UserGameItems(UserGameId, ItemId) values(177, 506)
insert into UserGameItems(UserGameId, ItemId) values(177, 507)
insert into UserGameItems(UserGameId, ItemId) values(177, 508)
insert into UserGameItems(UserGameId, ItemId) values(177, 509)
insert into UserGameItems(UserGameId, ItemId) values(177, 510)
insert into UserGameItems(UserGameId, ItemId) values(177, 511)
insert into UserGameItems(UserGameId, ItemId) values(177, 512)
insert into UserGameItems(UserGameId, ItemId) values(177, 513)
insert into UserGameItems(UserGameId, ItemId) values(177, 514)
insert into UserGameItems(UserGameId, ItemId) values(177, 515)
insert into UserGameItems(UserGameId, ItemId) values(177, 516)
insert into UserGameItems(UserGameId, ItemId) values(177, 517)
insert into UserGameItems(UserGameId, ItemId) values(177, 518)
insert into UserGameItems(UserGameId, ItemId) values(177, 519)
insert into UserGameItems(UserGameId, ItemId) values(177, 520)
insert into UserGameItems(UserGameId, ItemId) values(177, 521)
insert into UserGameItems(UserGameId, ItemId) values(177, 522)
insert into UserGameItems(UserGameId, ItemId) values(177, 523)
insert into UserGameItems(UserGameId, ItemId) values(177, 524)
insert into UserGameItems(UserGameId, ItemId) values(177, 525)
insert into UserGameItems(UserGameId, ItemId) values(177, 526)
insert into UserGameItems(UserGameId, ItemId) values(177, 527)
insert into UserGameItems(UserGameId, ItemId) values(177, 528)
insert into UserGameItems(UserGameId, ItemId) values(177, 529)
insert into UserGameItems(UserGameId, ItemId) values(177, 530)
insert into UserGameItems(UserGameId, ItemId) values(177, 531)
insert into UserGameItems(UserGameId, ItemId) values(177, 532)
insert into UserGameItems(UserGameId, ItemId) values(177, 533)
insert into UserGameItems(UserGameId, ItemId) values(177, 534)
insert into UserGameItems(UserGameId, ItemId) values(177, 535)
insert into UserGameItems(UserGameId, ItemId) values(177, 536)
insert into UserGameItems(UserGameId, ItemId) values(177, 537)
insert into UserGameItems(UserGameId, ItemId) values(177, 538)
insert into UserGameItems(UserGameId, ItemId) values(177, 539)

-- FIFTH

insert into UserGameItems(UserGameId, ItemId) values(296, 501)
insert into UserGameItems(UserGameId, ItemId) values(296, 502)
insert into UserGameItems(UserGameId, ItemId) values(296, 503)
insert into UserGameItems(UserGameId, ItemId) values(296, 504)
insert into UserGameItems(UserGameId, ItemId) values(296, 505)
insert into UserGameItems(UserGameId, ItemId) values(296, 506)
insert into UserGameItems(UserGameId, ItemId) values(296, 507)
insert into UserGameItems(UserGameId, ItemId) values(296, 508)
insert into UserGameItems(UserGameId, ItemId) values(296, 509)
insert into UserGameItems(UserGameId, ItemId) values(296, 510)
insert into UserGameItems(UserGameId, ItemId) values(296, 511)
insert into UserGameItems(UserGameId, ItemId) values(296, 512)
insert into UserGameItems(UserGameId, ItemId) values(296, 513)
insert into UserGameItems(UserGameId, ItemId) values(296, 514)
insert into UserGameItems(UserGameId, ItemId) values(296, 515)
insert into UserGameItems(UserGameId, ItemId) values(296, 516)
insert into UserGameItems(UserGameId, ItemId) values(296, 517)
insert into UserGameItems(UserGameId, ItemId) values(296, 518)
insert into UserGameItems(UserGameId, ItemId) values(296, 519)
insert into UserGameItems(UserGameId, ItemId) values(296, 520)
insert into UserGameItems(UserGameId, ItemId) values(296, 521)
insert into UserGameItems(UserGameId, ItemId) values(296, 522)
insert into UserGameItems(UserGameId, ItemId) values(296, 523)
insert into UserGameItems(UserGameId, ItemId) values(296, 524)
insert into UserGameItems(UserGameId, ItemId) values(296, 525)
insert into UserGameItems(UserGameId, ItemId) values(296, 526)
insert into UserGameItems(UserGameId, ItemId) values(296, 527)
insert into UserGameItems(UserGameId, ItemId) values(296, 528)
insert into UserGameItems(UserGameId, ItemId) values(296, 529)
insert into UserGameItems(UserGameId, ItemId) values(296, 530)
insert into UserGameItems(UserGameId, ItemId) values(296, 531)
insert into UserGameItems(UserGameId, ItemId) values(296, 532)
insert into UserGameItems(UserGameId, ItemId) values(296, 533)
insert into UserGameItems(UserGameId, ItemId) values(296, 534)
insert into UserGameItems(UserGameId, ItemId) values(296, 535)
insert into UserGameItems(UserGameId, ItemId) values(296, 536)
insert into UserGameItems(UserGameId, ItemId) values(296, 537)
insert into UserGameItems(UserGameId, ItemId) values(296, 538)
insert into UserGameItems(UserGameId, ItemId) values(296, 539)

-- Select all users in the current game with their items. 
-- Display username, game name, cash and item name. 
-- Sort the result by username alphabetically, then by item name alphabetically.

select 
	u.Username as [Username],
	g.Name as [Name],
	REPLACE(CONVERT(nvarchar(max), ug.Cash), ',', '.') as [Cash],
	i.Name as [Item Name]
from UsersGames ug
join Users u on u.Id = ug.UserId
join Games g on g.Id = ug.GameId
join UserGameItems ugi on ugi.UserGameId = ug.Id
join Items i on i.Id = ugi.ItemId
where g.Name = 'Bali' 
order by u.Username, i.Name