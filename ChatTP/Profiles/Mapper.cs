using ChatTP.DTO.Request;
using ChatTP.DTO.Response;
using AutoMapper;
using ChatTP.Models;

namespace ChatTP.Profiles
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<RegisterRequest, User>();
            CreateMap<User, UserResponse>();
            CreateMap<Room, RoomResponse>().ReverseMap();
            CreateMap<Messagge, MessaggeResponse>();
            CreateMap<MessaggeRequest, Messagge>().ReverseMap();
        }

    }
}