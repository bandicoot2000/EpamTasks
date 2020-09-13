USE AcademicYear2020_t7

CREATE TABLE Groups(
	GroupId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	GroupName NVARCHAR(30) NOT NULL,
	Specialization NVARCHAR(30) NOT NULL
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
	SubjectId INT FOREIGN KEY REFERENCES Subjects(SubjectId) NOT NULL,
	Examinator NVARCHAR(60) NOT NULL
)

CREATE TABLE Grades(
	GradeId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	PassSubjectId INT FOREIGN KEY REFERENCES PassSubjects(PassSubjectId) NOT NULL,
	StudentId INT FOREIGN KEY REFERENCES Students(StudentId) NOT NULL,
	Grade INT NOT NULL
)