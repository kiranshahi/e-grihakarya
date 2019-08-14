using Microsoft.EntityFrameworkCore.Migrations;

namespace egrihakarya.Migrations
{
    public partial class GetAllClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp = @"USE [Classroom]
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetAllClass]    Script Date: 8/14/2019 3:48:15 PM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO
                        -- =============================================
                        -- Author:		<Author,,Name>
                        -- Create date: <Create Date,,>
                        -- Description:	<Description,,>
                        -- EXEC [dbo].[GetAllClass] 'Student', 3
                        -- =============================================
                        CREATE PROCEDURE [dbo].[GetAllClass] 
                        	@Role NVARCHAR(250),
                        	@Id INT
                        AS
                        BEGIN
                        	SET NOCOUNT ON;
                        	IF @Role = 'Admin'
                        		BEGIN
                        			SELECT 
                        			C.[Id]
                        			,[ClassName]
                        			,[Section]
                        			,[Subject]
                        			,[Room]
                        			, CONCAT(U.FirstName, ' ', U.LastName) AS Teacher
                        			FROM Classes C
                        			INNER JOIN Users U
                        			ON U.Id = C.AddedBy  
                        			ORDER BY C.ID DESC;
                        		END
                        	ELSE IF @Role = 'Teacher'
                        		BEGIN
                        			SELECT 
                        			C.[Id]
                        			,[ClassName]
                        			,[Section]
                        			,[Subject]
                        			,[Room]
                        			, CONCAT(U.FirstName, ' ', U.LastName) AS Teacher
                        			FROM Classes C
                        			INNER JOIN Users U
                        			ON U.Id = C.AddedBy
                        			WHERE AddedBy = @Id ORDER BY ID DESC;
                        		END
                        	ELSE
                        		BEGIN
                        			SELECT
                        			DISTINCT 
                        			C.[Id]
                        			,[ClassName]
                        			,[Section]
                        			,[Subject]
                        			,[Room]
                        			, CONCAT(U.FirstName, ' ', U.LastName) AS Teacher
                        			FROM Classes C
                        			INNER JOIN UserClasses UC
                        			ON C.Id = UC.ClassID
                        			INNER JOIN Users U
                        			ON C.AddedBy = U.Id 
                        			WHERE UC.UserID = @Id
                        			ORDER BY ID DESC
                        		END
                        END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
