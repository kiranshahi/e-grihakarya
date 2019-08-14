using Microsoft.EntityFrameworkCore.Migrations;

namespace egrihakarya.Migrations
{
    public partial class JoinClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp = @"USE [Classroom]
                        GO
                        /****** Object:  StoredProcedure [dbo].[JoinClass]    Script Date: 8/14/2019 4:00:18 PM ******/
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
                        END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
