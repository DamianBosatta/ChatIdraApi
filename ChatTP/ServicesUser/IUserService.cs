using ChatTP.DTO.Request;
using ChatTP.DTO.Response;

namespace ChatTP.Services
{
    public interface IUserService
    {
        UserResponse Register(RegisterRequest usuario);
        UserResponse Login(LoginRequest loginUser);
        UserResponse OffLogin(LoginRequest loginUser);
    }
}
