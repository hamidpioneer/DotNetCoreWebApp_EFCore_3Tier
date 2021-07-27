using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ElementarySchoolDbInitializedWith4Entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "applicants",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sur_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    contact_number = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    contact_email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    creation_date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 7, 27, 15, 57, 42, 112, DateTimeKind.Utc).AddTicks(4086)),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicants", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "application_statuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    creation_date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 7, 27, 15, 57, 42, 132, DateTimeKind.Utc).AddTicks(9715)),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_application_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "grades",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number = table.Column<int>(type: "int", nullable: false),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    creation_date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 7, 27, 15, 57, 42, 134, DateTimeKind.Utc).AddTicks(5036)),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grades", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "applications",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    applicant_id = table.Column<int>(type: "int", nullable: false),
                    application_status_id = table.Column<int>(type: "int", nullable: false),
                    grade_id = table.Column<int>(type: "int", nullable: false),
                    school_year = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creation_date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 7, 27, 15, 57, 42, 135, DateTimeKind.Utc).AddTicks(1019)),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applications", x => x.id);
                    table.ForeignKey(
                        name: "FK_applications_applicants_applicant_id",
                        column: x => x.applicant_id,
                        principalTable: "applicants",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_applications_application_statuses_application_status_id",
                        column: x => x.application_status_id,
                        principalTable: "application_statuses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_applications_grades_grade_id",
                        column: x => x.grade_id,
                        principalTable: "grades",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_application_statuses_name",
                table: "application_statuses",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_applications_applicant_id",
                table: "applications",
                column: "applicant_id");

            migrationBuilder.CreateIndex(
                name: "IX_applications_application_status_id",
                table: "applications",
                column: "application_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_applications_grade_id",
                table: "applications",
                column: "grade_id");

            migrationBuilder.CreateIndex(
                name: "IX_grades_name",
                table: "grades",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_grades_number",
                table: "grades",
                column: "number",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "applications");

            migrationBuilder.DropTable(
                name: "applicants");

            migrationBuilder.DropTable(
                name: "application_statuses");

            migrationBuilder.DropTable(
                name: "grades");
        }
    }
}
