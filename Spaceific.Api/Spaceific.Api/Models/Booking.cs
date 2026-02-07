using System.ComponentModel.DataAnnotations;

namespace Spaceific.Api.Models
{
    public class Booking
    {
        public int Id { get; set; }
        [Required] 
        public string FirstName { get; set; } = string.Empty;
        [Required] 
        public string LastName { get; set; } = string.Empty;
        [Required] 
        public string Room { get; set; } = string.Empty;
        [Required] 
        public string? Purpose { get; set; }

        public DateTime Start {  get; set; }
        public DateTime End { get; set; }
        public bool AllDay { get; set; }

        [Required] 
        public string Status { get; set; } = "Pending";
        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
