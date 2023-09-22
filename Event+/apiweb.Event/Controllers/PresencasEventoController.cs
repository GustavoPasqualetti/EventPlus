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
    public class PresencasEventoController : ControllerBase
    {
        private readonly IPresencasEventoRepository _presencasEventoRepository;

        public PresencasEventoController()
        {
            _presencasEventoRepository = new PresencasEventoRepository();
        }

        [HttpPost]
        [Authorize(Roles = "aluno,admin")]
        public IActionResult Post(PresencasEvento presencasEvento)
        {
            try
            {
                _presencasEventoRepository.Cadastrar(presencasEvento);
                return StatusCode(201);
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
            return Ok(_presencasEventoRepository.Listar());
        }

        [HttpDelete]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(Guid id)
        {
            _presencasEventoRepository.Deletar(id);
            return StatusCode(204);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "aluno,admin")]
        public IActionResult Get(Guid id)
        {
            return Ok(_presencasEventoRepository.ListarMinhas(id));
        }
    }
}
