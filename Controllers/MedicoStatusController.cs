using Microsoft.AspNetCore.Mvc;
using ProjetoCrud.Data;
using ProjetoCrud.Models;
using Microsoft.EntityFrameworkCore;


namespace ProjetoCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class MedicoStatusController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public MedicoStatusController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        // Endpoint POST api/MedicoStatus: cadastra um novo status de médico.
        [HttpPost]
        public async Task<IActionResult> PostActionResultAsync(MED_TAB_STATUS medicoStatus)
        {
            _appDbContext.MED_TAB_STATUS.Add(medicoStatus);
            await _appDbContext.SaveChangesAsync();

            return Ok(medicoStatus);
        }

        // Endpoint GET api/MedicoStatus: retorna todos os status de médico cadastrados.
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var medicoStatus = await _appDbContext.MED_TAB_STATUS.ToListAsync();
            return Ok(medicoStatus);
        }

        // Endpoint PUT api/MedicoStatus/{id}: atualiza um status de médico existente.
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, MED_TAB_STATUS medicoStatus)
        {
            // Busca o status pelo ID; retorna 404 se não existir.
            var medicoStatusExistente = await _appDbContext.MED_TAB_STATUS.FindAsync(id);
            if (medicoStatusExistente == null)
            {
                return NotFound();
            }

            // Sobrescreve os campos do status existente com os valores recebidos.
            medicoStatusExistente.MED_TAB_STATUS_DESCRICAO = medicoStatus.MED_TAB_STATUS_DESCRICAO;
            medicoStatusExistente.MED_TAB_STATUS_OCULTA = medicoStatus.MED_TAB_STATUS_OCULTA;

            await _appDbContext.SaveChangesAsync();
            return Ok(medicoStatus);
        }

        // Endpoint DELETE api/MedicoStatus/{id}: remove um status de médico pelo ID.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var medicoStatus = await _appDbContext.MED_TAB_STATUS.FindAsync(id);
            if (medicoStatus == null)
            {
                return NotFound();
            }
            _appDbContext.MED_TAB_STATUS.Remove(medicoStatus);
            await _appDbContext.SaveChangesAsync();

            return Ok(medicoStatus);
        }
    }
}