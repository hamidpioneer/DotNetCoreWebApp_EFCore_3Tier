using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ApplicationStatusDefaultvalue1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "creation_date",
                table: "grades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 27, 21, 39, 49, 501, DateTimeKind.Utc).AddTicks(2882),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 27, 17, 49, 47, 851, DateTimeKind.Utc).AddTicks(4041));

            migrationBuilder.AlterColumn<DateTime>(
                name: "creation_date",
                table: "applications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 27, 21, 39, 49, 501, DateTimeKind.Utc).AddTicks(9896),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 27, 17, 49, 47, 851, DateTimeKind.Utc).AddTicks(9542));

            migrationBuilder.AlterColumn<int>(
                name: "application_status_id",
                table: "applications",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "creation_date",
                table: "application_statuses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 27, 21, 39, 49, 500, DateTimeKind.Utc).AddTicks(3609),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 27, 17, 49, 47, 850, DateTimeKind.Utc).AddTicks(2284));

            migrationBuilder.AlterColumn<DateTime>(
                name: "creation_date",
                table: "applicants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 27, 21, 39, 49, 480, DateTimeKind.Utc).AddTicks(3649),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 27, 17, 49, 47, 828, DateTimeKind.Utc).AddTicks(6560));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "creation_date",
                table: "grades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 27, 17, 49, 47, 851, DateTimeKind.Utc).AddTicks(4041),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 27, 21, 39, 49, 501, DateTimeKind.Utc).AddTicks(2882));

            migrationBuilder.AlterColumn<DateTime>(
                name: "creation_date",
                table: "applications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 27, 17, 49, 47, 851, DateTimeKind.Utc).AddTicks(9542),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 27, 21, 39, 49, 501, DateTimeKind.Utc).AddTicks(9896));

            migrationBuilder.AlterColumn<int>(
                name: "application_status_id",
                table: "applications",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "creation_date",
                table: "application_statuses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 27, 17, 49, 47, 850, DateTimeKind.Utc).AddTicks(2284),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 27, 21, 39, 49, 500, DateTimeKind.Utc).AddTicks(3609));

            migrationBuilder.AlterColumn<DateTime>(
                name: "creation_date",
                table: "applicants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 27, 17, 49, 47, 828, DateTimeKind.Utc).AddTicks(6560),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 27, 21, 39, 49, 480, DateTimeKind.Utc).AddTicks(3649));
        }
    }
}
