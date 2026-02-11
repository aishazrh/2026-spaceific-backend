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
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Booking>().HasData(
                new Booking
                {
                    Id = 1,
                    FirstName = "Andi",
                    LastName = "Pratama",
                    Room = "HH-203",
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
                    Room = "B-304",
                    Purpose = "Presentasi proyek PBL",
                    Start = new DateTime(2026, 2, 8, 13, 0, 0),
                    End = new DateTime(2026, 2, 8, 15, 0, 0),
                    AllDay = false,
                    Status = "Approved",
                    IsDeleted = false,
                    CreatedAt = new DateTime(2026, 2, 7),
                    UpdatedAt = new DateTime(2026, 2, 7)
                },
                new Booking
                {
                    Id = 3,
                    FirstName = "Rina",
                    LastName = "Kusuma",
                    Room = "SAW-0608",
                    Purpose = "Pelatihan editing video",
                    Start = new DateTime(2026, 2, 10, 10, 0, 0),
                    End = new DateTime(2026, 2, 10, 12, 0, 0),
                    AllDay = false,
                    Status = "Rejected",
                    IsDeleted = false,
                    CreatedAt = new DateTime(2026, 2, 7, 13, 47, 18),
                    UpdatedAt = new DateTime(2026, 2, 7, 13, 47, 18)
                }
            );

            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    Id = 1,
                    Name = "B-102",
                    Building = "D4",
                    Capacity = 30,
                    CreatedAt = new DateTime(2026, 2, 11, 22, 52, 0),
                    UpdatedAt = new DateTime(2026, 2, 11, 22, 52, 0)
                },
                new Room
                {
                    Id = 2,
                    Name = "HH-103",
                    Building = "D3",
                    Capacity = 30,
                    CreatedAt = new DateTime(2026, 2, 11, 22, 52, 0),
                    UpdatedAt = new DateTime(2026, 2, 11, 22, 52, 0)
                },
                new Room
                {
                    Id = 3,
                    Name = "SAW-0201",
                    Building = "SAW",
                    Capacity = 100,
                    CreatedAt = new DateTime(2026, 2, 11, 22, 52, 0),
                    UpdatedAt = new DateTime(2026, 2, 11, 22, 52, 0)
                },
                new Room
                {
                    Id = 4,
                    Name = "PS-0105",
                    Building = "Pascasarjana",
                    Capacity = 50,
                    CreatedAt = new DateTime(2026, 2, 11, 22, 52, 0),
                    UpdatedAt = new DateTime(2026, 2, 11, 22, 52, 0)
                }
            );
        }
    }
}
