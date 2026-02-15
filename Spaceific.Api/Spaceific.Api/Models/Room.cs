using System.ComponentModel.DataAnnotations;

namespace Spaceific.Api.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Building { get; set; } = string.Empty;

        [Required]
        public int Capacity { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
