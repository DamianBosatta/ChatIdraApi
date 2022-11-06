using System.ComponentModel.DataAnnotations;

namespace ChatTP.Models
{
    public class UserRoom
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set; }
        public int IdRoom { get; set; }
        public string? IdUser { get; set; }

        public Room? RoomChats { get; set; }


    }
}
