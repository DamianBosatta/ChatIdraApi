using ChatTP.DataBase;
using ChatTP.Models;
using ChatTP.Repository.Interfaces;

namespace ChatTP.Repository.Implemenations
{
    public class RoomTypeRepository : GenericRepository<RoomType>, IRoomTypeRepository
    {
        public RoomTypeRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
