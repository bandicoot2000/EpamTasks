USE master
GO
IF DB_ID(N'AcademicYear2020') IS NOT NULL
DROP DATABASE AcademicYear2020;
GO

CREATE DATABASE AcademicYear2020
GO

USE AcademicYear2020

CREATE TABLE Groups(
	GroupId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	GroupName NVARCHAR(30) NOT NULL
)

CREATE TABLE Students(
    StudentId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	SecondName NVARCHAR(30) NOT NULL,
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(30) NOT NULL,
	Gender NVARCHAR(1) NOT NULL,
	Birthday DATE NOT NULL,
	GroupId INT FOREIGN KEY REFERENCES Groups(GroupId) NOT NULL
)

CREATE TABLE SessionTypes(
	SessionTypeId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	SessionTypeName NVARCHAR(20) NOT NULL
)

CREATE TABLE AssessmentForms(
	AssessmentFormId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	AssessmentFormName NVARCHAR(20) NOT NULL
)

CREATE TABLE Subjects(
	SubjectId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	SubjectName NVARCHAR(20) NOT NULL
)

CREATE TABLE PassSubjects(
	PassSubjectId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	GroupId INT FOREIGN KEY REFERENCES Groups(GroupId) NOT NULL,
	SessionTypeId INT FOREIGN KEY REFERENCES SessionTypes(SessionTypeId) NOT NULL, 
	AssessmentFormId INT FOREIGN KEY REFERENCES AssessmentForms(AssessmentFormId) NOT NULL,
	SubjectId INT FOREIGN KEY REFERENCES Subjects(SubjectId) NOT NULL
)

CREATE TABLE Grades(
	GradeId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	PassSubjectId INT FOREIGN KEY REFERENCES PassSubjects(PassSubjectId) NOT NULL,
	StudentId INT FOREIGN KEY REFERENCES Students(StudentId) NOT NULL,
	Grade INT NOT NULL
)

GO

INSERT INTO Groups(GroupName) VALUES ('ITI'), ('ITP');
INSERT INTO Subjects(SubjectName) VALUES ('Math'), ('Chimiy'), ('PE');
INSERT INTO SessionTypes(SessionTypeName) VALUES ('Winter'), ('Summer');
INSERT INTO AssessmentForms(AssessmentFormName) VALUES ('Exem'), ('Test');
GO
INSERT INTO PassSubjects(GroupId, SessionTypeId, AssessmentFormId, SubjectId) 
VALUES (1, 1, 1, 1),
	(1, 1, 2, 3),
	(1, 2, 1, 2),
	(1, 2, 2, 3),
	(2, 1, 2, 2),
	(2, 1, 1, 3),
	(2, 2, 1, 1),
	(2, 2, 2, 2);
INSERT INTO Students(SecondName, FirstName, MiddleName, Gender, Birthday, GroupId) 
VALUES ('Akylich', 'Artem', 'Pavlovich', 'M', '2000-07-21', 1),
	('Akylich', 'Yra', 'Pavlovich', 'M', '2001-07-21', 2),
	('Zyckova', 'Anastasiy', 'Aleksandrovna', 'F', '2002-01-12', 1),
	('Erim', 'Danic', 'Ilich', 'M', '2000-07-21', 2),
	('Fill', 'Pill', 'liii', 'M', '2001-07-21', 1),
	('Chernenko', 'Sasha', 'Yriva', 'F', '1999-11-01', 2);
GO
INSERT INTO Grades(PassSubjectId, StudentId, Grade) 
VALUES (1, 1, 9),
	(1, 3, 6),
	(1, 5, 2),
	(2, 1, 7),
	(2, 3, 10),
	(2, 5, 4),
	(3, 1, 8),
	(3, 3, 9),
	(3, 5, 9),
	(4, 1, 6),
	(4, 3, 5),
	(4, 5, 10),
	(5, 2, 7),
	(5, 4, 1),
	(5, 6, 6),
	(6, 2, 3),
	(6, 4, 7),
	(6, 6, 9),
	(7, 2, 6),
	(7, 4, 6),
	(7, 6, 6),
	(8, 2, 6),
	(8, 4, 5),
	(8, 6, 8);