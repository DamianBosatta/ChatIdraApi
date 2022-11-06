using ChatTP.Models;

namespace ChatTP.Repository.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetByEmail(string email);
        bool ExisteUsuario(string email);
    }
}
