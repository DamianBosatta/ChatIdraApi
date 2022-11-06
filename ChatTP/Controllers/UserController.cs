using ChatTP.DTO.Request;
using ChatTP.DTO.Response;
using ChatTP.Models;
using ChatTP.Services;
using ChatTP.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace ChatTP.Controllers
{
    [Route("auth/login")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _usuarioService;
        private readonly IUnitOfWork _uow;

        public UserController(IUserService usuarioService, IUnitOfWork uow)
        {
            _usuarioService = usuarioService;
            _uow = uow;
        }
        [HttpPost]
        public ActionResult Login([FromBody] LoginRequest req)
        {
            var response = _usuarioService.Login(req);
            if (response == null)
            {
                return Unauthorized();
            }
            
            return Ok(response);
        }

        [HttpPut]
        public ActionResult OffLogin([FromBody] LoginRequest req)
        {
            var response = _usuarioService.Login(req);
            if (response == null)
            {
                return Unauthorized();
            }
          
            return Ok(response);
        }



        [HttpPost("register")]
        public async Task<ActionResult> RegistrarUsuario([FromBody] RegisterRequest user)
        {
            if (_uow.UserRepository.ExisteUsuario(user.mail.ToLower()))
            {
                return BadRequest("Ya existe un cuenta asociada a ese Email");
            }
            UserResponse res = _usuarioService.Register(user);
            
            return Ok(res);

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetUserOnLine() // devuelve todos los usuarios conectados
        {
            var listOnLine = _usuarioService.GetUsers().ToList();
          
            if (listOnLine== null)
            {
                return NotFound();
            }

           

            return Ok(listOnLine);
        }


    }
}
