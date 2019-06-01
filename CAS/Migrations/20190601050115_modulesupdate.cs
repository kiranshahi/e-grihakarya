using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CAS.Migrations
{
    public partial class modulesupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassesView");

            migrationBuilder.DropTable(
                name: "UserAssignments");

            migrationBuilder.DropTable(
                name: "UserClasses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassesView",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassName = table.Column<string>(nullable: true),
                    Room = table.Column<string>(nullable: true),
                    Section = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Teacher = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassesView", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAssignments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Assignment = table.Column<string>(nullable: true),
                    AssignmentID = table.Column<int>(nullable: false),
                    IsSubmitted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SubmittedOn = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAssignments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserClasses",
                columns: table => new
                {
                    UserClassID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClasses", x => x.UserClassID);
                });
        }
    }
}
