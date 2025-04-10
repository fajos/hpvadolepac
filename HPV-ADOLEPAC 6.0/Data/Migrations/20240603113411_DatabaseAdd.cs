using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HPV_ADOLEPAC_6._0.Data.Migrations
{
    public partial class DatabaseAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PostTestQuestions",
                columns: table => new
                {
                    PostTestQuestionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostTestQuestion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostTestQuestionOption1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostTestQuestionOption2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostTestQuestionOption3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostTestQuestionOption4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostTestQuestionOption5 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTestQuestions", x => x.PostTestQuestionID);
                });

            migrationBuilder.CreateTable(
                name: "PreTestQuestions",
                columns: table => new
                {
                    PreTestQuestionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreTestQuestion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreTestQuestionOption1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreTestQuestionOption2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreTestQuestionOption3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreTestQuestionOption4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreTestQuestionOption5 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreTestQuestions", x => x.PreTestQuestionID);
                });

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentParentPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentParentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentGender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentAge = table.Column<int>(type: "int", nullable: false),
                    School = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EthinicGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentalMaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherEdulevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherEdulevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherOccupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherOccupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonthlyIncome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnnualIncome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceOwnership = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrequencySub = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModulePercentage = table.Column<int>(type: "int", nullable: true),
                    AnswerBrief = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinalGrade = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.StudentID);
                });

            migrationBuilder.CreateTable(
                name: "TestQuestions",
                columns: table => new
                {
                    TestQuestionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestQuestion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestQuestionOption1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestQuestionOption2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestQuestionOption3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestQuestionOption4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrectOption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestQuestions", x => x.TestQuestionID);
                });

            migrationBuilder.CreateTable(
                name: "PostTestAnswer",
                columns: table => new
                {
                    PostTestAnswerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAttempt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostTestQuestionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTestAnswer", x => x.PostTestAnswerID);
                    table.ForeignKey(
                        name: "FK_PostTestAnswer_PostTestQuestions_PostTestQuestionID",
                        column: x => x.PostTestQuestionID,
                        principalTable: "PostTestQuestions",
                        principalColumn: "PostTestQuestionID");
                });

            migrationBuilder.CreateTable(
                name: "PreTestAnswer",
                columns: table => new
                {
                    PreTestAnswerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAttempt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreTestQuestionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreTestAnswer", x => x.PreTestAnswerID);
                    table.ForeignKey(
                        name: "FK_PreTestAnswer_PreTestQuestions_PreTestQuestionID",
                        column: x => x.PreTestQuestionID,
                        principalTable: "PreTestQuestions",
                        principalColumn: "PreTestQuestionID");
                });

            migrationBuilder.CreateTable(
                name: "TestAnswers",
                columns: table => new
                {
                    TestAnswerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestQuestionID = table.Column<int>(type: "int", nullable: true),
                    AnswerStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAttempt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinalGradeStudentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestAnswers", x => x.TestAnswerID);
                    table.ForeignKey(
                        name: "FK_TestAnswers_student_FinalGradeStudentID",
                        column: x => x.FinalGradeStudentID,
                        principalTable: "student",
                        principalColumn: "StudentID");
                    table.ForeignKey(
                        name: "FK_TestAnswers_TestQuestions_TestQuestionID",
                        column: x => x.TestQuestionID,
                        principalTable: "TestQuestions",
                        principalColumn: "TestQuestionID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostTestAnswer_PostTestQuestionID",
                table: "PostTestAnswer",
                column: "PostTestQuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_PreTestAnswer_PreTestQuestionID",
                table: "PreTestAnswer",
                column: "PreTestQuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_TestAnswers_FinalGradeStudentID",
                table: "TestAnswers",
                column: "FinalGradeStudentID");

            migrationBuilder.CreateIndex(
                name: "IX_TestAnswers_TestQuestionID",
                table: "TestAnswers",
                column: "TestQuestionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostTestAnswer");

            migrationBuilder.DropTable(
                name: "PreTestAnswer");

            migrationBuilder.DropTable(
                name: "TestAnswers");

            migrationBuilder.DropTable(
                name: "PostTestQuestions");

            migrationBuilder.DropTable(
                name: "PreTestQuestions");

            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "TestQuestions");
        }
    }
}
