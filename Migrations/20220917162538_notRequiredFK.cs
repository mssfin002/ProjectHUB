using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectHUB.Migrations
{
    public partial class notRequiredFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topics_AreasOfKnowledge_AreaOfKnowledgeId",
                table: "Topics");

            migrationBuilder.AlterColumn<Guid>(
                name: "AreaOfKnowledgeId",
                table: "Topics",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 17, 9, 25, 38, 732, DateTimeKind.Local).AddTicks(4634),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 16, 18, 28, 34, 584, DateTimeKind.Local).AddTicks(1896));

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_AreasOfKnowledge_AreaOfKnowledgeId",
                table: "Topics",
                column: "AreaOfKnowledgeId",
                principalTable: "AreasOfKnowledge",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topics_AreasOfKnowledge_AreaOfKnowledgeId",
                table: "Topics");

            migrationBuilder.AlterColumn<Guid>(
                name: "AreaOfKnowledgeId",
                table: "Topics",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 16, 18, 28, 34, 584, DateTimeKind.Local).AddTicks(1896),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 17, 9, 25, 38, 732, DateTimeKind.Local).AddTicks(4634));

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_AreasOfKnowledge_AreaOfKnowledgeId",
                table: "Topics",
                column: "AreaOfKnowledgeId",
                principalTable: "AreasOfKnowledge",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
