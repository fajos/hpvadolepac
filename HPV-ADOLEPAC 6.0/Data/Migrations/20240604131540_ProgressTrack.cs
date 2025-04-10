using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HPV_ADOLEPAC_6._0.Data.Migrations
{
    public partial class ProgressTrack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "KnowledgeTestCompleted",
                table: "student",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LearningModulesCompleted",
                table: "student",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MyProfileCompleted",
                table: "student",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PostTestCompleted",
                table: "student",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PreTestCompleted",
                table: "student",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KnowledgeTestCompleted",
                table: "student");

            migrationBuilder.DropColumn(
                name: "LearningModulesCompleted",
                table: "student");

            migrationBuilder.DropColumn(
                name: "MyProfileCompleted",
                table: "student");

            migrationBuilder.DropColumn(
                name: "PostTestCompleted",
                table: "student");

            migrationBuilder.DropColumn(
                name: "PreTestCompleted",
                table: "student");
        }
    }
}
