using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class DateTimUtcNow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "creation_date",
                table: "grades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 27, 17, 49, 47, 851, DateTimeKind.Utc).AddTicks(4041),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 27, 15, 57, 42, 134, DateTimeKind.Utc).AddTicks(5036));

            migrationBuilder.AlterColumn<DateTime>(
                name: "creation_date",
                table: "applications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 27, 17, 49, 47, 851, DateTimeKind.Utc).AddTicks(9542),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 27, 15, 57, 42, 135, DateTimeKind.Utc).AddTicks(1019));

            migrationBuilder.AlterColumn<DateTime>(
                name: "creation_date",
                table: "application_statuses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 27, 17, 49, 47, 850, DateTimeKind.Utc).AddTicks(2284),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 27, 15, 57, 42, 132, DateTimeKind.Utc).AddTicks(9715));

            migrationBuilder.AlterColumn<DateTime>(
                name: "creation_date",
                table: "applicants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 27, 17, 49, 47, 828, DateTimeKind.Utc).AddTicks(6560),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 27, 15, 57, 42, 112, DateTimeKind.Utc).AddTicks(4086));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "creation_date",
                table: "grades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 27, 15, 57, 42, 134, DateTimeKind.Utc).AddTicks(5036),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 27, 17, 49, 47, 851, DateTimeKind.Utc).AddTicks(4041));

            migrationBuilder.AlterColumn<DateTime>(
                name: "creation_date",
                table: "applications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 27, 15, 57, 42, 135, DateTimeKind.Utc).AddTicks(1019),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 27, 17, 49, 47, 851, DateTimeKind.Utc).AddTicks(9542));

            migrationBuilder.AlterColumn<DateTime>(
                name: "creation_date",
                table: "application_statuses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 27, 15, 57, 42, 132, DateTimeKind.Utc).AddTicks(9715),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 27, 17, 49, 47, 850, DateTimeKind.Utc).AddTicks(2284));

            migrationBuilder.AlterColumn<DateTime>(
                name: "creation_date",
                table: "applicants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 7, 27, 15, 57, 42, 112, DateTimeKind.Utc).AddTicks(4086),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 7, 27, 17, 49, 47, 828, DateTimeKind.Utc).AddTicks(6560));
        }
    }
}
