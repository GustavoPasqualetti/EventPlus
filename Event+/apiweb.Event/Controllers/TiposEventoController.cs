using apiweb.Event.Domains;
using apiweb.Event.Interfaces;
using apiweb.Event.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace apiweb.Event.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TiposEventoController : ControllerBase
    {
        private ITiposEventoRepository _tiposEventoRepository;

        public TiposEventoController()
        {
            _tiposEventoRepository = new TiposEventoRepository();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Post(TiposEvento tiposEvento)
        {
            try
            {
                _tiposEventoRepository.Cadastrar(tiposEvento);
                return StatusCode(201);
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
            _tiposEventoRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpGet]
        [Authorize(Roles = "aluno,admin")]
        public IActionResult Get()
        {
            return Ok(_tiposEventoRepository.Listar());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "aluno,admin")]
        public IActionResult Get(Guid id) 
        { 
            return Ok(_tiposEventoRepository.BuscarPorId(id));
        }
    }
}