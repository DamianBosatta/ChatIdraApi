using ChatTP.DataBase;
using ChatTP.Repository.Implemenations;
using ChatTP.Repository.Interfaces;

namespace ChatTP.UnitOfWork
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            MessaggeRepository = new MessaggeRepository(context);
            RoomRepository = new RoomRepository(context);
            UserRepository = new UserRepository(context);
            UserRoomRepository = new UserRoomRepository(context);
            RoomTypeRepository = new RoomTypeRepository(context);
        }

        public IMessaggeRepository MessaggeRepository { get; private set; }

        public IRoomRepository RoomRepository { get; private set; }

        public IUserRepository UserRepository { get; private set; }

        public IUserRoomRepository UserRoomRepository { get; private set; }

        public IRoomTypeRepository RoomTypeRepository { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
