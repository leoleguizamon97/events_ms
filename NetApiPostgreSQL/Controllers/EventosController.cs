using Microsoft.AspNetCore.Mvc;
using NetApiPostgreSQL.Models;
using NetApiPostgreSQL.Repositories;

namespace NetApiPostgreSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly EventosInterface _eventosInterface;

        public EventosController(EventosInterface eventosInterface)
        {
            _eventosInterface = eventosInterface;
        }

        // GET: api/Eventos
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var eventos = await _eventosInterface.GetAll();
            return Ok(eventos);
        }

        // GET: api/Eventos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var evento = await _eventosInterface.GetEvento(id);
            if (evento == null)
                return NotFound();

            return Ok(evento);
        }

        // POST: api/Eventos
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Evento evento)
        {
            var result = await _eventosInterface.InsertEvento(evento);
            if (result)
                return CreatedAtAction(nameof(Get), new { id = evento.Id }, evento);

            return BadRequest("No se pudo crear el evento");
        }

        // PUT: api/Eventos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Evento evento)
        {
            if (id != evento.Id)
                return BadRequest("ID del body no coincide con el ID de la ruta");

            var result = await _eventosInterface.UpdateEvento(evento);
            if (result)
                return NoContent();

            return NotFound("Evento no encontrado");
        }

        // DELETE: api/Eventos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _eventosInterface.DeleteEvento(id);
            if (result)
                return NoContent();

            return NotFound("Evento no encontrado");
        }
    }
}
