using System.ComponentModel.DataAnnotations;

namespace ChatTP.Models
{
    public class Room
    {
      
       [Key]
       public int id { get; set; }
       [Required]
       public string? NameRoom { get; set; }
       public int idUserRoom { get; set; }
        [Required]
        public int roomtypeid { get; set; }
        public virtual ICollection<Messagge>? Messages { get; set; }


    }
}
