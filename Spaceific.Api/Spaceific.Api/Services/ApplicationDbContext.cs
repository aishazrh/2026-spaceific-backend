using Microsoft.EntityFrameworkCore;
using Spaceific.Api.Models;

namespace Spaceific.Api.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public required DbSet<Booking> Bookings { get; set; }

        protected ApplicationDbContext()
        {
        }
    }
}
