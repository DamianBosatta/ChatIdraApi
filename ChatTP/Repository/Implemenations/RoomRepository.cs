using ChatTP.DataBase;
using ChatTP.Models;
using ChatTP.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChatTP.Repository.Implemenations
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        public RoomRepository(ApplicationDbContext db) : base(db)
        {
        }
        public Room GetRoomFull(int Id)
        {
            Room res = _db.Rooms.Where(r => r.id == Id).Include(r => r.Messages).FirstOrDefault();
            var mes = res.Messages.OrderBy(x => x.time).ToList();
            res.Messages = mes;
            return res;
        }


    }
}
