using ChatTP.Repository.Interfaces;

namespace ChatTP.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IMessaggeRepository MessaggeRepository { get; }
        IRoomRepository  RoomRepository { get; }
        IUserRepository UserRepository { get; }
        IUserRoomRepository UserRoomRepository { get; }
        IRoomTypeRepository RoomTypeRepository { get; }
        void Save();

    }
}
