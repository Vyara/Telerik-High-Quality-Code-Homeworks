-- 01. Create a table in SQL Server with 10 000 000 log entries (date + text). 
-- Search in the table by date range. Check the speed (without caching).                               


CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty cache

CREATE TABLE Students(
	StudentId int NOT NULL PRIMARY KEY IDENTITY,
	StudentName varchar(100),
	RecordDate date
)
GO

INSERT INTO Students(StudentName, RecordDate) VALUES ('Isaak Newton', GETDATE())
INSERT INTO Students(StudentName, RecordDate) VALUES ('Stephen Hawking', GETDATE() + 1)
INSERT INTO Students(StudentName, RecordDate) VALUES ('Alan Turing', GETDATE() + 2)
INSERT INTO Students(StudentName, RecordDate) VALUES ('Ada von Lovelace', GETDATE() + 3)
INSERT INTO Students(StudentName, RecordDate) VALUES ('Wolfgang Pauli', GETDATE() + 4)
INSERT INTO Students(StudentName, RecordDate) VALUES ('Carl Sagan', GETDATE() + 5)
INSERT INTO Students(StudentName, RecordDate) VALUES ('Williamina Fleming', GETDATE() + 6)
INSERT INTO Students(StudentName, RecordDate) VALUES ('Edwin Hubble', GETDATE() + 7)
INSERT INTO Students(StudentName, RecordDate) VALUES ('Paul Dirac', GETDATE() + 8)
INSERT INTO Students(StudentName, RecordDate) VALUES ('Albert Einstein', GETDATE() + 9)
GO

DECLARE @Counter int = 0
WHILE (SELECT COUNT(*) FROM Students) < 10000000
BEGIN
	INSERT INTO Students(StudentName, RecordDate)
	SELECT StudentName + CONVERT(varchar, @Counter), GETDATE() + @Counter FROM Students
	SET @Counter = @Counter + 1
END
GO

-- Speed: 00:01:06



-- 2. Add an index to speed-up the search by date. Test the search speed (after 
-- cleaning the cache).                               


CREATE INDEX IDX_Trainers_PostDate
ON Students(RecordDate)

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

SELECT * FROM Students
WHERE RecordDate BETWEEN GETDATE() AND GETDATE() + 15

-- Sped: 00:00:05


-- 03. Add a full text index for the text column. Try to search with and without 
-- the full-text index and compare the speed.                              


-- Adding full-text catalog and full-text index
CREATE FULLTEXT CATALOG StudentNameFullTextCatalog
WITH ACCENT_SENSITIVITY = OFF

CREATE FULLTEXT INDEX ON Students(TrainerName)
KEY INDEX PK__Students__366A1A7C3E923D38
ON StudentNameFullTextCatalog
WITH CHANGE_TRACKING AUTO


-- Searching without full-text index
CHECKPOINT; DBCC DROPCLEANBUFFERS; 
SELECT * FROM Students
WHERE StudentName LIKE 'Stephen%'
GO

-- Speed: 00:00:07

CHECKPOINT; DBCC DROPCLEANBUFFERS; 
SELECT * FROM Students
WHERE StudentName LIKE 'Isaak%'
GO

-- Speed: 00:00:10

-- Searching with full-text index
CHECKPOINT; DBCC DROPCLEANBUFFERS; 
SELECT * FROM Students
WHERE CONTAINS(StudentName, 'Isaak')
GO

-- Speed: 00:00:07

CHECKPOINT; DBCC DROPCLEANBUFFERS; 
SELECT * FROM Students
WHERE CONTAINS(StudentName, 'Stephen')
GO

-- Speed: 00:00:07