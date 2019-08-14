using Microsoft.EntityFrameworkCore.Migrations;

namespace egrihakarya.Migrations
{
    public partial class GetAssignmentByClassID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp = @"USE [Classroom]
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetAssignmentByClassID]    Script Date: 8/14/2019 3:50:08 PM ******/
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
                        END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
