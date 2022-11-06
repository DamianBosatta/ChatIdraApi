namespace ChatTP.DTO.Request
{
    public class MessaggeRequest
    {
        
        public string? messaggebody { get; set; }
        public int idUser { get; set; }
        public int idRoom { get; set; }
        public DateTime? msjTime { get; set; }
    }
}
