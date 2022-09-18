using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectHUB.Migrations
{
    public partial class RolesSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 14, 48, 6, 555, DateTimeKind.Local).AddTicks(4126),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 13, 13, 53, 23, 575, DateTimeKind.Local).AddTicks(2613));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e29807a-78a6-4c73-ad1c-889da604f3f5", "7cce535c-6b9f-40dc-ba37-04e21a58ebef", "Admin", "ADMIN" },
                    { "104a5c8c-efec-4c87-ae4f-1362f1d6c40c", "3a9e6434-1209-46f7-a55d-da6765ef89df", "Unassigned", "UNASSIGNED" },
                    { "7cf7e34e-9506-4d5c-ad38-3b80ace7494c", "99321a57-aa21-4455-8cd2-b2b2933813a5", "Mentor", "MENTOR" },
                    { "c81cca67-36a7-492d-b303-db8e6bf81d49", "4034aaf8-79d0-47c0-a585-4a9677a228b7", "Student", "STUDENT" },
                    { "eff688e9-5559-4f43-9b11-fb4ea872fedd", "374c5f13-1665-4aa2-aa6b-3ada9fa1c7ce", "Post-GradStudent", "POST-GRADSTUDENT" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e29807a-78a6-4c73-ad1c-889da604f3f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "104a5c8c-efec-4c87-ae4f-1362f1d6c40c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cf7e34e-9506-4d5c-ad38-3b80ace7494c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c81cca67-36a7-492d-b303-db8e6bf81d49");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eff688e9-5559-4f43-9b11-fb4ea872fedd");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 13, 53, 23, 575, DateTimeKind.Local).AddTicks(2613),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 13, 14, 48, 6, 555, DateTimeKind.Local).AddTicks(4126));
        }
    }
}
