using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spaceific.Api.Models;
using Spaceific.Api.Services;
using System.Security.Claims;

namespace Spaceific.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public BookingsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetBookings()
        {
            var bookings = context.Bookings
                .Include(b => b.User)
                .Include(b => b.Room)
                .Where(b => !b.IsDeleted)
                .OrderByDescending(b => b.Id)
                .Select(b => new
                {
                    b.Id,
                    RoomName = b.Room!.Name,
                    Building = b.Room.Building,
                    b.Purpose,
                    b.Start,
                    b.End,
                    b.Status,
                    FirstName = b.User!.FirstName,
                    LastName = b.User.LastName
                })
                .ToList();

            return Ok(bookings);
        }

        [Authorize]
        [HttpGet("my")]
        public IActionResult GetMyBookings()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
                return Unauthorized("Token tidak valid");

            int userId = int.Parse(userIdClaim);

            var myBookings = context.Bookings
                .Include(b => b.User)
                .Include(b => b.Room)
                .Where(b => b.UserId == userId && !b.IsDeleted)
                .OrderByDescending(b => b.Start)
                .Select(b => new
                {
                    b.Id,
                    RoomName = b.Room!.Name,
                    Building = b.Room.Building,
                    b.Purpose,
                    b.Start,
                    b.End,
                    b.Status,
                    FirstName = b.User!.FirstName,
                    LastName = b.User.LastName
                })
                .ToList();

            return Ok(myBookings);
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateBooking(BookingDTO dto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
                return Unauthorized("Token tidak valid");

            int userId = int.Parse(userIdClaim);

            var booking = new Booking
            {
                UserId = userId,
                RoomId = dto.RoomId,
                Purpose = dto.Purpose!,
                Start = dto.Start,
                End = dto.End,
                AllDay = dto.AllDay,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.Bookings.Add(booking);
            context.SaveChanges();

            return Ok(booking);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateBookingStatusDto dto)
        {
            var booking = await context.Bookings.FindAsync(id);
            if (booking == null)
                return NotFound();

            booking.Status = dto.Status;
            booking.UpdatedAt = DateTime.UtcNow;

            await context.SaveChangesAsync();
            return Ok(booking);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var booking = context.Bookings.FirstOrDefault(b => b.Id == id && !b.IsDeleted);
            if (booking == null)
                return NotFound();

            booking.IsDeleted = true;
            booking.UpdatedAt = DateTime.UtcNow;
            context.SaveChanges();

            return NoContent();
        }
    }
}
