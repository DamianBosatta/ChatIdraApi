using ChatTP.DTO.Response;
using ChatTP.Models;

namespace ChatTP.ServiceRoom
{
    public interface IServiceRoom
    {
        int AddRoom(Room room);
        void AddUserRoom(string userId, int roomId, string name);
        List<RoomResponse> ListRoomPublic();
        List<RoomResponse> ListRoomPrivate(string id);
        RoomResponse RoomPrivateCreate(string user1Id, string user1Name, string user2Name, string user2Id);
        RoomResponse MessaggesGroup(int id);


    }
}
