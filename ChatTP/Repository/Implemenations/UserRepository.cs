using ChatTP.DataBase;
using ChatTP.Models;
using ChatTP.Repository.Interfaces;

namespace ChatTP.Repository.Implemenations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext db) : base(db)
        {
        }
        public User GetByEmail(string? email)
        {
            return _db.Users.Where(a => a.mail == email).FirstOrDefault();
        }
        public bool ExisteUsuario(string email)
        {
            return _db.Users.Any(a => a.mail == email);
        }
    }
}
