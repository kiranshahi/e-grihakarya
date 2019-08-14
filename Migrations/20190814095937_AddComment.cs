using Microsoft.EntityFrameworkCore.Migrations;

namespace egrihakarya.Migrations
{
    public partial class AddComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp = @"USE [Classroom]
                        GO
                        /****** Object:  StoredProcedure [dbo].[AddComment]    Script Date: 8/14/2019 3:44:57 PM ******/
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
                        END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
