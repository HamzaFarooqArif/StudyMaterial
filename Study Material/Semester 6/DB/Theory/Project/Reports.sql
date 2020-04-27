DROP PROCEDURE UP_BatchWiseStudentReport
DROP PROCEDURE UP_CourseWiseStudentReport
DROP PROCEDURE UP_BatchWiseAttendaceReport
DROP PROCEDURE UP_SemesterWiseAttendaceReport
DROP PROCEDURE UP_CourseWiseEmployeeReport
DROP PROCEDURE UP_SemesterWiseEmployeeReport
DROP PROCEDURE UP_CourseWiseResultReport
DROP PROCEDURE UP_BatchWiseResultReport
DROP PROCEDURE UP_StudentFeeReport
DROP PROCEDURE UP_SalaryReport

EXEC UP_BatchWiseStudentReport @Batch = 2001
EXEC UP_CourseWiseStudentReport @Course = 'PRV'
EXEC UP_BatchWiseAttendaceReport @Batch = 2003
EXEC UP_SemesterWiseAttendaceReport @Semester = 1
EXEC UP_CourseWiseEmployeeReport @Course = 'PRV'
EXEC UP_SemesterWiseEmployeeReport @Semester = 1
EXEC UP_CourseWiseResultReport @Course = 'PRV'
EXEC UP_BatchWiseResultReport @Batch = 2003
EXEC UP_StudentFeeReport
EXEC UP_SalaryReport

--1-----------------------------------------------------------------------------------
CREATE PROCEDURE UP_BatchWiseStudentReport @Batch varchar(20)
AS
SELECT Student.RegNo AS Registration, Semester.Name AS Semester, Person.Name AS FirstName, Person.FatherName AS LastName, Person.Contact FROM Person JOIN Student ON Person.ID = Student.PersonID JOIN Semester ON Semester.ID = Student.SemesterID JOIN Batch ON Semester.BatchID = Batch.ID WHERE Batch.Session = @Batch
GO
--2------------------------------------------------------------------------------------
CREATE PROCEDURE UP_CourseWiseStudentReport @Course varchar(50)
AS
SELECT Student.RegNo AS Registration, Semester.Name AS Semester, Person.Name AS FirstName, Person.FatherName AS LastName, Person.Contact FROM Student JOIN EmployeeCourseSemester_MTM ON EmployeeCourseSemester_MTM.ID = Student.EmployeeCourseID JOIN CourseSemester_MTM ON CourseSemester_MTM.ID = EmployeeCourseSemester_MTM.CourseSemesterID JOIN Course ON Course.ID = CourseSemester_MTM.CourseID JOIN Semester ON CourseSemester_MTM.SemesterID = Semester.ID JOIN Batch ON Batch.ID = Semester.BatchID JOIN Person ON Person.ID = Student.PersonID WHERE Course.Name  = @Course
GO
--3------------------------------------------------------------------------------------
CREATE PROCEDURE UP_BatchWiseAttendaceReport @Batch varchar(20)
AS
SELECT Student.RegNo AS Registration, Attendance.AtdStatus AS Status, Semester.Name AS Semester, Course.Name AS Course, Person.Name AS FirstName, Person.FatherName AS LastName, Person.Contact  FROM Attendance JOIN CourseSemester_MTM ON CourseSemester_MTM.ID = Attendance.CourseSemesterID JOIN Semester ON Semester.ID = CourseSemester_MTM.SemesterID JOIN Batch ON Batch.ID = Semester.BatchID JOIN Person ON Person.ID = Attendance.StudentID JOIN Student ON Student.PersonID = Attendance.StudentID JOIN Course ON Course.ID = CourseSemester_MTM.CourseID WHERE Batch.Session = @Batch
GO
--4-----------------------------------------------------------------------------------
CREATE PROCEDURE UP_SemesterWiseAttendaceReport @Semester varchar(20)
AS
SELECT Student.RegNo AS Registration, Attendance.AtdStatus AS Status, Course.Name AS Course, Person.Name AS FirstName, Person.FatherName AS LastName, Person.Contact  FROM Attendance JOIN CourseSemester_MTM ON CourseSemester_MTM.ID = Attendance.CourseSemesterID JOIN Semester ON Semester.ID = CourseSemester_MTM.SemesterID JOIN Batch ON Batch.ID = Semester.BatchID JOIN Person ON Person.ID = Attendance.StudentID JOIN Student ON Student.PersonID = Attendance.StudentID JOIN Course ON Course.ID = CourseSemester_MTM.CourseID WHERE Semester.Name = @Semester
GO
--5------------------------------------------------------------------------------------
CREATE PROCEDURE UP_CourseWiseEmployeeReport @Course varchar(50)
AS
SELECT DISTINCT Employee.Designation, Employee.Salary, Person.Name AS FirstName, Person.FatherName AS LastName, Person.Contact  FROM Employee JOIN EmployeeCourseSemester_MTM ON EmployeeCourseSemester_MTM.EmployeeID = Employee.PersonID JOIN CourseSemester_MTM ON CourseSemester_MTM.ID = EmployeeCourseSemester_MTM.CourseSemesterID JOIN Course ON Course.ID = CourseSemester_MTM.CourseID JOIN Person ON Person.ID = Employee.PersonID JOIN Semester ON Semester.ID = CourseSemester_MTM.SemesterID JOIN Batch ON Batch.ID = Semester.BatchID WHERE Course.Name = @Course
GO
--6-----------------------------------------------------------------------------------
CREATE PROCEDURE UP_SemesterWiseEmployeeReport @Semester varchar(20)
AS
SELECT Employee.Designation, Employee.Salary, Course.Name AS Course, Batch.Session AS Batch, Person.Name AS FirstName, Person.FatherName AS LastName, Person.Contact  FROM Employee JOIN EmployeeCourseSemester_MTM ON EmployeeCourseSemester_MTM.EmployeeID = Employee.PersonID JOIN CourseSemester_MTM ON CourseSemester_MTM.ID = EmployeeCourseSemester_MTM.CourseSemesterID JOIN Course ON Course.ID = CourseSemester_MTM.CourseID JOIN Person ON Person.ID = Employee.PersonID JOIN Semester ON Semester.ID = CourseSemester_MTM.SemesterID JOIN Batch ON Batch.ID = Semester.BatchID WHERE Semester.Name = @Semester
GO
--7------------------------------------------------------------------------------------
CREATE PROCEDURE UP_CourseWiseResultReport @Course varchar(50)
AS
SELECT Student.RegNo AS Registration, CAST(((CAST(Result.ObtainedMarks AS float)) / (CAST(Result.TotalMarks AS float))*100) AS DECIMAL(5, 2)) AS Percentage, Semester.Name AS Semester, Person.Name AS FirstName, Person.FatherName AS LastName FROM Result JOIN Person ON Person.ID = Result.StudentID JOIN CourseSemester_MTM ON CourseSemester_MTM.ID = Result.CourseSemesterID JOIN Course ON Course.ID = CourseSemester_MTM.CourseID JOIN Semester ON Semester.ID = CourseSemester_MTM.SemesterID JOIN Batch ON Batch.ID = Semester.BatchID JOIN Student ON Student.PersonID = Result.StudentID WHERE Course.Name = @Course
GO
--8------------------------------------------------------------------------------------
CREATE PROCEDURE UP_BatchWiseResultReport @Batch varchar(20)
AS
SELECT Student.RegNo AS Registration, CAST(((CAST(Result.ObtainedMarks AS float)) / (CAST(Result.TotalMarks AS float))*100) AS DECIMAL(5, 2)) AS Percentage, Course.Name AS Course, Semester.Name AS Semester, Person.Name AS FirstName, Person.FatherName AS LastName FROM Result JOIN Person ON Person.ID = Result.StudentID JOIN CourseSemester_MTM ON CourseSemester_MTM.ID = Result.CourseSemesterID JOIN Course ON Course.ID = CourseSemester_MTM.CourseID JOIN Semester ON Semester.ID = CourseSemester_MTM.SemesterID JOIN Batch ON Batch.ID = Semester.BatchID JOIN Student ON Student.PersonID = Result.StudentID WHERE Batch.Session = @Batch
GO
--9------------------------------------------------------------------------------------
CREATE PROCEDURE UP_StudentFeeReport
AS
SELECT Student.RegNo AS Registration, Student.Fee AS MonthlyFee, (CAST(Student.Fee AS int))*(CAST(Semester.Name AS int)) AS TotalPaid, Semester.Name AS Semester, Person.Name AS FirstName, Person.FatherName AS LastName, Person.Contact FROM Person JOIN Student ON Person.ID = Student.PersonID JOIN Semester ON Semester.ID = Student.SemesterID
GO
--10------------------------------------------------------------------------------------
CREATE PROCEDURE UP_SalaryReport
AS
SELECT DISTINCT Employee.Designation, Employee.Salary AS MonthlySalary, (YEAR(getdate()) - CAST(Batch.Session AS INT))*Employee.Salary AS TotalPaid, YEAR(getdate()) - CAST(Batch.Session AS INT) AS ServiceYears , Person.Name, Person.Contact FROM Employee JOIN EmployeeCourseSemester_MTM ON EmployeeCourseSemester_MTM.EmployeeID = Employee.PersonID JOIN CourseSemester_MTM ON  CourseSemester_MTM.ID = EmployeeCourseSemester_MTM.CourseSemesterID JOIN Semester ON Semester.ID = CourseSemester_MTM.SemesterID JOIN Batch ON Batch.ID = Semester.BatchID JOIN Person ON Person.ID = Employee.PersonID
WHERE Batch.Session = (SELECT MIN(Batch.Session) FROM EmployeeCourseSemester_MTM JOIN CourseSemester_MTM ON EmployeeCourseSemester_MTM.CourseSemesterID = CourseSemester_MTM.ID JOIN Semester ON Semester.ID = CourseSemester_MTM.SemesterID JOIN Batch ON Batch.ID = Semester.BatchID WHERE EmployeeCourseSemester_MTM.EmployeeID = Employee.PersonID)
GO

