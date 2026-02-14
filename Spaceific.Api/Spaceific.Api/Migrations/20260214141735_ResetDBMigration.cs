using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Spaceific.Api.Migrations
{
    /// <inheritdoc />
    public partial class ResetDBMigration : Migration
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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AllDay = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "FirstName", "LastName", "PasswordHash", "Role", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 2, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), "Admin", "Spaceific", "$2a$12$KeFN2k184BuqvUQgshTLROC4CPp6vLkTK.8Z/RBoOepPUAYU1/lTe", "Admin", new DateTime(2026, 2, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), "admin" },
                    { 2, new DateTime(2026, 2, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), "User", "Demo", "$2a$12$BKl1PPsOhkmvqCXfOQ57A.Bzgql0zcND2voJBsEUS.fyGZanjmej2", "User", new DateTime(2026, 2, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), "user" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "AllDay", "CreatedAt", "End", "IsDeleted", "Purpose", "RoomId", "Start", "Status", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 7, 11, 0, 0, 0, DateTimeKind.Unspecified), false, "Rapat divisi IT", 2, new DateTime(2026, 2, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), "Pending", new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, false, new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 8, 15, 0, 0, 0, DateTimeKind.Unspecified), false, "Presentasi proyek PBL", 4, new DateTime(2026, 2, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), "Approved", new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, false, new DateTime(2026, 2, 7, 13, 47, 18, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), false, "Pelatihan editing video", 3, new DateTime(2026, 2, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), "Rejected", new DateTime(2026, 2, 7, 13, 47, 18, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
