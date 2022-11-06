using ChatTP.DataBase;
using ChatTP.Models;
using ChatTP.Repository.Interfaces;

namespace ChatTP.Repository.Implemenations
{
    public class MessaggeRepository : GenericRepository<Messagge>, IMessaggeRepository
    {
        public MessaggeRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
