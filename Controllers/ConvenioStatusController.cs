using Microsoft.AspNetCore.Mvc;
using ProjetoCrud.Data;
using ProjetoCrud.Models;
using Microsoft.EntityFrameworkCore;


namespace ProjetoCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConevenioStatusController : ControllerBase
    {
                private readonly AppDbContext _appDbContext;
        public ConevenioStatusController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        // Endpoint POST api/ConevenioStatus: cadastra um novo status de convênio.
        [HttpPost]
        public async Task<IActionResult> PostActionResultAsync(CONEVENIO_TAB_STATUS conevenioStatus)
        {
            _appDbContext.CONEVENIO_TAB_STATUS.Add(conevenioStatus);
            await _appDbContext.SaveChangesAsync();

            return Ok(conevenioStatus);
        }

        // Endpoint GET api/ConevenioStatus: retorna todos os status de convênio cadastrados.
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var conevenioStatus = await _appDbContext.CONEVENIO_TAB_STATUS.ToListAsync();

            return Ok(conevenioStatus);
        }
        // Endpoint PUT api/ConevenioStatus/{id}: atualiza um status de convênio existente.
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CONEVENIO_TAB_STATUS conevenioStatus)
        {
            // Busca o status pelo ID; retorna 404 se não existir.
            var conevenioStatusExistente = await _appDbContext.CONEVENIO_TAB_STATUS.FindAsync(id);
            if (conevenioStatusExistente == null)
            {
                return NotFound();
            }
            // Sobrescreve a descrição do status existente com o valor recebido.
            conevenioStatusExistente.PAC_TAB_CONVENIO_STATUS_DESCRICAO = conevenioStatus.PAC_TAB_CONVENIO_STATUS_DESCRICAO;
            await _appDbContext.SaveChangesAsync();
            return Ok(conevenioStatusExistente);
        }
        // Endpoint DELETE api/ConevenioStatus/{id}: remove um status de convênio pelo ID.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var conevenioStatusExistente = await _appDbContext.CONEVENIO_TAB_STATUS.FindAsync(id);
            if (conevenioStatusExistente == null)
            {
                return NotFound();
            }
            _appDbContext.CONEVENIO_TAB_STATUS.Remove(conevenioStatusExistente);
            await _appDbContext.SaveChangesAsync();
            return Ok(conevenioStatusExistente);
        }
    }
}