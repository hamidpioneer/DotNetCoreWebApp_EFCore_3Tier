using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class initAppDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "applicants",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    sur_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    contact_number = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    contact_email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    creation_date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 8, 3, 20, 38, 16, 369, DateTimeKind.Utc).AddTicks(1974)),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(10, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified))
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
                    creation_date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 8, 3, 20, 38, 16, 389, DateTimeKind.Utc).AddTicks(3499)),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(10, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified))
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
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    number = table.Column<int>(type: "int", nullable: false),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    creation_date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 8, 3, 20, 38, 16, 390, DateTimeKind.Utc).AddTicks(2183)),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(10, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grades", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tblSamples",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSamples", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "applications",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    school_year = table.Column<int>(type: "int", nullable: false),
                    applicant_id = table.Column<int>(type: "int", nullable: false),
                    application_status_id = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    grade_id = table.Column<int>(type: "int", nullable: false),
                    creation_date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 8, 3, 20, 38, 16, 390, DateTimeKind.Utc).AddTicks(8838)),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(10, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified))
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
                name: "tblSamples");

            migrationBuilder.DropTable(
                name: "applicants");

            migrationBuilder.DropTable(
                name: "application_statuses");

            migrationBuilder.DropTable(
                name: "grades");
        }
    }
}
