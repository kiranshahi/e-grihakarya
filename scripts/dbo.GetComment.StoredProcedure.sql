/****** Object:  StoredProcedure [dbo].[GetComment]    Script Date: 8/15/2019 3:23:40 PM ******/
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
