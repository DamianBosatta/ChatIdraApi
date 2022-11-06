using ChatTP.Models;

namespace ChatTP.Repository.Interfaces
{
    public interface IRoomRepository : IGenericRepository<Room>
    {
        Room GetRoomFull(int id);

    }
}
