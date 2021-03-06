/****** Object:  StoredProcedure [dbo].[GetAssignmentByClassID]    Script Date: 8/15/2019 3:23:40 PM ******/
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
