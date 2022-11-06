using ChatTP.Models;

namespace ChatTP.Repository.Interfaces
{
    public interface IUserRoomRepository : IGenericRepository<UserRoom>
    {
        IEnumerable<UserRoom> GetRoomsFull(string id);
    }
}
