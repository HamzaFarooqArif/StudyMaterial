USE [master]
GO
/****** Object:  Database [IbmAdmissions2019]    Script Date: 6/12/2019 11:57:41 AM ******/
CREATE DATABASE [IbmAdmissions2019]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'IbmAdmissions2019', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\IbmAdmissions2019.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'IbmAdmissions2019_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\IbmAdmissions2019_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [IbmAdmissions2019] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [IbmAdmissions2019].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [IbmAdmissions2019] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [IbmAdmissions2019] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [IbmAdmissions2019] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [IbmAdmissions2019] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [IbmAdmissions2019] SET ARITHABORT OFF 
GO
ALTER DATABASE [IbmAdmissions2019] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [IbmAdmissions2019] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [IbmAdmissions2019] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [IbmAdmissions2019] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [IbmAdmissions2019] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [IbmAdmissions2019] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [IbmAdmissions2019] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [IbmAdmissions2019] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [IbmAdmissions2019] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [IbmAdmissions2019] SET  DISABLE_BROKER 
GO
ALTER DATABASE [IbmAdmissions2019] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [IbmAdmissions2019] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [IbmAdmissions2019] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [IbmAdmissions2019] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [IbmAdmissions2019] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [IbmAdmissions2019] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [IbmAdmissions2019] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [IbmAdmissions2019] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [IbmAdmissions2019] SET  MULTI_USER 
GO
ALTER DATABASE [IbmAdmissions2019] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [IbmAdmissions2019] SET DB_CHAINING OFF 
GO
ALTER DATABASE [IbmAdmissions2019] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [IbmAdmissions2019] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [IbmAdmissions2019] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [IbmAdmissions2019] SET QUERY_STORE = OFF
GO
USE [IbmAdmissions2019]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 6/12/2019 11:57:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 6/12/2019 11:57:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 6/12/2019 11:57:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 6/12/2019 11:57:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 6/12/2019 11:57:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 6/12/2019 11:57:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Block]    Script Date: 6/12/2019 11:57:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Block](
	[BlockId] [int] IDENTITY(1,1) NOT NULL,
	[BlockName] [nvarchar](50) NOT NULL,
	[TestId] [int] NOT NULL,
	[RollNumberStart] [int] NULL,
	[RollNumberEnd] [int] NULL,
	[Directions] [nvarchar](50) NULL,
	[Capacity] [int] NULL,
 CONSTRAINT [PK_Block] PRIMARY KEY CLUSTERED 
(
	[BlockId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 6/12/2019 11:57:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[PlaceLevel] [int] NOT NULL,
	[ParentId] [int] NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Degree]    Script Date: 6/12/2019 11:57:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Degree](
	[DegreeId] [int] IDENTITY(1,1) NOT NULL,
	[DegreeName] [nvarchar](50) NOT NULL,
	[TestId] [int] NOT NULL,
 CONSTRAINT [PK_Degree] PRIMARY KEY CLUSTERED 
(
	[DegreeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EducationDetails]    Script Date: 6/12/2019 11:57:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EducationDetails](
	[EducationId] [int] IDENTITY(1,1) NOT NULL,
	[EducationName] [nvarchar](50) NOT NULL,
	[IsPointsMarks] [bit] NOT NULL,
	[EducationLevel] [int] NOT NULL,
 CONSTRAINT [PK_EducationDetails] PRIMARY KEY CLUSTERED 
(
	[EducationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EntryTest]    Script Date: 6/12/2019 11:57:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EntryTest](
	[TestId] [int] NOT NULL,
	[TestName] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_EntryTest] PRIMARY KEY CLUSTERED 
(
	[TestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lookups]    Script Date: 6/12/2019 11:57:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lookups](
	[LookupId] [int] IDENTITY(1,1) NOT NULL,
	[LookupName] [nvarchar](50) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Lookups] PRIMARY KEY CLUSTERED 
(
	[LookupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Privilege]    Script Date: 6/12/2019 11:57:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Privilege](
	[PrivilegeId] [int] IDENTITY(1,1) NOT NULL,
	[PrivilegeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Privilege] PRIMARY KEY CLUSTERED 
(
	[PrivilegeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Program]    Script Date: 6/12/2019 11:57:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Program](
	[ProgramId] [int] IDENTITY(1,1) NOT NULL,
	[ProgramName] [nvarchar](50) NOT NULL,
	[DegreeId] [int] NOT NULL,
 CONSTRAINT [PK_Program] PRIMARY KEY CLUSTERED 
(
	[ProgramId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolePrivileges]    Script Date: 6/12/2019 11:57:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolePrivileges](
	[RoleId] [nvarchar](128) NOT NULL,
	[PrivilegeId] [int] NOT NULL,
 CONSTRAINT [PK_RolePrivileges] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[PrivilegeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 6/12/2019 11:57:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FatherName] [nvarchar](50) NOT NULL,
	[StudentCnic] [nvarchar](15) NOT NULL,
	[FaherCnic] [nvarchar](50) NULL,
	[PostalAddress] [nvarchar](max) NOT NULL,
	[PermanentAddress] [nvarchar](max) NOT NULL,
	[PhotographPath] [nvarchar](max) NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[Religion] [nvarchar](50) NOT NULL,
	[ProvinceId] [int] NULL,
	[DistrictId] [int] NULL,
	[CityId] [int] NULL,
	[HomePhoneNo] [nvarchar](50) NULL,
	[CellNo] [nvarchar](50) NOT NULL,
	[Gender] [int] NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[IsApplicationConfirmed] [bit] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentEducation]    Script Date: 6/12/2019 11:57:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentEducation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EducationId] [int] NOT NULL,
	[Total] [decimal](18, 0) NOT NULL,
	[Obtained] [decimal](18, 0) NOT NULL,
	[StudentId] [int] NOT NULL,
 CONSTRAINT [PK_StudentEducation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentPrograms]    Script Date: 6/12/2019 11:57:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentPrograms](
	[StudentId] [int] NOT NULL,
	[ProgramId] [int] NOT NULL,
	[DateOfApplication] [datetime] NOT NULL,
 CONSTRAINT [PK_StudentPrograms] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC,
	[ProgramId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentTest]    Script Date: 6/12/2019 11:57:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentTest](
	[StudentTestId] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[SlotId] [int] NULL,
	[RollNumber] [int] NULL,
	[TrackingNumber] [int] NOT NULL,
	[ChallanFormNumber] [int] NULL,
	[IsPaid] [bit] NULL,
	[Amount] [int] NULL,
	[TestUser] [nvarchar](50) NULL,
	[TestPassword] [nvarchar](50) NULL,
	[TestScore] [int] NULL,
	[PaymentVerifiedBy] [nvarchar](50) NULL,
	[PaymentVerifiedAt] [datetime] NULL,
	[RollNumberGeneratedAt] [datetime] NULL,
	[TestId] [int] NOT NULL,
 CONSTRAINT [PK_StudentTest] PRIMARY KEY CLUSTERED 
(
	[StudentTestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestCenter]    Script Date: 6/12/2019 11:57:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestCenter](
	[CenterId] [int] IDENTITY(1,1) NOT NULL,
	[CenterName] [nvarchar](50) NOT NULL,
	[BlockId] [int] NOT NULL,
	[Directions] [nvarchar](max) NOT NULL,
	[Capacity] [int] NOT NULL,
 CONSTRAINT [PK_TestCenter] PRIMARY KEY CLUSTERED 
(
	[CenterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestCenterSlot]    Script Date: 6/12/2019 11:57:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestCenterSlot](
	[SlotId] [int] IDENTITY(1,1) NOT NULL,
	[CenterId] [int] NOT NULL,
	[TestDateTime] [datetime] NOT NULL,
	[RollNumberStart] [int] NULL,
	[RollNumberEnd] [int] NULL,
 CONSTRAINT [PK_TestCenterSlot] PRIMARY KEY CLUSTERED 
(
	[SlotId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLoginHistory]    Script Date: 6/12/2019 11:57:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLoginHistory](
	[LoginId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[LoginTime] [datetime] NOT NULL,
	[Browser] [nvarchar](50) NULL,
	[IpAddress] [nvarchar](50) NULL,
	[MacAddress] [nvarchar](50) NULL,
 CONSTRAINT [PK_UserLoginHistory] PRIMARY KEY CLUSTERED 
(
	[LoginId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 6/12/2019 11:57:41 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 6/12/2019 11:57:41 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 6/12/2019 11:57:41 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleId]    Script Date: 6/12/2019 11:57:41 AM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 6/12/2019 11:57:41 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 6/12/2019 11:57:41 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF_Student_IsApplicationConfirmed]  DEFAULT ((0)) FOR [IsApplicationConfirmed]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Block]  WITH CHECK ADD  CONSTRAINT [FK_Block_EntryTest] FOREIGN KEY([TestId])
REFERENCES [dbo].[EntryTest] ([TestId])
GO
ALTER TABLE [dbo].[Block] CHECK CONSTRAINT [FK_Block_EntryTest]
GO
ALTER TABLE [dbo].[Program]  WITH CHECK ADD  CONSTRAINT [FK_Program_Degree] FOREIGN KEY([DegreeId])
REFERENCES [dbo].[Degree] ([DegreeId])
GO
ALTER TABLE [dbo].[Program] CHECK CONSTRAINT [FK_Program_Degree]
GO
ALTER TABLE [dbo].[RolePrivileges]  WITH CHECK ADD  CONSTRAINT [FK_RolePrivileges_AspNetRoles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
GO
ALTER TABLE [dbo].[RolePrivileges] CHECK CONSTRAINT [FK_RolePrivileges_AspNetRoles]
GO
ALTER TABLE [dbo].[RolePrivileges]  WITH CHECK ADD  CONSTRAINT [FK_RolePrivileges_Privilege] FOREIGN KEY([PrivilegeId])
REFERENCES [dbo].[Privilege] ([PrivilegeId])
GO
ALTER TABLE [dbo].[RolePrivileges] CHECK CONSTRAINT [FK_RolePrivileges_Privilege]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_AspNetUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_AspNetUsers]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Cities] FOREIGN KEY([ProvinceId])
REFERENCES [dbo].[Cities] ([Id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Cities]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Cities1] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[Cities] ([Id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Cities1]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Cities2] FOREIGN KEY([CityId])
REFERENCES [dbo].[Cities] ([Id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Cities2]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Lookups] FOREIGN KEY([Gender])
REFERENCES [dbo].[Lookups] ([LookupId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Lookups]
GO
ALTER TABLE [dbo].[StudentEducation]  WITH CHECK ADD  CONSTRAINT [FK_StudentEducation_EducationDetails] FOREIGN KEY([EducationId])
REFERENCES [dbo].[EducationDetails] ([EducationId])
GO
ALTER TABLE [dbo].[StudentEducation] CHECK CONSTRAINT [FK_StudentEducation_EducationDetails]
GO
ALTER TABLE [dbo].[StudentEducation]  WITH CHECK ADD  CONSTRAINT [FK_StudentEducation_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[StudentEducation] CHECK CONSTRAINT [FK_StudentEducation_Student]
GO
ALTER TABLE [dbo].[StudentPrograms]  WITH CHECK ADD  CONSTRAINT [FK_StudentPrograms_Program] FOREIGN KEY([ProgramId])
REFERENCES [dbo].[Program] ([ProgramId])
GO
ALTER TABLE [dbo].[StudentPrograms] CHECK CONSTRAINT [FK_StudentPrograms_Program]
GO
ALTER TABLE [dbo].[StudentPrograms]  WITH CHECK ADD  CONSTRAINT [FK_StudentPrograms_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[StudentPrograms] CHECK CONSTRAINT [FK_StudentPrograms_Student]
GO
ALTER TABLE [dbo].[StudentTest]  WITH CHECK ADD  CONSTRAINT [FK_StudentTest_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[StudentTest] CHECK CONSTRAINT [FK_StudentTest_Student]
GO
ALTER TABLE [dbo].[StudentTest]  WITH CHECK ADD  CONSTRAINT [FK_StudentTest_TestCenterSlot] FOREIGN KEY([SlotId])
REFERENCES [dbo].[TestCenterSlot] ([SlotId])
GO
ALTER TABLE [dbo].[StudentTest] CHECK CONSTRAINT [FK_StudentTest_TestCenterSlot]
GO
ALTER TABLE [dbo].[TestCenter]  WITH CHECK ADD  CONSTRAINT [FK_TestCenter_Block] FOREIGN KEY([BlockId])
REFERENCES [dbo].[Block] ([BlockId])
GO
ALTER TABLE [dbo].[TestCenter] CHECK CONSTRAINT [FK_TestCenter_Block]
GO
ALTER TABLE [dbo].[TestCenterSlot]  WITH CHECK ADD  CONSTRAINT [FK_TestCenterSlot_TestCenter] FOREIGN KEY([CenterId])
REFERENCES [dbo].[TestCenter] ([CenterId])
GO
ALTER TABLE [dbo].[TestCenterSlot] CHECK CONSTRAINT [FK_TestCenterSlot_TestCenter]
GO
ALTER TABLE [dbo].[UserLoginHistory]  WITH CHECK ADD  CONSTRAINT [FK_UserLoginHistory_AspNetUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[UserLoginHistory] CHECK CONSTRAINT [FK_UserLoginHistory_AspNetUsers]
GO
/****** Object:  StoredProcedure [dbo].[StudentDetails]    Script Date: 6/12/2019 11:57:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[StudentDetails](@StudentId int)
AS
Select Name,LookupName AS StudentGender,StudentCnic,TrackingNumber,ChallanFormNumber
FROM Student
JOIN Lookups
ON LookupId = Student.Gender
JOIN StudentTest
ON StudentTest.StudentId = Student.Id
JOIN EntryTest
ON EntryTest.TestId = StudentTest.TestId
Where EntryTest.IsActive = 'true'
and Student.Id = @StudentId 
GO
USE [master]
GO
ALTER DATABASE [IbmAdmissions2019] SET  READ_WRITE 
GO
