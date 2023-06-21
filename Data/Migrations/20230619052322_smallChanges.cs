using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeniorCapstoneProject.Migrations
{
    public partial class smallChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswers_QnAId",
                table: "StudentAnswers",
                column: "QnAId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswers_StudentId",
                table: "StudentAnswers",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAnswers_QnAs_QnAId",
                table: "StudentAnswers",
                column: "QnAId",
                principalTable: "QnAs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAnswers_Students_StudentId",
                table: "StudentAnswers",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAnswers_QnAs_QnAId",
                table: "StudentAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAnswers_Students_StudentId",
                table: "StudentAnswers");

            migrationBuilder.DropIndex(
                name: "IX_StudentAnswers_QnAId",
                table: "StudentAnswers");

            migrationBuilder.DropIndex(
                name: "IX_StudentAnswers_StudentId",
                table: "StudentAnswers");
        }
    }
}
