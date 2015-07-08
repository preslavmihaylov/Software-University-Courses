--------------------------------------------------------------------------------------------------------
-- Problem 1.	Create a table in SQL Server
--------------------------------------------------------------------------------------------------------

-- Your task is to create a table in SQL Server with 10 000 000 entries (date + text). 
-- Search in the table by date range. Check the speed (without caching).

-- Don't forget to turn on the Perform Maintenance Tasks in the syspol.msc
create database [7.Performance]

USE [7.Performance]
GO

-- Modify Autogrowth and initial db size to speed up inserting records
ALTER DATABASE [7.Performance] 
modify FILE (name=[7.Performance_log], filegrowth=1000mb)
GO

ALTER DATABASE [7.Performance] 
modify FILE (name=[7.Performance], filegrowth=1000mb)
GO

Create table Tasks
	(TaskID int NOT NULL PRIMARY KEY IDENTITY,
	DateDone smalldatetime NOT NULL,
	Task nvarchar(50) NOT NULL);

-- insert 2 000 000 records (Since 10 000 000 is too much for my HDD)
DECLARE @n int = 2000000

BEGIN TRANSACTION
WHILE(@n>0)
BEGIN
INSERT INTO Tasks
VALUES (GETDATE(), ('Text' + convert(nvarchar,@n)))
SET @n = @n - 1
END
COMMIT TRANSACTION

-- Inserting 2 000 000 records took me 3 minutes

--------------------------------------------------------------------------------------------------------
-- Problem 2.	Add an index to speed-up the search by date 
--------------------------------------------------------------------------------------------------------

-- Without index - took me quite fast anyways but still Clustered Index Scan, Maybe If I clear the cache, it would take me longer.
-- I would appreciate a comment on how to clean the cache as I wasn't able to find any hints
Select * from Tasks where Task = 'Text2789225'

CREATE NONCLUSTERED INDEX [IX_Date_Task] ON [dbo].Tasks 
(
	[Task],
	DateDone
) ON [PRIMARY]

-- This time, it was Index Seek
Select * from Tasks where Task = 'Text2789225'