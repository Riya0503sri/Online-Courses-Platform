CREATE DATABASE OCP
USE OCP

CREATE TABLE Teachers(
	Id INT identity(1,1) PRIMARY KEY,
	Name VARCHAR(MAX) NOT NULL,
	)

CREATE TABLE Students(
	Id INT identity(1,1) PRIMARY KEY,
	Name VARCHAR(MAX) NOT NULL,
	)

CREATE TABLE Courses(
	Id INT identity(1,1) PRIMARY KEY,
	Name VARCHAR(MAX) NOT NULL,
	TotalDuration INT NOT NULL
	)

CREATE TABLE Schedules(
	Id INT identity(1,1) PRIMARY KEY,
	CourseId INT NOT NULL,
	TeacherId INT NOT NULL,
	Day VARCHAR(MAX) NOT NULL,
	StartTime VARCHAR(200) NOT NULL,
	EndTime VARCHAR(200) NOT NULL,
	CONSTRAINT Course_Id FOREIGN KEY (CourseId) REFERENCES Courses(Id),
	CONSTRAINT Teacher_Id FOREIGN KEY (TeacherId) REFERENCES Teachers(Id)
	)

CREATE TABLE Enrollment(
	Id INT identity(1,1) PRIMARY KEY,
	StudentId INT NOT NULL,
	CourseId INT NOT NULL,
	ScheduleId INT NOT NULL,
	CONSTRAINT Student_Enrollment_Id FOREIGN KEY (StudentId) REFERENCES Students(Id),
	CONSTRAINT Course_Enrollment_Id FOREIGN KEY (CourseId) REFERENCES Courses(Id),
	CONSTRAINT Schedule_Enrollment_Id FOREIGN KEY (ScheduleId) REFERENCES Schedules(Id)
	)

INSERT INTO Teachers (Name)
VALUES
    ('Teacher 1'),
    ('Teacher 2');

INSERT INTO Students (Name)
VALUES
    ('John'),
    ('Ram');

INSERT INTO Courses (Name, TotalDuration)
VALUES
    ('Computer Science', 15),
    ('Mathematics', 12);

-- Schedule 1
INSERT INTO Schedules (CourseId, TeacherId, Day, StartTime, EndTime)
VALUES
    (1, 1, 'Monday', '12:00', '13:00'),
    (1, 1, 'Wednesday', '16:00', '17:00'),
    (1, 1, 'Friday', '12:00', '13:00');
-- Schedule 2
INSERT INTO Schedules (CourseId, TeacherId, Day, StartTime, EndTime)
VALUES
    (1, 2, 'Tuesday', '12:00', '13:00'),
    (1, 2, 'Wednesday', '16:00', '17:00'),
    (1, 2, 'Friday', '12:00', '13:00');

INSERT INTO Enrollment (StudentId, CourseId, ScheduleId)
VALUES
    (1, 1, 1),
    (2, 1, 2);