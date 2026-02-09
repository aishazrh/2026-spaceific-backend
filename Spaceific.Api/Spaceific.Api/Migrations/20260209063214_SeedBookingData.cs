using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Spaceific.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedBookingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "AllDay", "CreatedAt", "End", "FirstName", "IsDeleted", "LastName", "Purpose", "Room", "Start", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 7, 11, 0, 0, 0, DateTimeKind.Unspecified), "Andi", false, "Pratama", "Rapat divisi IT", "R.301", new DateTime(2026, 2, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), "Pending", new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, false, new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 8, 15, 0, 0, 0, DateTimeKind.Unspecified), "Siti", false, "Aisyah", "Presentasi proyek PBL", "R.205", new DateTime(2026, 2, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), "Approved", new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
