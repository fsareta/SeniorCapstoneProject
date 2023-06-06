using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeniorCapstoneProject.Data.Migrations
{
    public partial class seedStudentandGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Level", "Score" },
                values: new object[] { 1, 1, 0 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Enrolled", "FirstName", "GameId", "LastName", "Photo", "TeacherId" },
                values: new object[] { 1, true, "Emily", 1, "Falls", null, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
