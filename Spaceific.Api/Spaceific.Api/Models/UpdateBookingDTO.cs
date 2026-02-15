namespace Spaceific.Api.Models
{
    public class UpdateBookingDto
    {
        public int RoomId { get; set; }
        public string? Purpose { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool AllDay { get; set; }
    }
}
