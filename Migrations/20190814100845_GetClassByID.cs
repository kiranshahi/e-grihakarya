using Microsoft.EntityFrameworkCore.Migrations;

namespace egrihakarya.Migrations
{
    public partial class GetClassByID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp = @"USE [Classroom]
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetClassByID]    Script Date: 8/14/2019 3:54:16 PM ******/
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
                        END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
