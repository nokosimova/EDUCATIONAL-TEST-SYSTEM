using Microsoft.EntityFrameworkCore.Migrations;

namespace TestSystem.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherLogin",
                table: "Teachers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeacherPassword",
                table: "Teachers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentLogin",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentPassword",
                table: "Students",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeacherLogin",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "TeacherPassword",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "StudentLogin",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentPassword",
                table: "Students");
        }
    }
}
