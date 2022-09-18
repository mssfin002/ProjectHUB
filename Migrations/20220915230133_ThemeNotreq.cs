using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectHUB.Migrations
{
    public partial class ThemeNotreq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AreasOfKnowledge_Themes_ThemeId",
                table: "AreasOfKnowledge");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 15, 16, 1, 32, 913, DateTimeKind.Local).AddTicks(3409),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 15, 11, 3, 14, 990, DateTimeKind.Local).AddTicks(1217));

            migrationBuilder.AlterColumn<Guid>(
                name: "ThemeId",
                table: "AreasOfKnowledge",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_AreasOfKnowledge_Themes_ThemeId",
                table: "AreasOfKnowledge",
                column: "ThemeId",
                principalTable: "Themes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AreasOfKnowledge_Themes_ThemeId",
                table: "AreasOfKnowledge");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 15, 11, 3, 14, 990, DateTimeKind.Local).AddTicks(1217),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 15, 16, 1, 32, 913, DateTimeKind.Local).AddTicks(3409));

            migrationBuilder.AlterColumn<Guid>(
                name: "ThemeId",
                table: "AreasOfKnowledge",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AreasOfKnowledge_Themes_ThemeId",
                table: "AreasOfKnowledge",
                column: "ThemeId",
                principalTable: "Themes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
