using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectHUB.Migrations
{
    public partial class AOKshortTitleAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "aokShortTitle",
                table: "Topics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 16, 18, 28, 34, 584, DateTimeKind.Local).AddTicks(1896),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 15, 16, 1, 32, 913, DateTimeKind.Local).AddTicks(3409));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "aokShortTitle",
                table: "Topics");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 15, 16, 1, 32, 913, DateTimeKind.Local).AddTicks(3409),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 16, 18, 28, 34, 584, DateTimeKind.Local).AddTicks(1896));
        }
    }
}
