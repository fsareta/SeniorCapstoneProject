using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeniorCapstoneProject.Migrations
{
    public partial class changedtoIsUnlocked : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsLocked",
                table: "Levels",
                newName: "IsUnlocked");

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsUnlocked",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsUnlocked",
                table: "Levels",
                newName: "IsLocked");

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsLocked",
                value: false);
        }
    }
}
