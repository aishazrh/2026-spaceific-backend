using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spaceific.Api.Models;
using Spaceific.Api.Services;

namespace Spaceific.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public RoomsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetRooms()
        {
            var rooms = context.Rooms
                .Where(r => !r.IsDeleted)
                .OrderByDescending(r => r.Id)
                .ToList();

            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public IActionResult GetRoom(int id)
        {
            var room = context.Rooms.FirstOrDefault(r => r.Id == id && !r.IsDeleted);
            if (room == null)
                return NotFound();

            return Ok(room);
        }

        [HttpPost]
        public IActionResult CreateRoom([FromBody] RoomDTO dto)
        {
            Console.WriteLine("BUILDING = " + dto.Building);

            var room = new Room
            {
                Name = dto.Name,
                Building = dto.Building,
                Capacity = dto.Capacity,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.Rooms.Add(room);
            context.SaveChanges();

            return Ok(room);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRoom(int id, [FromBody] RoomDTO dto)
        {
            var room = context.Rooms.FirstOrDefault(r => r.Id == id && !r.IsDeleted);
            if (room == null)
                return NotFound();

            room.Name = dto.Name;
            room.Building = dto.Building;
            room.Capacity = dto.Capacity;
            room.UpdatedAt = DateTime.UtcNow;

            context.SaveChanges();
            return Ok(room);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id)
        {
            var room = context.Rooms.FirstOrDefault(r => r.Id == id && !r.IsDeleted);
            if (room == null)
                return NotFound();

            room.IsDeleted = true;
            room.UpdatedAt = DateTime.UtcNow;

            context.SaveChanges();
            return NoContent();
        }
    }
}
