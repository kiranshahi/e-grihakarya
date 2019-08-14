using Microsoft.EntityFrameworkCore.Migrations;

namespace egrihakarya.Migrations
{
    public partial class GetUserByEmailAndPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp = @"USE [Classroom]
                        GO
                        /****** Object:  StoredProcedure [dbo].[GetUserByEmailAndPassword]    Script Date: 8/14/2019 3:58:58 PM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO
                        CREATE PROC [dbo].[GetUserByEmailAndPassword](
                        	@Email NVARCHAR(MAX),
                        	@Password NVARCHAR(MAX)
                        )
                        AS
                        BEGIN
                        	SELECT * FROM Users WHERE Email = @Email AND Password = @Password
                        END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
