USE [DB11V2]

DROP TABLE Attendance
DROP TABLE Result
--DROP TABLE EmployeeSemester_MTM
DROP TABLE TimetableTimeslot_MTM
DROP TABLE Timetable
DROP TABLE Timeslot
DROP TABLE WorkingDays
--DROP TABLE EmployeeCourse_MTM
DROP TABLE EmployeeCourseSemester_MTM
DROP TABLE CourseSemester_MTM
DROP TABLE Course
DROP TABLE Employee
DROP TABLE Student
DROP TABLE Person
DROP TABLE Semester
DROP TABLE Batch

CREATE TABLE Person (
ID int PRIMARY KEY IDENTITY(1,1),
CNIC varchar(20),
Name varchar(50),
FatherName varchar(50),
Address varchar(150),
Contact varchar(20)
)

CREATE TABLE Employee(
PersonID int PRIMARY KEY,
Designation varchar(20),
Salary varchar(20),
CONSTRAINT FK_PersonEmployee FOREIGN KEY (PersonID) REFERENCES Person(ID), -- ON DELETE CASCADE,
)

CREATE TABLE Batch (
ID int PRIMARY KEY IDENTITY(1,1),
Session varchar(20),
)

CREATE TABLE Semester(
ID int PRIMARY KEY IDENTITY(1,1),
Name varchar(20),
BatchID int,
CONSTRAINT FK_BatchSemester FOREIGN KEY (BatchID) REFERENCES Batch(ID), -- ON DELETE CASCADE
)

CREATE TABLE Course (
ID int PRIMARY KEY IDENTITY(1,1),
Name varchar(50),
)

--CREATE TABLE EmployeeCourse_MTM (
--ID int PRIMARY KEY IDENTITY(1,1),
--EmployeeID int,
--CourseID int,
--CONSTRAINT FK_EmployeeEmployeeCourse FOREIGN KEY (EmployeeID) REFERENCES Employee(PersonID), -- ON DELETE CASCADE,
--CONSTRAINT FK_CourseEmployeeCourse FOREIGN KEY (CourseID) REFERENCES Course(ID), -- ON DELETE CASCADE
--)

CREATE TABLE CourseSemester_MTM(
ID int PRIMARY KEY IDENTITY(1,1),
CourseID int, 
SemesterID int, 
CONSTRAINT FK_CourseCourseSemester FOREIGN KEY (CourseID) REFERENCES Course(ID), -- ON DELETE CASCADE,
CONSTRAINT FK_SemesterCourseSemester FOREIGN KEY (SemesterID) REFERENCES Semester(ID), -- ON DELETE CASCADE
)

--CREATE TABLE CourseResult_MTM(
--ID int PRIMARY KEY IDENTITY(1,1),
--CourseID int,
--ResultID int, 
--CONSTRAINT FK_CourseCourseResult FOREIGN KEY (CourseID) REFERENCES Course(ID),
--CONSTRAINT FK_ResultCourseResult FOREIGN KEY (ResultID) REFERENCES Result(ID),
--)

CREATE TABLE EmployeeCourseSemester_MTM(
ID int PRIMARY KEY IDENTITY(1,1),
EmployeeID int,
CourseSemesterID int,
CONSTRAINT FK_EmployeeEmployeeCourseSemester FOREIGN KEY (EmployeeID) REFERENCES Employee(PersonID), -- ON DELETE CASCADE,
CONSTRAINT FK_CourseSemesterEmployeeCourseSemester FOREIGN KEY (CourseSemesterID) REFERENCES CourseSemester_MTM(ID), -- ON DELETE CASCADE,
)

CREATE TABLE Student(
PersonID int PRIMARY KEY,
SemesterID int,
--EmployeeCourseID int,
BatchID int,
RegNo varchar(20),
Fee varchar(20),
CONSTRAINT FK_PersonStudent FOREIGN KEY (PersonID) REFERENCES Person(ID), -- ON DELETE CASCADE,
CONSTRAINT FK_SemesterStudent FOREIGN KEY (SemesterID) REFERENCES Semester(ID), -- ON DELETE CASCADE,
--CONSTRAINT FK_EmployeeCourseStudent FOREIGN KEY (EmployeeCourseID) REFERENCES EmployeeCourse_MTM(ID) ON DELETE CASCADE,
CONSTRAINT FK_BatchStudent FOREIGN KEY (BatchID) REFERENCES Batch(ID) -- ON DELETE CASCADE
)

CREATE TABLE Attendance(
ID int PRIMARY KEY IDENTITY(1,1),
StudentID int,
AtdDate DateTime, 
AtdStatus varchar(10),
CourseSemesterID int,
CONSTRAINT FK_AttendanceCourseSemester FOREIGN KEY (CourseSemesterID) REFERENCES CourseSemester_MTM(ID), -- ON DELETE CASCADE,
CONSTRAINT FK_StudentAttendance FOREIGN KEY (StudentID) REFERENCES Student(PersonID), -- ON DELETE CASCADE
)

CREATE TABLE Result(
ID int PRIMARY KEY IDENTITY(1,1),
StudentID int,
CourseSemesterID int,
ObtainedMarks varchar(20),
TotalMarks varchar(10),
CONSTRAINT FK_StudentResult FOREIGN KEY (StudentID) REFERENCES Student(PersonID),-- ON DELETE CASCADE,
CONSTRAINT FK_CourseSemesterResult FOREIGN KEY (CourseSemesterID) REFERENCES CourseSemester_MTM(ID),-- ON DELETE CASCADE
)

CREATE TABLE WorkingDays(
ID int PRIMARY KEY IDENTITY(1,1),
Name varchar(10)
)

CREATE TABLE Timeslot(
ID int PRIMARY KEY IDENTITY(1,1),
EmployeeCourseSemesterID int,
StartTime DateTime,
EndTime DateTime,
WorkingDaysID int,
IsExam BIT DEFAULT 0,
CONSTRAINT FK_EmployeeCourseSemesterTimeslot FOREIGN KEY (EmployeeCourseSemesterID) REFERENCES EmployeeCourseSemester_MTM(ID),
CONSTRAINT FK_WorkingDaysTimeslot FOREIGN KEY (WorkingDaysID) REFERENCES WorkingDays(ID)
)

CREATE TABLE Timetable(
ID int PRIMARY KEY IDENTITY(1,1),
SemesterID int,
IsDatesheet BIT DEFAULT 0,
CONSTRAINT FK_SemesterTimetable FOREIGN KEY (SemesterID) REFERENCES Semester(ID), -- ON DELETE CASCADE,
)

CREATE TABLE TimetableTimeslot_MTM(
ID int PRIMARY KEY IDENTITY(1,1),
TimetableID int,
TimeslotID int,
CONSTRAINT FK_TimeTableTimetableTimeslot FOREIGN KEY (TimetableID) REFERENCES Timetable(ID), -- ON DELETE CASCADE,
CONSTRAINT FK_TimeslotTimetableTimeslot FOREIGN KEY (TimeslotID) REFERENCES Timeslot(ID), -- ON DELETE CASCADE
)
