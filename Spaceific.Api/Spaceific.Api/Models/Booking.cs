using Spaceific.Api.Models;
using System.ComponentModel.DataAnnotations;

public class Booking
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }

    [Required]
    public int RoomId { get; set; }
    public Room? Room { get; set; }

    [Required]
    public string Purpose { get; set; } = string.Empty;

    public DateTime Start { get; set; }
    public DateTime End { get; set; }

    public bool AllDay { get; set; }
    public string Status { get; set; } = "Pending";
    public bool IsDeleted { get; set; } = false;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
