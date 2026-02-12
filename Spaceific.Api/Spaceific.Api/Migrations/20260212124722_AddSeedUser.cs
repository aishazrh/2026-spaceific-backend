using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Spaceific.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "FirstName", "LastName", "PasswordHash", "Role", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 2, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), "Admin", "Spaceific", "$2a$12$KeFN2k184BuqvUQgshTLROC4CPp6vLkTK.8Z/RBoOepPUAYU1/lTe", "Admin", new DateTime(2026, 2, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), "admin" },
                    { 2, new DateTime(2026, 2, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), "User", "Demo", "$2a$12$BKl1PPsOhkmvqCXfOQ57A.Bzgql0zcND2voJBsEUS.fyGZanjmej2", "User", new DateTime(2026, 2, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
