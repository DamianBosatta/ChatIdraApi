using System.ComponentModel.DataAnnotations;

namespace ChatTP.DTO.Request
{
    public class RegisterRequest
    {
        [Required]
        public string? username { get; set; }
        public int age { get; set; }
        [Required]
        public string? mail { get; set; }
        [Required]
        public string? password { get; set; }
    }
}
