using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectHUB.Migrations
{
    public partial class RoleReAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92515019-5c95-40b0-8963-39ddb5fb4a3d");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 20, 17, 32, 369, DateTimeKind.Local).AddTicks(1605),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 13, 20, 15, 52, 806, DateTimeKind.Local).AddTicks(3812));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03fbab01-517e-4896-aadf-b17ac2e3bac2", "29f29332-f564-4a60-b69b-fddbc319a022", "Mentor", "MENTOR" },
                    { "3ac28e2d-628c-474b-9074-53f832d9ce6d", "39fa8b84-2eb8-47d9-9501-04149342df96", "Post-GradStudent", "POST-GRADSTUDENT" },
                    { "4dd21f85-bcff-4e99-aa72-aeed3cdac066", "82bdf013-a911-4738-b085-77b768b2581b", "Student", "STUDENT" },
                    { "5281c3e4-22d3-41b1-b42a-7f50d013f285", "bf163f0c-ba79-4a09-ae0d-e94aba6a408e", "Expert", "EXPERT" },
                    { "84677a2e-c25b-41f2-906d-bf6bf2fdbbe9", "b44b5b0b-f4d4-4a47-acba-a9095b57bbaf", "Admin", "ADMIN" },
                    { "f16fde30-8e5f-4bb9-bd61-80ea5fc078d4", "25e54743-bd06-455a-abcf-8d9c4678ffdc", "Unassigned", "UNASSIGNED" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03fbab01-517e-4896-aadf-b17ac2e3bac2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ac28e2d-628c-474b-9074-53f832d9ce6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4dd21f85-bcff-4e99-aa72-aeed3cdac066");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5281c3e4-22d3-41b1-b42a-7f50d013f285");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84677a2e-c25b-41f2-906d-bf6bf2fdbbe9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f16fde30-8e5f-4bb9-bd61-80ea5fc078d4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 20, 15, 52, 806, DateTimeKind.Local).AddTicks(3812),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 9, 13, 20, 17, 32, 369, DateTimeKind.Local).AddTicks(1605));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "92515019-5c95-40b0-8963-39ddb5fb4a3d", "18268b6c-5256-47f8-83e8-baff811fe481", "Expert", "EXPERT" });
        }
    }
}
