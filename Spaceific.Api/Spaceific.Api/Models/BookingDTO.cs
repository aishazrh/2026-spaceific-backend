using System.ComponentModel.DataAnnotations;

namespace Spaceific.Api.Models
{
    public class BookingDTO
    {
        [Required] 
        public string FirstName { get; set; } = string.Empty;
        [Required] 
        public string LastName { get; set; } = string.Empty;
        [Required] 
        public string Room { get; set; } = string.Empty;
        [Required]
        [MaxLength(500)]
        public string Purpose { get; set; } = string.Empty;

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool AllDay { get; set; }

        [Required] 
        public string Status { get; set; } = "Pending";
    }
    public class UpdateBookingStatusDto
    {
        public string Status { get; set; } = string.Empty;
    }

}
