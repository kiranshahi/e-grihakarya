using Microsoft.EntityFrameworkCore.Migrations;

namespace egrihakarya.Migrations
{
    public partial class AddUpdateUserAssignment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp = @"USE [Classroom]
                        GO
                        /****** Object:  StoredProcedure [dbo].[AddUpdateUserAssignment]    Script Date: 8/14/2019 3:47:04 PM ******/
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
                        END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
