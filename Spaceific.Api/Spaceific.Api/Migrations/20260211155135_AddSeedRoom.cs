using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Spaceific.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Building = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Building", "Capacity", "CreatedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "D4", 30, new DateTime(2026, 2, 11, 22, 52, 0, 0, DateTimeKind.Unspecified), false, "B-102", new DateTime(2026, 2, 11, 22, 52, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "D3", 30, new DateTime(2026, 2, 11, 22, 52, 0, 0, DateTimeKind.Unspecified), false, "HH-103", new DateTime(2026, 2, 11, 22, 52, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "SAW", 100, new DateTime(2026, 2, 11, 22, 52, 0, 0, DateTimeKind.Unspecified), false, "SAW-0201", new DateTime(2026, 2, 11, 22, 52, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Pascasarjana", 50, new DateTime(2026, 2, 11, 22, 52, 0, 0, DateTimeKind.Unspecified), false, "PS-0105", new DateTime(2026, 2, 11, 22, 52, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
