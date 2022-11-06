using ChatTP.DataBase;
using ChatTP.Models;
using ChatTP.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChatTP.Repository.Implemenations
{
    public class UserRoomRepository : GenericRepository<UserRoom>, IUserRoomRepository
    {
        public UserRoomRepository(ApplicationDbContext db) : base(db)
        {
        }
        public IEnumerable<UserRoom> GetRoomsFull(string id)
        {
            return _db.UserRooms.Where(r => r.IdUser == id).Include(y => y.RoomChats).ToList();
        }
    }
}
