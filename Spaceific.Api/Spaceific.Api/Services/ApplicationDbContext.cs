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

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Room)
                .WithMany(r => r.Bookings)
                .HasForeignKey(b => b.RoomId);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Booking>().HasData(
                new Booking
                {
                    Id = 1,
                    UserId = 2,
                    RoomId = 2,
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
                    UserId = 2,
                    RoomId = 4,
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
                    UserId = 2,
                    RoomId = 3,
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
                    IsDeleted = false,
                    CreatedAt = new DateTime(2026, 2, 11, 22, 52, 0),
                    UpdatedAt = new DateTime(2026, 2, 11, 22, 52, 0)
                },
                new Room
                {
                    Id = 3,
                    Name = "SAW-0201",
                    Building = "SAW",
                    Capacity = 100,
                    IsDeleted = false,
                    CreatedAt = new DateTime(2026, 2, 11, 22, 52, 0),
                    UpdatedAt = new DateTime(2026, 2, 11, 22, 52, 0)
                },
                new Room
                {
                    Id = 4,
                    Name = "PS-0105",
                    Building = "Pascasarjana",
                    Capacity = 50,
                    IsDeleted = false,
                    CreatedAt = new DateTime(2026, 2, 11, 22, 52, 0),
                    UpdatedAt = new DateTime(2026, 2, 11, 22, 52, 0)
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Admin",
                    LastName = "Spaceific",
                    Username = "admin",
                    PasswordHash = "$2a$12$KeFN2k184BuqvUQgshTLROC4CPp6vLkTK.8Z/RBoOepPUAYU1/lTe",
                    Role = "Admin",
                    CreatedAt = new DateTime(2026, 2, 11, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 2, 11, 10, 0, 0)
                },
                new User
                {
                    Id = 2,
                    FirstName = "User",
                    LastName = "Demo",
                    Username = "user",
                    PasswordHash = "$2a$12$BKl1PPsOhkmvqCXfOQ57A.Bzgql0zcND2voJBsEUS.fyGZanjmej2",
                    Role = "User",
                    CreatedAt = new DateTime(2026, 2, 11, 10, 0, 0),
                    UpdatedAt = new DateTime(2026, 2, 11, 10, 0, 0)
                }
            );
        }
    }
}
