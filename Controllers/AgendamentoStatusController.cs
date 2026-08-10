using Microsoft.AspNetCore.Mvc;
using ProjetoCrud.Data;
using ProjetoCrud.Models;
using Microsoft.EntityFrameworkCore;


namespace ProjetoCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AgendamentosStatusController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public AgendamentosStatusController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        // Endpoint POST api/AgendamentoStatus: cadastra um novo status de agendamento.
        [HttpPost]
        public async Task<IActionResult> PostActionResultAsync(MED_AGENDAMENTO_STATUS agendamentoStatus)
        {
            _appDbContext.MED_AGENDAMENTO_STATUS.Add(agendamentoStatus);
            await _appDbContext.SaveChangesAsync();

            return Ok(agendamentoStatus);
        }
        // Endpoint GET api/AgendamentoStatus: retorna todos os status de agendamento cadastrados.
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var agendamentoStatus = await _appDbContext.MED_AGENDAMENTO_STATUS.ToListAsync();
            return Ok(agendamentoStatus);
        }
        // Endpoint PUT api/AgendamentoStatus/{id}: atualiza um status de agendamento existente.
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, MED_AGENDAMENTO_STATUS agendamentoStatus)
        {
            // Busca o status pelo ID; retorna 404 se não existir.
            var agendamentoStatusExistente = await _appDbContext.MED_AGENDAMENTO_STATUS.FindAsync(id);
            if (agendamentoStatusExistente == null)
            {
                return NotFound();
            }
            // Sobrescreve os campos do status existente com os valores recebidos.
            agendamentoStatusExistente.MED_AGENDAMENTO_STATUS_DESCRICAO = agendamentoStatus.MED_AGENDAMENTO_STATUS_DESCRICAO;
            agendamentoStatusExistente.MED_AGENDAMENTO_STATUS_OCULTA = agendamentoStatus.MED_AGENDAMENTO_STATUS_OCULTA;

            await _appDbContext.SaveChangesAsync();
            return Ok(agendamentoStatus);
        }
        // Endpoint DELETE api/AgendamentoStatus/{id}: remove um status de agendamento pelo ID.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var agendamentoStatusExistente = await _appDbContext.MED_AGENDAMENTO_STATUS.FindAsync(id);
            if (agendamentoStatusExistente == null)
            {
                return NotFound();
            }
            _appDbContext.MED_AGENDAMENTO_STATUS.Remove(agendamentoStatusExistente);
            await _appDbContext.SaveChangesAsync();
            return Ok(agendamentoStatusExistente);
        }
    }
}