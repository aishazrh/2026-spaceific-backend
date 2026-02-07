using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spaceific.Api.Models;
using Spaceific.Api.Services;

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
                    .Where(b => !b.IsDeleted)
                    .OrderByDescending(e => e.Id)
                    .ToList();
            
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var booking = context.Bookings
                    .FirstOrDefault(b => b.Id == id && !b.IsDeleted);
            
            if (booking == null)
            {
                return NotFound(new { message = "Booking tidak ditemukan." });
            }

            return Ok(booking);
        }

        [HttpPost]
        public IActionResult CreateBooking(BookingDTO bookingDTO)
        {
            var booking = new Booking
            {
                FirstName = bookingDTO.FirstName,
                LastName = bookingDTO.LastName,
                Room = bookingDTO.Room,
                Purpose = bookingDTO.Purpose,
                Start = bookingDTO.Start,
                End = bookingDTO.End,
                AllDay = bookingDTO.AllDay,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            context.Bookings.Add(booking);
            context.SaveChanges();

            return CreatedAtAction(nameof(GetBooking), new { id = booking.Id }, booking);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBooking(int id, BookingDTO bookingDTO)
        {
            var booking = context.Bookings.FirstOrDefault(b => b.Id == id && !b.IsDeleted);
            if (booking == null)
            {
                return NotFound(new { message = "Booking tidak ditemukan." });
            }

            booking.FirstName = bookingDTO.FirstName;
            booking.LastName = bookingDTO.LastName;
            booking.Room = bookingDTO.Room;
            booking.Purpose = bookingDTO.Purpose;
            booking.Start = bookingDTO.Start;
            booking.End = bookingDTO.End;
            booking.AllDay = bookingDTO.AllDay;
            booking.Status = bookingDTO.Status;
            booking.UpdatedAt = DateTime.UtcNow;

            context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id) 
        {
            var booking = context.Bookings.FirstOrDefault(b => b.Id == id && !b.IsDeleted);

            if (booking == null)
            {
                return NotFound(new { message = "Booking tidak ditemukan." });
            }

            booking.IsDeleted = true;
            booking.UpdatedAt = DateTime.UtcNow;
            
            context.SaveChanges();           
            return NoContent();
        }
    }
}
