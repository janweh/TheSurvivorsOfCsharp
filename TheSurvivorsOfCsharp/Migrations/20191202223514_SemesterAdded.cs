using Microsoft.EntityFrameworkCore.Migrations;

namespace TheSurvivorsOfCsharp.Migrations
{
    public partial class SemesterAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Lecturer_LecturerID",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_University_UniversityID",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_LecturerID",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "LecturerID",
                table: "Course");

            migrationBuilder.AlterColumn<int>(
                name: "UniversityID",
                table: "Course",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "CourseLecturer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoursID = table.Column<int>(nullable: false),
                    LecturerID = table.Column<int>(nullable: false),
                    CourseID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseLecturer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CourseLecturer_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseLecturer_Lecturer_LecturerID",
                        column: x => x.LecturerID,
                        principalTable: "Lecturer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseLecturer_CourseID",
                table: "CourseLecturer",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseLecturer_LecturerID",
                table: "CourseLecturer",
                column: "LecturerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_University_UniversityID",
                table: "Course",
                column: "UniversityID",
                principalTable: "University",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_University_UniversityID",
                table: "Course");

            migrationBuilder.DropTable(
                name: "CourseLecturer");

            migrationBuilder.AlterColumn<int>(
                name: "UniversityID",
                table: "Course",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LecturerID",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Course_LecturerID",
                table: "Course",
                column: "LecturerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Lecturer_LecturerID",
                table: "Course",
                column: "LecturerID",
                principalTable: "Lecturer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_University_UniversityID",
                table: "Course",
                column: "UniversityID",
                principalTable: "University",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
