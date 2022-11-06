using ChatTP.DataBase;
using ChatTP.DTO.Request;
using ChatTP.DTO.Response;
using ChatTP.ServiceRoom;
using ChatTP.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace ChatTP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : Controller
    {
       
        private readonly IServiceRoom _roomChatService;
        private readonly IUnitOfWork _uow;
        private readonly ApplicationDbContext _context;

        public RoomController(ApplicationDbContext context, IServiceRoom _room, IUnitOfWork uow)
        {
            _context = context;
            _roomChatService = _room;
            _uow = uow;
        }


        [HttpGet("{id}")]
        public ActionResult<List<RoomResponse>> GetRoomList(string id) // id de usuario y devuelve los chat de ese usuario
        {
            if (_uow.RoomRepository == null) // chequea si el repo tiene info
            {
                return NotFound();
            }
            List<RoomResponse> groupList = _roomChatService.ListRoomPublic(); // crea una lista de los chat publicos
            var roomChat = _roomChatService.ListRoomPrivate(id);// crea una lista de privados
            groupList.AddRange(roomChat); // de acuerdo al parametro compara el rango

            if (roomChat == null) // verifica si esta nula
            {
                return NotFound();
            }

            return groupList; // devuelve la que corresponda
        }


        [HttpGet("/api/[controller]/group/{id}")]
        public IActionResult GetGroupChat(int id) // recibe id de chat y devuelve historial de msj
        {
            var room = _roomChatService.MessaggesGroup(id);
            return Ok(room);
        }


          [HttpPost("/api/[controller]/priv")]
        public IActionResult PostPrivateChat([FromBody] RoomRequest rRequest) // buscamos , si no existe creamos chat .
        {
            var room = _roomChatService.RoomPrivateCreate(rRequest.idTransmitter,rRequest.TransmitterName, rRequest.ArrivalName, rRequest.idArrival);
            return Ok(room);
        }



          [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomChat(int id)//pasamos id de chat y lo eliminamos
        {
            if (_context.Rooms == null)
            {
                return NotFound();
            }
            var roomChat = await _context.Rooms.FindAsync(id);
            if (roomChat == null)
            {
                return NotFound();
            }

            _context.Rooms.Remove(roomChat);
            await _context.SaveChangesAsync();

            return NoContent();
        }




    }
}
