using Microsoft.EntityFrameworkCore.Migrations;

namespace CAS.Migrations
{
    public partial class DatabaseUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CASClassId",
                table: "Assignments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassID",
                table: "Assignments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_CASClassId",
                table: "Assignments",
                column: "CASClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Classes_CASClassId",
                table: "Assignments",
                column: "CASClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Classes_CASClassId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_CASClassId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "CASClassId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "ClassID",
                table: "Assignments");
        }
    }
}
