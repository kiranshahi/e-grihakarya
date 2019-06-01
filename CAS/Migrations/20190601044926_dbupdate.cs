using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CAS.Migrations
{
    public partial class dbupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Users");

            migrationBuilder.AddColumn<bool>(
                name: "IsSubmitted",
                table: "UserAssignments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UserAssignments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubmittedOn",
                table: "UserAssignments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddedBy",
                table: "Classes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SubjectCode",
                table: "Classes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Classes",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DueDate",
                table: "Assignments",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "AddedOn",
                table: "Assignments",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClassesView",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassName = table.Column<string>(nullable: true),
                    Section = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Room = table.Column<string>(nullable: true),
                    Teacher = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassesView", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_UserId",
                table: "Classes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Users_UserId",
                table: "Classes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Users_UserId",
                table: "Classes");

            migrationBuilder.DropTable(
                name: "ClassesView");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Classes_UserId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "IsSubmitted",
                table: "UserAssignments");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "UserAssignments");

            migrationBuilder.DropColumn(
                name: "SubmittedOn",
                table: "UserAssignments");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "SubjectCode",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "Assignments");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Users",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                table: "Assignments",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
