using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectHUB.Migrations
{
    public partial class AOKupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "themeShortTitle",
                table: "AreasOfKnowledge",
                newName: "ThemeShortTitle");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 15, 11, 3, 14, 990, DateTimeKind.Local).AddTicks(1217),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 14, 16, 44, 54, 244, DateTimeKind.Local).AddTicks(8602));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ThemeShortTitle",
                table: "AreasOfKnowledge",
                newName: "themeShortTitle");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 16, 44, 54, 244, DateTimeKind.Local).AddTicks(8602),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 15, 11, 3, 14, 990, DateTimeKind.Local).AddTicks(1217));
        }
    }
}
