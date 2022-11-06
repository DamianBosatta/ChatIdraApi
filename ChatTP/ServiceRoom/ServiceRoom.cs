using AutoMapper;
using ChatTP.DTO.Response;
using ChatTP.Models;
using ChatTP.UnitOfWork;

namespace ChatTP.ServiceRoom
{
    public class ServiceRoom : IServiceRoom
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public ServiceRoom(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public List<RoomResponse> ListRoomPublic() // lista de grupos publicos
        {
            List<Room> groupChats = new List<Room>();
            groupChats = _uow.RoomRepository.find(x => x.roomtypeid == 1).ToList();
            List<RoomResponse> resGroup = MapperRoom(groupChats);
            return resGroup;
        }

        public List<RoomResponse> ListRoomPrivate(string id) // lista de chats privados
        {
            List<RoomResponse> res = new List<RoomResponse>();
            List<Room> rchat = new List<Room>();
            Room rChatAux = new Room();
            List<UserRoom> userRooms = _uow.UserRoomRepository.GetRoomsFull(id).ToList();
            foreach (UserRoom userRoom in userRooms)
            {
                rChatAux = userRoom.RoomChats;
                rChatAux.NameRoom = userRoom.name;
                rchat.Add(rChatAux);
            }
            res = _mapper.Map<List<RoomResponse>>(rchat);
            return res;
        }
        public RoomResponse RoomPrivateCreate(string user1Id, string user1Name, string user2Name, string user2Id) // buscamos chat privado , si esta lo devolvemos con sus historial
                                                                                                                  // de msj por hora,
                                                                                                                  // si no esta el chat  lo creamos
        {
            Room roomChat = new Room();
            List<UserRoom> list1 = _uow.UserRoomRepository.GetRoomsFull(user1Id).ToList();
            List<UserRoom> list2 = _uow.UserRoomRepository.GetRoomsFull(user2Id).ToList();

            UserRoom userRoom = (from x in list1
                                 where list2.Any(y => y.RoomChats.id == x.RoomChats.id && y.RoomChats.roomtypeid == 2 && x.RoomChats.roomtypeid == 2)
                                 select x).FirstOrDefault();

            //aqui creamos la sala de chat
            if (userRoom == null)
            {
                roomChat.NameRoom = "priv";
                roomChat.roomtypeid = 2;
                int aux = AddRoom(roomChat);
                AddUserRoom(user1Id, aux, user2Name);
                AddUserRoom(user2Id, aux, user1Name);
                userRoom = new UserRoom();
                userRoom.IdRoom = aux;
            }

            roomChat = _uow.RoomRepository.GetRoomFull(userRoom.IdRoom);
            RoomResponse roomResponse = _mapper.Map<RoomResponse>(roomChat);
            return roomResponse;
        }
        public RoomResponse MessaggesGroup(int id)// lista de mensajes de los grupos publicos
        {
            Room aux = _uow.RoomRepository.GetRoomFull(id);
            return _mapper.Map<RoomResponse>(aux);
        }
        public void AddUserRoom(string userId, int roomId, string name)
        {
            UserRoom u = new UserRoom();
            u.IdRoom= roomId;
            u.IdUser = userId;
            u.name = name;
            _uow.UserRoomRepository.Insert(u);
            _uow.Save();
        }
        public int AddRoom(Room room)
        {
            room.roomtypeid = 2;
            _uow.RoomRepository.Insert(room);
            _uow.Save();
            var id = _uow.RoomRepository.GetAll().Last();
            return id.id;
        }

        private List<RoomResponse> MapperRoom(List<Room> li)
        {
            List<RoomResponse> roomResponses = new List<RoomResponse>();
            List<MessaggeResponse> mlist = new List<MessaggeResponse>();
            RoomResponse aux;
            MessaggeResponse mAux;
            foreach (Room roomChat in li)
            {
                if (roomChat.Messages != null)
                {
                    foreach (var m in roomChat.Messages)
                    {
                        mAux = _mapper.Map<MessaggeResponse>(m);
                        mlist.Add(mAux);
                    }
                }
                aux = _mapper.Map<RoomResponse>(roomChat);
                aux.Messages = mlist;
                roomResponses.Add(aux);
            }
            return roomResponses;
        }


    }
}
