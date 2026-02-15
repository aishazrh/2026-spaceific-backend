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
                    b.RoomId,
                    RoomName = b.Room!.Name,
                    Building = b.Room.Building,
                    b.Purpose,
                    b.Start,
                    b.End,
                    b.Status,
                    b.CreatedAt,
                    b.UpdatedAt,
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
                    b.RoomId,
                    RoomName = b.Room!.Name,
                    Building = b.Room.Building,
                    b.Purpose,
                    b.Start,
                    b.End,
                    b.Status,
                    b.CreatedAt,
                    b.UpdatedAt,
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

        [Authorize]
        [HttpDelete("my/{id}")]
        public IActionResult DeleteMyBooking(int id)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
                return Unauthorized("Token tidak valid");

            int userId = int.Parse(userIdClaim);

            var booking = context.Bookings
                .FirstOrDefault(b => b.Id == id &&
                                     b.UserId == userId &&
                                     !b.IsDeleted);

            if (booking == null)
                return NotFound();

            booking.IsDeleted = true;
            booking.UpdatedAt = DateTime.UtcNow;

            context.SaveChanges();

            return NoContent();
        }


        // edit booking user
        [Authorize]
        [HttpPut("my/{id}")]
        public async Task<IActionResult> UpdateMyBooking(int id, [FromBody] UpdateBookingDto dto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
                return Unauthorized("Token invalid");

            int userId = int.Parse(userIdClaim);

            var booking = await context.Bookings
                .FirstOrDefaultAsync(b => b.Id == id && !b.IsDeleted);

            if (booking == null)
                return NotFound("Booking not found");

            if (booking.UserId != userId)
                return Forbid("Cannot edit other user's booking");

            if (booking.Status != "Pending")
                return BadRequest("Processed booking cannot be edited.");

            booking.RoomId = dto.RoomId;
            booking.Purpose = dto.Purpose!;
            booking.Start = dto.Start;
            booking.End = dto.End;
            booking.AllDay = dto.AllDay;
            booking.UpdatedAt = DateTime.UtcNow;

            await context.SaveChangesAsync();

            return Ok(new
            {
                booking.Id,
                booking.RoomId,
                booking.Purpose,
                booking.Start,
                booking.End,
                booking.Status
            });
        }

    }
}
