using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ModelRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "applications");

            migrationBuilder.AlterColumn<DateTime>(
                name: "creation_date",
                table: "grades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 28, 12, 4, 17, 511, DateTimeKind.Utc).AddTicks(8251),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 27, 21, 39, 49, 501, DateTimeKind.Utc).AddTicks(2882));

            migrationBuilder.AlterColumn<DateTime>(
                name: "creation_date",
                table: "applications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 28, 12, 4, 17, 512, DateTimeKind.Utc).AddTicks(5870),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 27, 21, 39, 49, 501, DateTimeKind.Utc).AddTicks(9896));

            migrationBuilder.AlterColumn<DateTime>(
                name: "creation_date",
                table: "application_statuses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 28, 12, 4, 17, 510, DateTimeKind.Utc).AddTicks(7305),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 27, 21, 39, 49, 500, DateTimeKind.Utc).AddTicks(3609));

            migrationBuilder.AlterColumn<DateTime>(
                name: "creation_date",
                table: "applicants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 28, 12, 4, 17, 490, DateTimeKind.Utc).AddTicks(3535),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 27, 21, 39, 49, 480, DateTimeKind.Utc).AddTicks(3649));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "creation_date",
                table: "grades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 27, 21, 39, 49, 501, DateTimeKind.Utc).AddTicks(2882),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 28, 12, 4, 17, 511, DateTimeKind.Utc).AddTicks(8251));

            migrationBuilder.AlterColumn<DateTime>(
                name: "creation_date",
                table: "applications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 27, 21, 39, 49, 501, DateTimeKind.Utc).AddTicks(9896),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 28, 12, 4, 17, 512, DateTimeKind.Utc).AddTicks(5870));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "applications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "creation_date",
                table: "application_statuses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 27, 21, 39, 49, 500, DateTimeKind.Utc).AddTicks(3609),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 28, 12, 4, 17, 510, DateTimeKind.Utc).AddTicks(7305));

            migrationBuilder.AlterColumn<DateTime>(
                name: "creation_date",
                table: "applicants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 27, 21, 39, 49, 480, DateTimeKind.Utc).AddTicks(3649),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 28, 12, 4, 17, 490, DateTimeKind.Utc).AddTicks(3535));
        }
    }
}
