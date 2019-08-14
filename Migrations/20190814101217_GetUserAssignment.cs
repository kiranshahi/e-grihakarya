using Microsoft.EntityFrameworkCore.Migrations;

namespace egrihakarya.Migrations
{
    public partial class GetUserAssignment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp = @"USE [Classroom]
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetUserAssignment]    Script Date: 8/14/2019 3:57:38 PM ******/
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
                        END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
