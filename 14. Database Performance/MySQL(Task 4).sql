
-- 4. Create the same table in MySQL and partition it by date (1990, 2000, 2010). 
-- Fill 1 000 000 log entries. Compare the searching speed in all partitions (random 
-- dates) to certain partition (e.g. year 1995).                           


-- Without partitioning
CREATE SCHEMA `students`;

CREATE TABLE `students`.`logs` (
	`Id` INT NOT NULL AUTO_INCREMENT,
	`StudentrName` TEXT NOT NULL,
	`RecordDate` DATETIME NOT NULL,
	PRIMARY KEY (`Id`));

-- With partitioning
CREATE SCHEMA `students`;

CREATE TABLE `students`.`logs` (
	`Id` INT NOT NULL AUTO_INCREMENT,
	`StudentName` TEXT NOT NULL,
	`RecordDate` DATETIME NOT NULL,
	PRIMARY KEY (`Id`, `RecordDate`)
) PARTITION BY RANGE(YEAR(RecordDate)) (
    PARTITION p0 VALUES LESS THAN (1990),
    PARTITION p1 VALUES LESS THAN (2000),
    PARTITION p2 VALUES LESS THAN (2010),
    PARTITION p3 VALUES LESS THAN MAXVALUE
);

