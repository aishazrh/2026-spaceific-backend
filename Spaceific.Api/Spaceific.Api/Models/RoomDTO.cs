using System.ComponentModel.DataAnnotations;

namespace Spaceific.Api.Models
{
    public class RoomDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public string Building { get; set; } = string.Empty;
        
        [Required]
        public int Capacity { get; set; }
    }
}
