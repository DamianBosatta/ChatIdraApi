using System.ComponentModel.DataAnnotations;

namespace ChatTP.Models
{
    public class Messagge
    {
       [Key]
       public int id { get; set; }
        public string? messaggebody { get; set; }
       public int idUser { get; set; }
       public int idRoom { get; set; }
        public DateTime time { get; set; }
        public Room? roomchat { get; set; }  
    }
}
