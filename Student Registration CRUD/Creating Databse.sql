/*Creating database*/
CREATE DATABASE BelgiumCampusDB;
GO

USE BelgiumCampusDB
GO

/*Creating Tables*/
CREATE TABLE Students (
StudentID int,
LastName VARCHAR(255),
FirstName VARCHAR(255),
DOB VARCHAR(255),
Gender VARCHAR(255),
Phone VARCHAR(255),
Address VARCHAR(255),
ModuleCode VARCHAR(255),
ModuleName VARCHAR(255),
ModDescription VARCHAR(255),
OnLineLink VARCHAR(255),
Image image
);
GO

SELECT * FROM Students
GO

CREATE PROCEDURE spGetStudents
AS
BEGIN
SELECT* FROM Students
END
GO

CREATE PROCEDURE spAddStudents
(
@StudentID INT,
@Name VARCHAR(20),
@Surname VARCHAR(20),
@dob VARCHAR(20),
@Gender VARCHAR(20),
@Phone VARCHAR(20),
@Address VARCHAR(20),
@ModuleCode VARCHAR(20),
@ModuleName VARCHAR(20),
@ModDescription VARCHAR(20),
@OnlineLink VARCHAR(20)
)
AS
BEGIN
INSERT INTO Students
VALUES (@StudentID, @Name, @Surname,@dob,@Gender,@Phone,@Address,@ModuleCode,@ModDescription,@OnlineLink)
END
GO

CREATE PROCEDURE spUpdateStudents
(
@StudentID INT,
@Name VARCHAR(20),
@Surname VARCHAR(20),
@dob VARCHAR(20),
@Gender VARCHAR(20),
@Phone VARCHAR(20),
@Address VARCHAR(20),
@ModuleCode VARCHAR(20),
@ModuleName VARCHAR(20),
@ModDescription VARCHAR(20),
@OnlineLink VARCHAR(20)
)
AS
BEGIN
UPDATE Students
SET StudentID = @StudentID, FirstName = @Name, LastName = @Surname,DOB = @dob, Gender = @Gender,Phone = @Phone,Address = @Address,ModuleCode = @ModuleCode,ModDescription = @ModDescription
WHERE StudentID = @StudentID
END
GO

CREATE PROCEDURE spDeleteStudents
(
@ID INT
)
AS
BEGIN
DELETE FROM Students
WHERE StudentID = @ID
END
GO

CREATE PROCEDURE spSearchStudents
(
@ID INT
)
AS
BEGIN
SELECT * FROM Students
WHERE StudentID = @ID
END
GO



