using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spaceific.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreSeedBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "AllDay", "CreatedAt", "End", "FirstName", "IsDeleted", "LastName", "Purpose", "Room", "Start", "Status", "UpdatedAt" },
                values: new object[] { 3, false, new DateTime(2026, 2, 7, 13, 47, 18, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), "Rina", false, "Kusuma", "Pelatihan editing video", "Lab Multimedia", new DateTime(2026, 2, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), "Rejected", new DateTime(2026, 2, 7, 13, 47, 18, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
