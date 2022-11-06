using AutoMapper;
using AutoMapper.Internal;
using ChatTP.DTO.Request;
using ChatTP.DTO.Response;
using ChatTP.Models;
using ChatTP.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace ChatTP.Services
{
    public class UserService :IUserService
    {
        private readonly IUnitOfWork _uOW;
       
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork uow, IMapper mapper)
        {
            _uOW = uow;
          
            _mapper = mapper;
        }

        public UserResponse Login(LoginRequest userLogin)
        {
            if (_uOW.UserRepository.ExisteUsuario(userLogin.mail))
            {
                UserResponse response = new UserResponse();
                //traigo el usuario, por el email
                User user = _uOW.UserRepository.GetByEmail(userLogin.mail);
                user.conectado = true;
                //aca mappeo de un Usuario a un UserResponse para no devolver cosas innecesarias
                response = _mapper.Map<UserResponse>(user);
                //Devuelvo la respuesta si esta todo bien
                return response;
            }

            return null;
        }


        public UserResponse OffLogin(LoginRequest userLogin)
        {
            if (_uOW.UserRepository.ExisteUsuario(userLogin.mail))
            {
                UserResponse response = new UserResponse();
               
                User user = _uOW.UserRepository.GetByEmail(userLogin.mail);
                user.conectado = false;
            
                response = _mapper.Map<UserResponse>(user);
                
                return response;
            }

            return null;
        }




        public UserResponse Register(RegisterRequest user)
        {
            User usuario = _mapper.Map<User>(user);

            _uOW.UserRepository.Insert(usuario);
            _uOW.Save();
            UserResponse response = _mapper.Map<UserResponse>(usuario);
            return response;

        }

   
    }

}

