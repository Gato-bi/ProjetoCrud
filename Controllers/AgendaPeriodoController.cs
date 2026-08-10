using Microsoft.AspNetCore.Mvc;
using ProjetoCrud.Data;
using ProjetoCrud.Models;
using ProjetoCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetoCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AgendaPeriodoController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public AgendaPeriodoController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }




        // Endpoint POST api/AgendaPeriodo: cadastra um novo período de agenda.
        [HttpPost]
        public async Task<IActionResult> PostActionResultAsync(MED_TAB_AGENDA_PERIODO agendaPerido)
        {
            _appDbContext.Add(agendaPerido);
            await _appDbContext.SaveChangesAsync();

            return Ok(agendaPerido);
        }
        // Endpoint GET api/AgendaPeriodo: retorna todos os períodos de agenda cadastrados.
        [HttpGet]
        public async Task<IActionResult> GetActionResultAsync()
        {
            var agendaPeriodos = await _appDbContext.MED_TAB_AGENDA_PERIODO.ToListAsync();
            return Ok(agendaPeriodos);
        }
        // Endpoint PUT api/AgendaPeriodo/{id}: atualiza um período de agenda existente.
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, MED_TAB_AGENDA_PERIODO agendaPerido)
        {
            // Busca o período pelo ID; retorna 404 se não existir.
            var agendaPeriodoExistente = await _appDbContext.MED_TAB_AGENDA_PERIODO.FindAsync(id);
            if (agendaPeriodoExistente == null)
            {
                return NotFound();
            }

            // Sobrescreve os campos do período existente com os valores recebidos.
            agendaPeriodoExistente.ID_MED_TAB_AGENDA_PERIODO = agendaPerido.ID_MED_TAB_AGENDA_PERIODO;
            agendaPeriodoExistente.MED_TAB_AGENDA_PERIODO_DESCRICAO = agendaPerido.MED_TAB_AGENDA_PERIODO_DESCRICAO;
            agendaPeriodoExistente.MED_TAB_AGENDA_PERIODO_OCULTA = agendaPerido.MED_TAB_AGENDA_PERIODO_OCULTA;

            await _appDbContext.SaveChangesAsync();
            return Ok(agendaPeriodoExistente);
        }
        // Endpoint DELETE api/AgendaPeriodo/{id}: remove um período de agenda pelo ID.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var agendaPeriodoExistente = await _appDbContext.MED_TAB_AGENDA_PERIODO.FindAsync(id);
            if (agendaPeriodoExistente == null)
            {
                return NotFound();
            }

            _appDbContext.MED_TAB_AGENDA_PERIODO.Remove(agendaPeriodoExistente);
            await _appDbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}