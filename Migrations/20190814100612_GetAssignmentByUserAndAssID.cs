using Microsoft.EntityFrameworkCore.Migrations;

namespace egrihakarya.Migrations
{
    public partial class GetAssignmentByUserAndAssID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp = @"USE [Classroom]
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetAssignmentByUserAndAssID]    Script Date: 8/14/2019 3:51:26 PM ******/
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
                        END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
