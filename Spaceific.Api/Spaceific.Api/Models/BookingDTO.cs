using System.ComponentModel.DataAnnotations;

namespace Spaceific.Api.Models
{
    public class BookingDTO
    {
        public int RoomId { get; set; }
        public string? Purpose { get; set; }
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
