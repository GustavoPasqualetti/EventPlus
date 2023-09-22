using apiweb.Event.Domains;
using apiweb.Event.Interfaces;
using apiweb.Event.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiweb.Event.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentariosEventoController : ControllerBase
    {
        private readonly IComentariosRepository _comentariosRepository;

        public ComentariosEventoController()
        {
            _comentariosRepository = new ComentariosEventoRepository();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Post(ComentariosEvento comentariosEvento)
        {
            try
            {
                _comentariosRepository.Cadastrar(comentariosEvento);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet]
        [Authorize(Roles = "aluno,admin")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_comentariosRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("{id}")]
        [Authorize(Roles = "aluno,admin")]
        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok(_comentariosRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _comentariosRepository.Deletar(id);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
