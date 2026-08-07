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
        [HttpPost]
        public async Task<IActionResult> PostActionResultAsync(CONEVENIO_TAB_STATUS conevenioStatus)
        {
            _appDbContext.CONEVENIO_TAB_STATUS.Add(conevenioStatus);
            await _appDbContext.SaveChangesAsync();

            return Ok(conevenioStatus);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var conevenioStatus = await _appDbContext.CONEVENIO_TAB_STATUS.ToListAsync();

            return Ok(conevenioStatus);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CONEVENIO_TAB_STATUS conevenioStatus)
        {
            var conevenioStatusExistente = await _appDbContext.CONEVENIO_TAB_STATUS.FindAsync(id);
            if (conevenioStatusExistente == null)
            {
                return NotFound();
            }
            conevenioStatusExistente.PAC_TAB_CONVENIO_STATUS_DESCRICAO = conevenioStatus.PAC_TAB_CONVENIO_STATUS_DESCRICAO;
            await _appDbContext.SaveChangesAsync();
            return Ok(conevenioStatusExistente);
        }
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