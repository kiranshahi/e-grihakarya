/****** Object:  Database [Classroom]    Script Date: 5/13/2019 9:04:19 AM ******/
CREATE DATABASE [Classroom]  ;
GO
ALTER DATABASE [Classroom] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Classroom] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Classroom] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Classroom] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Classroom] SET ARITHABORT OFF 
GO
ALTER DATABASE [Classroom] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Classroom] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Classroom] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Classroom] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Classroom] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Classroom] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Classroom] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Classroom] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Classroom] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Classroom] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Classroom] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Classroom] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Classroom] SET  MULTI_USER 
GO
ALTER DATABASE [Classroom] SET QUERY_STORE = OFF
GO
/****** Object:  User [IIS APPPOOL\charachurungi]    Script Date: 5/13/2019 9:04:19 AM ******/
CREATE USER [IIS APPPOOL\charachurungi] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/13/2019 9:04:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Assignments]    Script Date: 5/13/2019 9:04:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assignments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Instructions] [nvarchar](max) NULL,
	[Attachment] [nvarchar](max) NULL,
	[DueDate] [nvarchar](250) NOT NULL,
	[CASClassId] [int] NULL,
	[ClassID] [int] NOT NULL,
	[AddedOn] [nvarchar](50) NULL,
 CONSTRAINT [PK_Assignments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 5/13/2019 9:04:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [nvarchar](100) NOT NULL,
	[Section] [nvarchar](100) NULL,
	[Subject] [nvarchar](100) NULL,
	[Room] [nvarchar](100) NULL,
	[AddedOn] [datetime2](7) NOT NULL,
	[AddedBy] [int] NULL,
	[SubjectCode] [nvarchar](50) NULL,
 CONSTRAINT [PK_Classes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 5/13/2019 9:04:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[AssignmentID] [int] NULL,
	[Comment] [nvarchar](max) NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAssignments]    Script Date: 5/13/2019 9:04:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAssignments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[AssignmentID] [int] NOT NULL,
	[Assignment] [nvarchar](max) NULL,
	[IsSubmitted] [bit] NULL,
	[SubmittedOn] [nvarchar](50) NULL,
 CONSTRAINT [PK_UserAssignments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserClasses]    Script Date: 5/13/2019 9:04:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserClasses](
	[UserClassID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[ClassID] [int] NOT NULL,
 CONSTRAINT [PK_UserClasses] PRIMARY KEY CLUSTERED 
(
	[UserClassID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/13/2019 9:04:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](250) NULL,
	[LastName] [nvarchar](250) NULL,
	[Email] [nvarchar](250) NULL,
	[Username] [nvarchar](250) NULL,
	[Password] [nvarchar](250) NULL,
	[Role] [nvarchar](250) NULL,
	[Token] [nvarchar](250) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190318092649_CAS', N'2.2.3-servicing-35854')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190318100049_DatabaseUpdate', N'2.2.3-servicing-35854')
SET IDENTITY_INSERT [dbo].[Assignments] ON 

INSERT [dbo].[Assignments] ([ID], [Title], [Instructions], [Attachment], [DueDate], [CASClassId], [ClassID], [AddedOn]) VALUES (1, N'Assignment 1', N'Follow the following instruction.

"On the other hand, we denounce with righteous indignation and dislike men who are so beguiled and demoralized by the charms of pleasure of the moment, so blinded by desire, that they cannot foresee the pain and trouble that are bound to ensue; and equal blame belongs to those who fail in their duty through weakness of will, which is the same as saying through shrinking from toil and pain. These cases are perfectly simple and easy to distinguish. In a free hour, when our power of choice is untrammelled and when nothing prevents our being able to do what we like best, every pleasure is to be welcomed and every pain avoided. But in certain circumstances and owing to the claims of duty or the obligations of business it will frequently occur that pleasures have to be repudiated and annoyances accepted. The wise man therefore always holds in these matters to this principle of selection: he rejects pleasures to secure other greater pleasures, or else he endures pains to avoid worse pains."', N'wwwroot\uploads\files\Assignment-1.pdf', N'2019-05-06T18:14:06.000Z', NULL, 1, N'May  2 2019  7:52AM')
SET IDENTITY_INSERT [dbo].[Assignments] OFF
SET IDENTITY_INSERT [dbo].[Classes] ON 

INSERT [dbo].[Classes] ([Id], [ClassName], [Section], [Subject], [Room], [AddedOn], [AddedBy], [SubjectCode]) VALUES (1, N'Final Year Project', N'A', N'FYP', N'Sagarmatha', CAST(N'2019-05-02T06:50:02.9666667' AS DateTime2), 2, N'0x0000AA4100709F95')
SET IDENTITY_INSERT [dbo].[Classes] OFF
SET IDENTITY_INSERT [dbo].[UserAssignments] ON 

INSERT [dbo].[UserAssignments] ([ID], [UserID], [AssignmentID], [Assignment], [IsSubmitted], [SubmittedOn]) VALUES (1, 3, 1, NULL, 0, NULL)
INSERT [dbo].[UserAssignments] ([ID], [UserID], [AssignmentID], [Assignment], [IsSubmitted], [SubmittedOn]) VALUES (2, 4, 1, NULL, 0, NULL)
SET IDENTITY_INSERT [dbo].[UserAssignments] OFF
SET IDENTITY_INSERT [dbo].[UserClasses] ON 

INSERT [dbo].[UserClasses] ([UserClassID], [UserID], [ClassID]) VALUES (1, 3, 1)
INSERT [dbo].[UserClasses] ([UserClassID], [UserID], [ClassID]) VALUES (2, 3, 1)
INSERT [dbo].[UserClasses] ([UserClassID], [UserID], [ClassID]) VALUES (3, 4, 1)
SET IDENTITY_INSERT [dbo].[UserClasses] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Username], [Password], [Role], [Token]) VALUES (1, N'Admin', N'Admin', N'admin@email.com', NULL, N'admin', N'Admin', NULL)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Username], [Password], [Role], [Token]) VALUES (2, N'Teacher', N'Teacher', N'teacher@email.com', NULL, N'teacher', N'Teacher', NULL)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Username], [Password], [Role], [Token]) VALUES (3, N'Student', N'Student', N'student@email.com', NULL, N'student', N'Student', NULL)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Username], [Password], [Role], [Token]) VALUES (4, N'Parent', N'Parent', N'parent@email.com', NULL, N'parent', N'Parent', NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
/****** Object:  Index [IX_Assignments_CASClassId]    Script Date: 5/13/2019 9:04:22 AM ******/
CREATE NONCLUSTERED INDEX [IX_Assignments_CASClassId] ON [dbo].[Assignments]
(
	[CASClassId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Assignments] ADD  CONSTRAINT [DF__Assignmen__Class__534D60F1]  DEFAULT ((0)) FOR [ClassID]
GO
ALTER TABLE [dbo].[Assignments] ADD  CONSTRAINT [DF_Assignments_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
ALTER TABLE [dbo].[UserAssignments] ADD  CONSTRAINT [DF_UserAssignments_IsSubmitted]  DEFAULT ((0)) FOR [IsSubmitted]
GO
/****** Object:  StoredProcedure [dbo].[AddAssignment]    Script Date: 5/13/2019 9:04:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddAssignment]
	@AssinmentID INT,
	@title NVARCHAR(MAX),
	@instructions NVARCHAR(MAX),
	@attachment NVARCHAR(MAX),
	@duedate NVARCHAR(MAX),
	@classid INT
AS
BEGIN
	SET NOCOUNT ON;
	IF @AssinmentID = 0
		BEGIN
			DECLARE @Id INT; 
			INSERT INTO [dbo].[Assignments] 
				([Title], 
				[Instructions], 
				[Attachment], 
				[DueDate],  
				[ClassID]) 
			VALUES
			(
				 @title,
				 @instructions,
				 @attachment,
				 @duedate,
				 @classid
			)
			SET @Id = @@IDENTITY;
			INSERT INTO [dbo].[UserAssignments]
				([UserID]
				,[AssignmentID])
			SELECT UserID
				,@Id
				FROM UserClasses
				WHERE ClassID = @classid;
			SELECT 1;
		END
	ELSE
		BEGIN
			UPDATE
				[dbo].[Assignments] 
			SET
				[Title] = @title, 
				[Instructions] = @instructions, 
				[Attachment] = @attachment, 
				[DueDate] = @duedate, 
				[ClassID] = @classid
			WHERE ID = @AssinmentID;
			SELECT 2;
		END
END
GO
/****** Object:  StoredProcedure [dbo].[AddClass]    Script Date: 5/13/2019 9:04:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- EXEC [dbo].[AddClass] 'test', 'test', 'test', 'test', 1
-- =============================================
CREATE PROCEDURE [dbo].[AddClass](
	@ClassName NVARCHAR(100),
	@Section NVARCHAR(100),
	@Subject NVARCHAR(100),
	@Room NVARCHAR(100),
	@AddedBy INT
)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @SubjectCode NVARCHAR(50);
	SELECT @SubjectCode = CONVERT(nvarchar(50), CONVERT(varbinary(max),CAST(GETDATE() AS timestamp)),1)  
	INSERT INTO [dbo].[Classes]
           ([ClassName]
           ,[Section]
           ,[Subject]
           ,[Room]
           ,[AddedOn]
           ,[AddedBy]
           ,[SubjectCode])
     VALUES
           (@ClassName
           ,@Section
           ,@Subject
           ,@Room
           ,GETDATE()
           ,@AddedBy
           ,@SubjectCode)
	SELECT @SubjectCode;
END
GO
/****** Object:  StoredProcedure [dbo].[AddComment]    Script Date: 5/13/2019 9:04:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddComment] 
	@UserId INT,
	@AssignmentID INT,
	@Comment NVARCHAR(MAX)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Comment]
           ([UserID]
           ,[AssignmentID]
           ,[Comment])
     VALUES
           (@UserId
           ,@AssignmentID
           ,@Comment)
END
GO
/****** Object:  StoredProcedure [dbo].[AddUpdateUserAssignment]    Script Date: 5/13/2019 9:04:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddUpdateUserAssignment]
	@UserID INT,
	@AssignmentID INT,
	@Assignment NVARCHAR(MAX)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[UserAssignments]
	SET [Assignment] = @Assignment
		,[IsSubmitted] = 1
		,[SubmittedOn] = GETDATE()
	WHERE UserID = @UserID AND AssignmentID = @AssignmentID
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllClass]    Script Date: 5/13/2019 9:04:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- EXEC [dbo].[GetAllClass] 'Student', 3
-- =============================================
CREATE PROCEDURE [dbo].[GetAllClass] 
	@Role NVARCHAR(250),
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;
	IF @Role = 'Admin'
		BEGIN
			SELECT 
			C.[Id]
			,[ClassName]
			,[Section]
			,[Subject]
			,[Room]
			, CONCAT(U.FirstName, ' ', U.LastName) AS Teacher
			FROM Classes C
			INNER JOIN Users U
			ON U.Id = C.AddedBy  
			ORDER BY C.ID DESC;
		END
	ELSE IF @Role = 'Teacher'
		BEGIN
			SELECT 
			C.[Id]
			,[ClassName]
			,[Section]
			,[Subject]
			,[Room]
			, CONCAT(U.FirstName, ' ', U.LastName) AS Teacher
			FROM Classes C
			INNER JOIN Users U
			ON U.Id = C.AddedBy
			WHERE AddedBy = @Id ORDER BY ID DESC;
		END
	ELSE
		BEGIN
			SELECT
			DISTINCT 
			C.[Id]
			,[ClassName]
			,[Section]
			,[Subject]
			,[Room]
			, CONCAT(U.FirstName, ' ', U.LastName) AS Teacher
			FROM Classes C
			INNER JOIN UserClasses UC
			ON C.Id = UC.ClassID
			INNER JOIN Users U
			ON C.AddedBy = U.Id 
			WHERE UC.UserID = @Id
			ORDER BY ID DESC
		END
END
GO
/****** Object:  StoredProcedure [dbo].[GetAssignmentByClassID]    Script Date: 5/13/2019 9:04:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- EXEC GetAssignmentByClassID 28
-- =============================================
CREATE PROCEDURE [dbo].[GetAssignmentByClassID]
	@ClassId INT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [ID]
      ,[Title]
      ,[Instructions]
      ,[Attachment]
      ,[DueDate]
      ,[CASClassId]
      ,[ClassID]
	  ,[AddedOn]
  FROM [dbo].[Assignments]
  WHERE ClassID = @ClassId
END
GO
/****** Object:  StoredProcedure [dbo].[GetAssignmentByUserAndAssID]    Script Date: 5/13/2019 9:04:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAssignmentByUserAndAssID]
	@UserID INT,
	@AssignmentID INT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT UA.[ID]
		,[UserID]
		,[AssignmentID]
		,[Assignment]
		,[IsSubmitted]
		,[SubmittedOn]
		,CONCAT( U.FirstName, ' ' ,U.LastName) AS Name
	FROM [dbo].[UserAssignments] UA
	INNER JOIN Users U
	ON UA.UserID = U.Id
	WHERE AssignmentID = @AssignmentID AND UserID = @UserID
END
GO
/****** Object:  StoredProcedure [dbo].[GetClassByID]    Script Date: 5/13/2019 9:04:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetClassByID]
	@ClassID INT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [Id]
		,[ClassName]
		,[Section]
		,[Subject]
		,[Room]
		,[AddedOn]
		,[AddedBy]
		,[SubjectCode]
		FROM [dbo].[Classes]
		WHERE Id = @ClassID
END
GO
/****** Object:  StoredProcedure [dbo].[GetComment]    Script Date: 5/13/2019 9:04:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetComment] 
	@AssignmentID INT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT C.ID
		,CONCAT(U.FirstName, ' ', U.LastName) AS Name
		,[Comment]
	FROM [dbo].[Comment] C
	INNER JOIN Users U
	ON U.Id = C.UserID
	WHERE C.AssignmentID = @AssignmentID
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserAssignment]    Script Date: 5/13/2019 9:04:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- EXEC GetUserAssignment 1005
-- =============================================
CREATE PROCEDURE [dbo].[GetUserAssignment] 
	@AssignmentID INT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT UA.[ID]
		,[UserID]
		,[AssignmentID]
		,[Assignment]
		,[IsSubmitted]
		,[SubmittedOn]
		,CONCAT( U.FirstName, ' ' ,U.LastName) AS Name
	FROM [dbo].[UserAssignments] UA
	INNER JOIN Users U
	ON UA.UserID = U.Id
	WHERE AssignmentID = @AssignmentID AND U.Role='Student'
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserByEmailAndPassword]    Script Date: 5/13/2019 9:04:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetUserByEmailAndPassword](
	@Email NVARCHAR(MAX),
	@Password NVARCHAR(MAX)
)
AS
BEGIN
	SELECT * FROM Users WHERE Email = @Email AND Password = @Password
END
GO
/****** Object:  StoredProcedure [dbo].[JoinClass]    Script Date: 5/13/2019 9:04:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- EXEC JoinClass 3, '0x0000AA4100709F95'
-- =============================================
CREATE PROCEDURE [dbo].[JoinClass] 
	@UserID INT,
	@ClassID NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;
	IF NOT EXISTS (SELECT * FROM UserClasses WHERE UserID = @UserID AND ClassID = (SELECT Id FROM Classes WHERE SubjectCode = @ClassID))
	DECLARE @AssClass INT;
	BEGIN
		INSERT INTO [dbo].[UserClasses]
           ([UserID]
           ,[ClassID])
		VALUES
           (@UserID
           ,(SELECT Id FROM Classes WHERE SubjectCode = @ClassID))
		SELECT @AssClass = Id FROM Classes WHERE SubjectCode = @ClassID;
		INSERT INTO [dbo].[UserAssignments]
			([UserID]
			,[AssignmentID])
		SELECT @UserID, ID FROM  Assignments WHERE ClassID = @AssClass 
	END
END
GO
ALTER DATABASE [Classroom] SET  READ_WRITE 
GO
