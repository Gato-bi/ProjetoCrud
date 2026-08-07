using Microsoft.AspNetCore.Mvc;
using ProjetoCrud.Data;
using ProjetoCrud.Models;
using Microsoft.EntityFrameworkCore;


namespace ProjetoCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ConvenioController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ConvenioController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> PostActionResultAsync(PAC_TAB_CONVENIO convenio)
        {
            _appDbContext.PAC_TAB_CONVENIO.Add(convenio);
            await _appDbContext.SaveChangesAsync();
            return Ok(convenio);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var convenio = await _appDbContext.PAC_TAB_CONVENIO.ToListAsync();

            return Ok(convenio);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PAC_TAB_CONVENIO convenio)
        {
            var convenioExistente = await _appDbContext.PAC_TAB_CONVENIO.FindAsync(id);

            if (convenioExistente == null)
            {
                return NotFound();
            }
            convenioExistente.ID_PAC_TAB_CONVENIO = convenio.ID_PAC_TAB_CONVENIO;
            convenioExistente.PAC_TAB_CONVENIO_OCULTA = convenio.PAC_TAB_CONVENIO_OCULTA;
            convenioExistente.PAC_TAB_CONVENIO_DESCRICAO = convenio.PAC_TAB_CONVENIO_DESCRICAO;
            convenioExistente.ID_PAC_TAB_CONVENIO_STATUS = convenio.ID_PAC_TAB_CONVENIO_STATUS;

            await _appDbContext.SaveChangesAsync();
            return Ok(convenioExistente);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var convenioExistente = await _appDbContext.PAC_TAB_CONVENIO.FindAsync(id);
            
            if (convenioExistente == null)
            {
                return NotFound();
            } 

            _appDbContext.PAC_TAB_CONVENIO.Remove(convenioExistente);
            await _appDbContext.SaveChangesAsync();
            return Ok(convenioExistente);
        }
    }
}