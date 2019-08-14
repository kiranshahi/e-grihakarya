using Microsoft.EntityFrameworkCore.Migrations;

namespace egrihakarya.Migrations
{
    public partial class GetComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp = @"USE [Classroom]
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetComment]    Script Date: 8/14/2019 3:56:08 PM ******/
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
                        END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
