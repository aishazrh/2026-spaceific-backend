using Microsoft.EntityFrameworkCore;
using Spaceific.Api.Models;

namespace Spaceific.Api.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public required DbSet<Booking> Bookings { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Booking>().HasData(
                new Booking
                {
                    Id = 1,
                    FirstName = "Andi",
                    LastName = "Pratama",
                    Room = "R.301",
                    Purpose = "Rapat divisi IT",
                    Start = new DateTime(2026, 2, 7, 9, 0, 0),
                    End = new DateTime(2026, 2, 7, 11, 0, 0),
                    AllDay = false,
                    Status = "Pending",
                    IsDeleted = false,
                    CreatedAt = new DateTime(2026, 2, 7),
                    UpdatedAt = new DateTime(2026, 2, 7)
                },
                new Booking
                {
                    Id = 2,
                    FirstName = "Siti",
                    LastName = "Aisyah",
                    Room = "R.205",
                    Purpose = "Presentasi proyek PBL",
                    Start = new DateTime(2026, 2, 8, 13, 0, 0),
                    End = new DateTime(2026, 2, 8, 15, 0, 0),
                    AllDay = false,
                    Status = "Approved",
                    IsDeleted = false,
                    CreatedAt = new DateTime(2026, 2, 7),
                    UpdatedAt = new DateTime(2026, 2, 7)
                }
            );
        }
    }
}
