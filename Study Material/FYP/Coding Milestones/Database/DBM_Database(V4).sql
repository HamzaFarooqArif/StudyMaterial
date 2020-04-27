CREATE TABLE Institute(
Id int NOT NULL IDENTITY(1, 1),
Name varchar(100) NOT NULL,
PRIMARY KEY (Id),
);

CREATE TABLE UserGroups(
Id int NOT NULL IDENTITY(1, 1),
Name varchar(100) NOT NULL,
InstituteId int NOT NULL,
PRIMARY KEY (Id),
FOREIGN KEY (InstituteId) REFERENCES Institute(Id) ON DELETE CASCADE
);

CREATE TABLE PermissionLookup(
Id int NOT NULL IDENTITY(1, 1),
Name int NOT NULL,
PRIMARY KEY (Id)
);


CREATE TABLE GroupsAssignedPermissions(
Id int NOT NULL IDENTITY(1, 1),
UserGroupId int NOT NULL,
PermissionId int NOT NULL,
PRIMARY KEY (Id),
FOREIGN KEY (UserGroupId) REFERENCES UserGroups(Id) ON DELETE CASCADE,
FOREIGN KEY (PermissionId) REFERENCES PermissionLookup(Id) ON DELETE CASCADE
);


CREATE TABLE Users(
Id int NOT NULL IDENTITY(1, 1),
FirstName varchar(max) NOT NULL,
LastName varchar(max) NOT NULL,
CNIC varchar(100) NOT NULL,
Email varchar(max) NOT NULL,
Password varchar(max) NOT NULL, 
Designation varchar(100) NOT NULL,
DateOfBirth DateTime NOT NULL,
LoginStatus int NOT NULL,
ActiveStatue int NOT NULL,
InstituteId int NOT NULL,
PRIMARY KEY (Id),
FOREIGN KEY (InstituteId) REFERENCES Institute(Id) ON DELETE CASCADE
);

CREATE TABLE UserAssignedGroups(
Id int NOT NULL IDENTITY(1, 1),
UserId int NOT NULL,
UserGroupId int NOT NULL,
PRIMARY KEY (Id),
FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE,
FOREIGN KEY (UserGroupId) REFERENCES UserGroups(Id)
);


CREATE TABLE Courses(
Id int NOT NULL IDENTITY(1, 1),
Name varchar(100) NOT NULL,
CourseCode varchar(100) NOT NULL,
ParentCourseid int NULL,
InstituteId int NOT NULL,
PRIMARY KEY (Id),
FOREIGN KEY (ParentCourseid) References Courses(Id),
FOREIGN KEY (InstituteId) REFERENCES Institute(Id) ON DELETE CASCADE
);

Create Table CourseInfo(
Id int NOT NULL IDENTITY(1, 1),
CreatedBy int NOT NULL,
CreatedOn DateTime NOT NULL,
UpdatedBy int NOT NULL,
UpdatedOn DateTime NOT NULL,
Courseid int NULL,
CourseYear int NOT NULL,
CourseSemester varchar(50) NOT NULL,
PRIMARY KEY (Id),
FOREIGN KEY (CreatedBy) REFERENCES Users(Id) ON DELETE CASCADE,
FOREIGN KEY (UpdatedBY) REFERENCES Users(Id),
FOREIGN KEY (Courseid) References Courses(Id)
);

CREATE TABLE TeachersAssignedCourses(
Id int NOT NULL IDENTITY(1, 1),
CourseId int NOT NULL,
UserId int NOT NULL,
PRIMARY KEY(Id),
FOREIGN KEY (CourseId) REFERENCES Courses(Id) ON DELETE CASCADE,
FOREIGN KEY (UserId) REFERENCES Users(Id),
);

CREATE TABLE Lectures(
Id int NOT NULL IDENTITY(1, 1),
Name varchar(max) not null,
CourseId int NOT NULL,
PRIMARY KEY (Id),
FOREIGN KEY (CourseId) REFERENCES Courses(Id) ON DELETE CASCADE
);

CREATE TABLE Video(
Id int NOT NULL IDENTITY(1, 1),
Titel VARCHAR(100) NOT NULL,
Lectureid int not null,
VideoFilePath varchar(max) NOT NULL,
CourseId int NOT NULL,
PRIMARY KEY (Id),
FOREIGN KEY (CourseId) REFERENCES Courses(Id) ON DELETE CASCADE,
FOREIGN KEY (Lectureid) REFERENCES Lectures(Id)
);



CREATE TABLE Announcement(
Id int NOT NULL IDENTITY(1, 1),
Title varchar(max) NOT NULL,
Description varchar(max) NOT NULL,
CreatedBy int NOT NULL,
CreatedOn DateTime NOT NULL,
UpdatedBy int NOT NULL,
UpdatedOn DateTime NOT NULL,
CourseId int NOT NULL,
PRIMARY KEY (Id),
FOREIGN KEY (CreatedBy) REFERENCES Users(Id) ON DELETE CASCADE,
FOREIGN KEY (UpdatedBy) REFERENCES Users(Id),
FOREIGN KEY (CourseId) REFERENCES Courses(Id)
);


CREATE TABLE CourseContent(
Id int NOT NULL IDENTITY(1, 1),
FilePath varchar(max) NOT NULL,
Name varchar(100) NOT NULL,
AddedOn DateTime NOT NULL,
UpdatedOn DateTime NOT NULL,
AddedBy int NOT NULL, 
UpdatedBy int NOT NULL,
CourseId int NOT NULL,
PRIMARY KEY (Id),
FOREIGN KEY (AddedBy) REFERENCES Users(Id) ON DELETE CASCADE,
FOREIGN KEY (UpdatedBy) REFERENCES Users(Id),
FOREIGN KEY (CourseId) REFERENCES Courses(Id),
);


CREATE TABLE Notes(
Id int NOT NULL IDENTITY(1, 1),
FilePath varchar(max) NOT NULL,
Title varchar(max) NOT NULL,
CreatedOn DateTime NOT NULL,
CreatedBy int NOT NULL,
UpdatedOn DateTime NOT NULL,
UpdatedBy int NOT NULL,
CourseId int NOT NULL,
Lectureid int,
PRIMARY KEY (Id),
FOREIGN KEY (CreatedBy) REFERENCES Users(Id) ON DELETE CASCADE,
FOREIGN KEY (UpdatedBy) REFERENCES Users(Id),
FOREIGN KEY (CourseId) REFERENCES Courses(Id),
FOREIGN KEY (Lectureid) REFERENCES Lectures(Id)
);

CREATE TABLE StudentGroupNumber(
Id int NOT NULL IDENTITY(1, 1),
PRIMARY KEY (Id),
);

CREATE TABLE StudentGroup(
Id int NOT NULL IDENTITY(1, 1),
Userid int,
Groupid int,
PRIMARY KEY (Id),
FOREIGN KEY (Userid) REFERENCES Users(Id) ON DELETE CASCADE,
FOREIGN KEY (Groupid) REFERENCES StudentGroupNumber(Id) ON DELETE CASCADE,
);

CREATE TABLE Assignments(
Id int NOT NULL IDENTITY(1, 1),
FilePath varchar(max) NOT NULL,
Title varchar(max) NOT NULL,
SubmissionDateTime DateTime NOT NULL,
PostSubmissionDateTime DATETIME NOT NULL,
StartDateTime DateTime NOT NULL,
Status varchar(100) NOT NULL,
CreatedOn DateTime NOT NULL,
CreatedBy int NOT NULL,
UpdatedOn DateTime NOT NULL,
UpdatedBy int NOT NULL,
CourseId int NOT NULL,
PRIMARY KEY (Id),
FOREIGN KEY (CreatedBy) REFERENCES Users(Id) ON DELETE CASCADE,
FOREIGN KEY (UpdatedBy) REFERENCES Users(Id),
FOREIGN KEY (CourseId) REFERENCES Courses(Id)
);


Create Table AssignmentQuestion(
Id int NOT NULL IDENTITY(1, 1),
Name varchar(100),
AssignmentId int,
PRIMARY KEY (Id),
FOREIGN KEY (AssignmentId) REFERENCES Assignments(Id) ON DELETE CASCADE,
);

CREATE TABLE AssignmentSubmission(
Id int NOT NULL IDENTITY(1, 1),
SubmissionDateTime DateTime NOT NULL,
StudentGroupid int NOT NULL,
AssignmentFilePath varchar(max) NOT NULL,
AssignmentId int NOT NULL,
PRIMARY KEY (Id),
FOREIGN KEY (AssignmentId) REFERENCES Assignments(Id) ON DELETE CASCADE,
FOREIGN KEY (StudentGroupid) REFERENCES StudentGroupNumber(Id) ON DELETE CASCADE
);


CREATE TABLE LoginHistory(
Id int NOT NULL IDENTITY(1, 1),
UserId int NOT NULL,
Status int NOT NULL,
StatusChangedAt DateTime NOT NULL,
PRIMARY KEY (Id)
);



CREATE TABLE UserCourseMTM(
Id int NOT NULL IDENTITY(1, 1),
Userid int NOT NULL,
Courseid int NOT NULL,
Role int Not NULL,
UserIdentity Varchar(100),
Approved BINARY(1),
PRIMARY KEY (Id),
FOREIGN KEY (Userid) REFERENCES Users(Id),
FOREIGN KEY (Courseid) REFERENCES Courses(Id) ON DELETE CASCADE,
);

CREATE TABLE Marks(
Id int NOT NULL IDENTITY(1, 1),
Groupid int NOT NULL,
AssignmentQuestionid int NOT NULL,
Marks float,
PRIMARY KEY (Id),
FOREIGN KEY (Groupid) REFERENCES StudentGroupNumber(Id) ON DELETE CASCADE,
FOREIGN KEY (AssignmentQuestionid) REFERENCES AssignmentQuestion(Id) ON DELETE CASCADE,
);
