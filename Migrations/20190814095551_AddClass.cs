using Microsoft.EntityFrameworkCore.Migrations;

namespace egrihakarya.Migrations
{
    public partial class AddClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp = @"USE [Classroom]
                        GO
                        /****** Object:  StoredProcedure [dbo].[AddClass]    Script Date: 8/14/2019 3:41:19 PM ******/
                        SET ANSI_NULLS ON
                        GO
                        SET QUOTED_IDENTIFIER ON
                        GO
                        -- =============================================
                        -- Author:		<Author,,Name>
                        -- Create date: <Create Date,,>
                        -- Description:	<Description,,>
                        -- EXEC [dbo].[AddClass] 'test', 'test', 'test', 'test', 1
                        -- =============================================
                        CREATE PROCEDURE [dbo].[AddClass](
                        	@ClassName NVARCHAR(100),
                        	@Section NVARCHAR(100),
                        	@Subject NVARCHAR(100),
                        	@Room NVARCHAR(100),
                        	@AddedBy INT
                        )
                        AS
                        BEGIN
                        	SET NOCOUNT ON;
                        	DECLARE @SubjectCode NVARCHAR(50);
                        	SELECT @SubjectCode = SUBSTRING(CONVERT(varchar(255), NEWID()), 0, 7)
                        	INSERT INTO [dbo].[Classes]
                                   ([ClassName]
                                   ,[Section]
                                   ,[Subject]
                                   ,[Room]
                                   ,[AddedOn]
                                   ,[AddedBy]
                                   ,[SubjectCode])
                             VALUES
                                   (@ClassName
                                   ,@Section
                                   ,@Subject
                                   ,@Room
                                   ,GETDATE()
                                   ,@AddedBy
                                   ,@SubjectCode)
                        	SELECT @SubjectCode;
                        END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
