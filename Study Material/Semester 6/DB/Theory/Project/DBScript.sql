USE [master]
GO
/****** Object:  Database [DB11V2]    Script Date: 5/11/2019 3:55:25 PM ******/
CREATE DATABASE [DB11V2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB11V2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\DB11V2.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DB11V2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\DB11V2_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DB11V2] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB11V2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB11V2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB11V2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB11V2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB11V2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB11V2] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB11V2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB11V2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB11V2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB11V2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB11V2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB11V2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB11V2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB11V2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB11V2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB11V2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DB11V2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB11V2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB11V2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB11V2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB11V2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB11V2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB11V2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB11V2] SET RECOVERY FULL 
GO
ALTER DATABASE [DB11V2] SET  MULTI_USER 
GO
ALTER DATABASE [DB11V2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB11V2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB11V2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB11V2] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DB11V2] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DB11V2', N'ON'
GO
USE [DB11V2]
GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 5/11/2019 3:55:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Attendance](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [int] NULL,
	[AtdDate] [datetime] NULL,
	[AtdStatus] [varchar](10) NULL,
	[CourseSemesterID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Batch]    Script Date: 5/11/2019 3:55:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Batch](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Session] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Course]    Script Date: 5/11/2019 3:55:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Course](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CourseSemester_MTM]    Script Date: 5/11/2019 3:55:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseSemester_MTM](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CourseID] [int] NULL,
	[SemesterID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 5/11/2019 3:55:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[PersonID] [int] NOT NULL,
	[Designation] [varchar](20) NULL,
	[Salary] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmployeeCourseSemester_MTM]    Script Date: 5/11/2019 3:55:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeCourseSemester_MTM](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NULL,
	[CourseSemesterID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Person]    Script Date: 5/11/2019 3:55:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Person](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CNIC] [varchar](20) NULL,
	[Name] [varchar](50) NULL,
	[FatherName] [varchar](50) NULL,
	[Address] [varchar](150) NULL,
	[Contact] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Result]    Script Date: 5/11/2019 3:55:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Result](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [int] NULL,
	[CourseSemesterID] [int] NULL,
	[ObtainedMarks] [varchar](20) NULL,
	[TotalMarks] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Semester]    Script Date: 5/11/2019 3:55:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Semester](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NULL,
	[BatchID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Student]    Script Date: 5/11/2019 3:55:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[PersonID] [int] NOT NULL,
	[SemesterID] [int] NULL,
	[EmployeeCourseID] [int] NULL,
	[BatchID] [int] NULL,
	[RegNo] [varchar](20) NULL,
	[Fee] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Timeslot]    Script Date: 5/11/2019 3:55:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Timeslot](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeCourseSemesterID] [int] NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[WorkingDaysID] [int] NULL,
	[IsExam] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Timetable]    Script Date: 5/11/2019 3:55:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Timetable](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SemesterID] [int] NULL,
	[IsDateSheet] [bit] NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TimetableTimeslot_MTM]    Script Date: 5/11/2019 3:55:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimetableTimeslot_MTM](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TimetableID] [int] NULL,
	[TimeslotID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WorkingDays]    Script Date: 5/11/2019 3:55:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WorkingDays](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Timeslot] ADD  DEFAULT ((0)) FOR [IsExam]
GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_AttendanceCourseSemester] FOREIGN KEY([CourseSemesterID])
REFERENCES [dbo].[CourseSemester_MTM] ([ID])
GO
ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_AttendanceCourseSemester]
GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_StudentAttendance] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([PersonID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_StudentAttendance]
GO
ALTER TABLE [dbo].[CourseSemester_MTM]  WITH CHECK ADD  CONSTRAINT [FK_CourseCourseSemester] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CourseSemester_MTM] CHECK CONSTRAINT [FK_CourseCourseSemester]
GO
ALTER TABLE [dbo].[CourseSemester_MTM]  WITH CHECK ADD  CONSTRAINT [FK_SemesterCourseSemester] FOREIGN KEY([SemesterID])
REFERENCES [dbo].[Semester] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CourseSemester_MTM] CHECK CONSTRAINT [FK_SemesterCourseSemester]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_PersonEmployee] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_PersonEmployee]
GO
ALTER TABLE [dbo].[EmployeeCourseSemester_MTM]  WITH CHECK ADD  CONSTRAINT [FK_CourseSemesterEmployeeCourseSemester] FOREIGN KEY([CourseSemesterID])
REFERENCES [dbo].[CourseSemester_MTM] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeCourseSemester_MTM] CHECK CONSTRAINT [FK_CourseSemesterEmployeeCourseSemester]
GO
ALTER TABLE [dbo].[EmployeeCourseSemester_MTM]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeEmployeeCourseSemester] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([PersonID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeCourseSemester_MTM] CHECK CONSTRAINT [FK_EmployeeEmployeeCourseSemester]
GO
ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_CourseSemesterResult] FOREIGN KEY([CourseSemesterID])
REFERENCES [dbo].[CourseSemester_MTM] ([ID])
GO
ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_CourseSemesterResult]
GO
ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_StudentResult] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([PersonID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_StudentResult]
GO
ALTER TABLE [dbo].[Semester]  WITH CHECK ADD  CONSTRAINT [FK_BatchSemester] FOREIGN KEY([BatchID])
REFERENCES [dbo].[Batch] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Semester] CHECK CONSTRAINT [FK_BatchSemester]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_BatchStudent] FOREIGN KEY([BatchID])
REFERENCES [dbo].[Batch] ([ID])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_BatchStudent]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_PersonStudent] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_PersonStudent]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_SemesterStudent] FOREIGN KEY([SemesterID])
REFERENCES [dbo].[Semester] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_SemesterStudent]
GO
ALTER TABLE [dbo].[Timeslot]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeCourseTimeslot] FOREIGN KEY([EmployeeCourseSemesterID])
REFERENCES [dbo].[EmployeeCourseSemester_MTM] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Timeslot] CHECK CONSTRAINT [FK_EmployeeCourseTimeslot]
GO
ALTER TABLE [dbo].[Timeslot]  WITH CHECK ADD  CONSTRAINT [FK_WorkingDaysTimeslot] FOREIGN KEY([WorkingDaysID])
REFERENCES [dbo].[WorkingDays] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Timeslot] CHECK CONSTRAINT [FK_WorkingDaysTimeslot]
GO
ALTER TABLE [dbo].[Timetable]  WITH CHECK ADD  CONSTRAINT [FK_SemesterTimetable] FOREIGN KEY([SemesterID])
REFERENCES [dbo].[Semester] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Timetable] CHECK CONSTRAINT [FK_SemesterTimetable]
GO
ALTER TABLE [dbo].[TimetableTimeslot_MTM]  WITH CHECK ADD  CONSTRAINT [FK_TimeslotTimetableTimeslot] FOREIGN KEY([TimeslotID])
REFERENCES [dbo].[Timeslot] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TimetableTimeslot_MTM] CHECK CONSTRAINT [FK_TimeslotTimetableTimeslot]
GO
ALTER TABLE [dbo].[TimetableTimeslot_MTM]  WITH CHECK ADD  CONSTRAINT [FK_TimeTableTimetableTimeslot] FOREIGN KEY([TimetableID])
REFERENCES [dbo].[Timetable] ([ID])
GO
ALTER TABLE [dbo].[TimetableTimeslot_MTM] CHECK CONSTRAINT [FK_TimeTableTimetableTimeslot]
GO
/****** Object:  StoredProcedure [dbo].[UP_BatchWiseAttendaceReport]    Script Date: 5/11/2019 3:55:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--3------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[UP_BatchWiseAttendaceReport] @Batch varchar(20)
AS
SELECT Student.RegNo AS Registration, Attendance.AtdStatus AS Status, Semester.Name AS Semester, Course.Name AS Course, Person.Name AS FirstName, Person.FatherName AS LastName, Person.Contact  FROM Attendance JOIN CourseSemester_MTM ON CourseSemester_MTM.ID = Attendance.CourseSemesterID JOIN Semester ON Semester.ID = CourseSemester_MTM.SemesterID JOIN Batch ON Batch.ID = Semester.BatchID JOIN Person ON Person.ID = Attendance.StudentID JOIN Student ON Student.PersonID = Attendance.StudentID JOIN Course ON Course.ID = CourseSemester_MTM.CourseID WHERE Batch.Session = @Batch

GO
/****** Object:  StoredProcedure [dbo].[UP_BatchWiseResultReport]    Script Date: 5/11/2019 3:55:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--8------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[UP_BatchWiseResultReport] @Batch varchar(20)
AS
SELECT Student.RegNo AS Registration, CAST(((CAST(Result.ObtainedMarks AS float)) / (CAST(Result.TotalMarks AS float))*100) AS DECIMAL(5, 2)) AS Percentage, Course.Name AS Course, Semester.Name AS Semester, Person.Name AS FirstName, Person.FatherName AS LastName FROM Result JOIN Person ON Person.ID = Result.StudentID JOIN CourseSemester_MTM ON CourseSemester_MTM.ID = Result.CourseSemesterID JOIN Course ON Course.ID = CourseSemester_MTM.CourseID JOIN Semester ON Semester.ID = CourseSemester_MTM.SemesterID JOIN Batch ON Batch.ID = Semester.BatchID JOIN Student ON Student.PersonID = Result.StudentID WHERE Batch.Session = @Batch

GO
/****** Object:  StoredProcedure [dbo].[UP_BatchWiseStudentReport]    Script Date: 5/11/2019 3:55:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UP_BatchWiseStudentReport] @Batch varchar(20)
AS
SELECT Student.RegNo AS Registration, Semester.Name AS Semester, Person.Name AS FirstName, Person.FatherName AS LastName, Person.Contact FROM Person JOIN Student ON Person.ID = Student.PersonID JOIN Semester ON Semester.ID = Student.SemesterID JOIN Batch ON Semester.BatchID = Batch.ID WHERE Batch.Session = @Batch

GO
/****** Object:  StoredProcedure [dbo].[UP_CourseWiseEmployeeReport]    Script Date: 5/11/2019 3:55:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--5------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[UP_CourseWiseEmployeeReport] @Course varchar(50)
AS
SELECT DISTINCT Employee.Designation, Employee.Salary, Person.Name AS FirstName, Person.FatherName AS LastName, Person.Contact  FROM Employee JOIN EmployeeCourseSemester_MTM ON EmployeeCourseSemester_MTM.EmployeeID = Employee.PersonID JOIN CourseSemester_MTM ON CourseSemester_MTM.ID = EmployeeCourseSemester_MTM.CourseSemesterID JOIN Course ON Course.ID = CourseSemester_MTM.CourseID JOIN Person ON Person.ID = Employee.PersonID JOIN Semester ON Semester.ID = CourseSemester_MTM.SemesterID JOIN Batch ON Batch.ID = Semester.BatchID WHERE Course.Name = @Course

GO
/****** Object:  StoredProcedure [dbo].[UP_CourseWiseResultReport]    Script Date: 5/11/2019 3:55:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--7------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[UP_CourseWiseResultReport] @Course varchar(50)
AS
SELECT Student.RegNo AS Registration, CAST(((CAST(Result.ObtainedMarks AS float)) / (CAST(Result.TotalMarks AS float))*100) AS DECIMAL(5, 2)) AS Percentage, Semester.Name AS Semester, Person.Name AS FirstName, Person.FatherName AS LastName FROM Result JOIN Person ON Person.ID = Result.StudentID JOIN CourseSemester_MTM ON CourseSemester_MTM.ID = Result.CourseSemesterID JOIN Course ON Course.ID = CourseSemester_MTM.CourseID JOIN Semester ON Semester.ID = CourseSemester_MTM.SemesterID JOIN Batch ON Batch.ID = Semester.BatchID JOIN Student ON Student.PersonID = Result.StudentID WHERE Course.Name = @Course

GO
/****** Object:  StoredProcedure [dbo].[UP_CourseWiseStudentReport]    Script Date: 5/11/2019 3:55:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--2------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[UP_CourseWiseStudentReport] @Course varchar(50)
AS
SELECT Student.RegNo AS Registration, Semester.Name AS Semester, Person.Name AS FirstName, Person.FatherName AS LastName, Person.Contact FROM Student JOIN EmployeeCourseSemester_MTM ON EmployeeCourseSemester_MTM.ID = Student.EmployeeCourseID JOIN CourseSemester_MTM ON CourseSemester_MTM.ID = EmployeeCourseSemester_MTM.CourseSemesterID JOIN Course ON Course.ID = CourseSemester_MTM.CourseID JOIN Semester ON CourseSemester_MTM.SemesterID = Semester.ID JOIN Batch ON Batch.ID = Semester.BatchID JOIN Person ON Person.ID = Student.PersonID WHERE Course.Name  = @Course

GO
/****** Object:  StoredProcedure [dbo].[up_getBath]    Script Date: 5/11/2019 3:55:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[up_getBath] @Session varchar(20)
AS
SELECT * FROM Batch WHERE Session = @Session

GO
/****** Object:  StoredProcedure [dbo].[UP_SalaryReport]    Script Date: 5/11/2019 3:55:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--10------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[UP_SalaryReport]
AS
SELECT DISTINCT Employee.Designation, Employee.Salary AS MonthlySalary, (YEAR(getdate()) - CAST(Batch.Session AS INT))*Employee.Salary AS TotalPaid, YEAR(getdate()) - CAST(Batch.Session AS INT) AS ServiceYears , Person.Name, Person.Contact FROM Employee JOIN EmployeeCourseSemester_MTM ON EmployeeCourseSemester_MTM.EmployeeID = Employee.PersonID JOIN CourseSemester_MTM ON  CourseSemester_MTM.ID = EmployeeCourseSemester_MTM.CourseSemesterID JOIN Semester ON Semester.ID = CourseSemester_MTM.SemesterID JOIN Batch ON Batch.ID = Semester.BatchID JOIN Person ON Person.ID = Employee.PersonID
WHERE Batch.Session = (SELECT MIN(Batch.Session) FROM EmployeeCourseSemester_MTM JOIN CourseSemester_MTM ON EmployeeCourseSemester_MTM.CourseSemesterID = CourseSemester_MTM.ID JOIN Semester ON Semester.ID = CourseSemester_MTM.SemesterID JOIN Batch ON Batch.ID = Semester.BatchID WHERE EmployeeCourseSemester_MTM.EmployeeID = Employee.PersonID)

GO
/****** Object:  StoredProcedure [dbo].[UP_SemesterWiseAttendaceReport]    Script Date: 5/11/2019 3:55:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--4-----------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[UP_SemesterWiseAttendaceReport] @Semester varchar(20)
AS
SELECT Student.RegNo AS Registration, Attendance.AtdStatus AS Status, Course.Name AS Course, Person.Name AS FirstName, Person.FatherName AS LastName, Person.Contact  FROM Attendance JOIN CourseSemester_MTM ON CourseSemester_MTM.ID = Attendance.CourseSemesterID JOIN Semester ON Semester.ID = CourseSemester_MTM.SemesterID JOIN Batch ON Batch.ID = Semester.BatchID JOIN Person ON Person.ID = Attendance.StudentID JOIN Student ON Student.PersonID = Attendance.StudentID JOIN Course ON Course.ID = CourseSemester_MTM.CourseID WHERE Semester.Name = @Semester

GO
/****** Object:  StoredProcedure [dbo].[UP_SemesterWiseEmployeeReport]    Script Date: 5/11/2019 3:55:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--6-----------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[UP_SemesterWiseEmployeeReport] @Semester varchar(20)
AS
SELECT Employee.Designation, Employee.Salary, Course.Name AS Course, Batch.Session AS Batch, Person.Name AS FirstName, Person.FatherName AS LastName, Person.Contact  FROM Employee JOIN EmployeeCourseSemester_MTM ON EmployeeCourseSemester_MTM.EmployeeID = Employee.PersonID JOIN CourseSemester_MTM ON CourseSemester_MTM.ID = EmployeeCourseSemester_MTM.CourseSemesterID JOIN Course ON Course.ID = CourseSemester_MTM.CourseID JOIN Person ON Person.ID = Employee.PersonID JOIN Semester ON Semester.ID = CourseSemester_MTM.SemesterID JOIN Batch ON Batch.ID = Semester.BatchID WHERE Semester.Name = @Semester

GO
/****** Object:  StoredProcedure [dbo].[UP_StudentFeeReport]    Script Date: 5/11/2019 3:55:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--9------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[UP_StudentFeeReport]
AS
SELECT Student.RegNo AS Registration, Student.Fee AS MonthlyFee, (CAST(Student.Fee AS int))*(CAST(Semester.Name AS int)) AS TotalPaid, Semester.Name AS Semester, Person.Name AS FirstName, Person.FatherName AS LastName, Person.Contact FROM Person JOIN Student ON Person.ID = Student.PersonID JOIN Semester ON Semester.ID = Student.SemesterID

GO
USE [master]
GO
ALTER DATABASE [DB11V2] SET  READ_WRITE 
GO
