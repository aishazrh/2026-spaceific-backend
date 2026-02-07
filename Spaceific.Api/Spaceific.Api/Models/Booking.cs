namespace Spaceific.Api.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Room { get; set; } = "";
        public DateTime Start {  get; set; }
        public DateTime End { get; set; }
        public bool AllDay { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
