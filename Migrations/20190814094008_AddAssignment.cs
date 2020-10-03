using Microsoft.EntityFrameworkCore.Migrations;

namespace egrihakarya.Migrations
{
    public partial class AddAssignment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"USE [Classroom]
                    GO
                    /****** Object:  StoredProcedure [dbo].[AddAssignment]    Script Date: 8/14/2019 3:26:28 PM ******/
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
                        END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
