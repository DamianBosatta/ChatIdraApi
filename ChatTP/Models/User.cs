using System.ComponentModel.DataAnnotations;

namespace ChatTP.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string? username { get; set; }
        public int age { get; set; }
        public string? mail { get; set; }
        public string? password { get; set; }
        public bool conectado { get; set; }    





    }
}
