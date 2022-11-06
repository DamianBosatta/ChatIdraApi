using AutoMapper;
using ChatTP.DTO.Request;
using ChatTP.DTO.Response;
using ChatTP.Models;
using ChatTP.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ChatTP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessaggeController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public MessaggeController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Messagge>>> GetMessages() // devuelve todos los mensajes existentes.
        {
            if (_uow.MessaggeRepository == null)
            {
                return NotFound();
            }

           var aux = _uow.MessaggeRepository.GetAll();
          
            return Ok(aux);
        }

     
        [HttpGet("{id}")]
        public async Task<ActionResult<Messagge>> GetMessage(int id)// busca mensaje por id y muestra.
        {
            if (_uow.MessaggeRepository == null)
            {
                return NotFound();
            }
            var message = _uow.MessaggeRepository.GetById(id);

            if (message == null)
            {
                return NotFound();
            }

            return message;
        }
        [HttpPost]
        public ActionResult PostMessagge([FromBody] MessaggeRequest msj) // creamos mensajes.
        {
            Messagge mensaje = _mapper.Map<Messagge>(msj);
            _uow.MessaggeRepository.Insert(mensaje);
            _uow.Save();
            return Ok();
        }

       
        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id) // recibe id de mensaje y lo elimina.
        {
            if (_uow.MessaggeRepository == null)
            {
                return NotFound();
            }
            var message = _uow.MessaggeRepository.GetById(id);
            if (message == null)
            {
                return NotFound();
            }

            _uow.MessaggeRepository.Delete(id);
            _uow.Save();

            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessage(int _id, Messagge message) // pido id de mensaje y mensaje nuevo para ser editado.
        {
            if (_id != message.id)
            {
                return BadRequest();
            }

            _uow.MessaggeRepository.Update(message);
            _uow.Save();

            return NoContent();
        }

    }



}

