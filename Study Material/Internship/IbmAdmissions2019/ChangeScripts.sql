/*
   Saturday, June 15, 20194:30:32 PM
   User: sa
   Server: SAMYAN-PC\SQLEXPRESS
   Database: IbmAdmissions2019
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.StudentEducation ADD
	PointsType int NULL,
	IsDegreeCompleted bit NOT NULL CONSTRAINT DF_StudentEducation_IsDegreeCompleted DEFAULT 1
GO
ALTER TABLE dbo.StudentEducation SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


INSERT INTO Lookups(LookupName,CategoryName)
Values('Marks','PointsType')
INSERT INTO Lookups(LookupName,CategoryName)
Values('CGPA','PointsType')




Update Program Set ProgramName='MBA 2 Years(60 Credit Hours)'
  Where ProgramName = 'MBA'

  INSERT INTO Program(ProgramName,DegreeId)
  Values('MBA 1.5 Years(60 Credit Hours)',2)

    INSERT INTO Program(ProgramName,DegreeId)
  Values('MBA- Specialization in Finance(1.5 years)',2)

     INSERT INTO Program(ProgramName,DegreeId)
  Values('Executive MBA(2 years)',2)

       INSERT INTO Program(ProgramName,DegreeId)
  Values('MS Management (1.5 years)',2)

     INSERT INTO Program(ProgramName,DegreeId)
  Values('MS Marketing (1.5 years)',2)
  
  
  
  /* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.StudentEducation
	DROP CONSTRAINT FK_StudentEducation_EducationDetails
GO
ALTER TABLE dbo.EducationDetails SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.StudentEducation
	DROP CONSTRAINT FK_StudentEducation_Student
GO
ALTER TABLE dbo.Student SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.StudentEducation
	DROP CONSTRAINT DF_StudentEducation_IsDegreeCompleted
GO
CREATE TABLE dbo.Tmp_StudentEducation
	(
	Id int NOT NULL IDENTITY (1, 1),
	EducationId int NOT NULL,
	Total decimal(18, 2) NOT NULL,
	Obtained decimal(18, 2) NOT NULL,
	StudentId int NOT NULL,
	PointsType int NULL,
	IsDegreeCompleted bit NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_StudentEducation SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_StudentEducation ADD CONSTRAINT
	DF_StudentEducation_IsDegreeCompleted DEFAULT ((1)) FOR IsDegreeCompleted
GO
SET IDENTITY_INSERT dbo.Tmp_StudentEducation ON
GO
IF EXISTS(SELECT * FROM dbo.StudentEducation)
	 EXEC('INSERT INTO dbo.Tmp_StudentEducation (Id, EducationId, Total, Obtained, StudentId, PointsType, IsDegreeCompleted)
		SELECT Id, EducationId, Total, Obtained, StudentId, PointsType, IsDegreeCompleted FROM dbo.StudentEducation WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_StudentEducation OFF
GO
DROP TABLE dbo.StudentEducation
GO
EXECUTE sp_rename N'dbo.Tmp_StudentEducation', N'StudentEducation', 'OBJECT' 
GO
ALTER TABLE dbo.StudentEducation ADD CONSTRAINT
	PK_StudentEducation PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.StudentEducation ADD CONSTRAINT
	FK_StudentEducation_Student FOREIGN KEY
	(
	StudentId
	) REFERENCES dbo.Student
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.StudentEducation ADD CONSTRAINT
	FK_StudentEducation_EducationDetails FOREIGN KEY
	(
	EducationId
	) REFERENCES dbo.EducationDetails
	(
	EducationId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT



/* June 18, 2019*/
/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Lookups ADD
	SortOrder int NULL
GO
ALTER TABLE dbo.Lookups SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Lookups', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Lookups', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Lookups', 'Object', 'CONTROL') as Contr_Per 




/* June 19,2019 
 To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Lookups ADD
	Description nvarchar(100) NULL,
	IsActive bit NOT NULL CONSTRAINT DF_Lookups_IsActive DEFAULT 1
GO
ALTER TABLE dbo.Lookups SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
