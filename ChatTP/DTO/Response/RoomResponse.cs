namespace ChatTP.DTO.Response
{
    public class RoomResponse
    {
        public int id { get; set; }
        public string? NameRoom { get; set; }
        public int roomtypeid { get; set; }
        public virtual ICollection<MessaggeResponse>? Messages { get; set; }

    }
}
