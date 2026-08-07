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
        [HttpPost]
        public async Task<IActionResult> PostActionResultAsync(MED_TAB_STATUS medicoStatus)
        {
            _appDbContext.MED_TAB_STATUS.Add(medicoStatus);
            await _appDbContext.SaveChangesAsync();

            return Ok(medicoStatus);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var medicoStatus = await _appDbContext.MED_TAB_STATUS.ToListAsync();
            return Ok(medicoStatus);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, MED_TAB_STATUS medicoStatus)
        {
            var medicoStatusExistente = await _appDbContext.MED_TAB_STATUS.FindAsync(id);
            if (medicoStatusExistente == null)
            {
                return NotFound();
            }
            
            medicoStatusExistente.MED_TAB_STATUS_DESCRICAO = medicoStatus.MED_TAB_STATUS_DESCRICAO;
            medicoStatusExistente.MED_TAB_STATUS_OCULTA = medicoStatus.MED_TAB_STATUS_OCULTA;

            await _appDbContext.SaveChangesAsync();
            return Ok(medicoStatus);
        }

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