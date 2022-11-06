using System.ComponentModel.DataAnnotations;

namespace ChatTP.Models
{
    public class RoomType
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
