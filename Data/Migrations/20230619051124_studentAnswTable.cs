using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeniorCapstoneProject.Migrations
{
    public partial class studentAnswTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    QnAId = table.Column<int>(type: "int", nullable: false),
                    StuAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAnswers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "QnAs",
                keyColumn: "Id",
                keyValue: 1,
                column: "MathEquation",
                value: "10+2");

            migrationBuilder.InsertData(
                table: "StudentAnswers",
                columns: new[] { "Id", "QnAId", "StuAnswer", "StudentId" },
                values: new object[] { 1, 1, "2", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentAnswers");

            migrationBuilder.UpdateData(
                table: "QnAs",
                keyColumn: "Id",
                keyValue: 1,
                column: "MathEquation",
                value: "$10+2");
        }
    }
}
