using Microsoft.AspNetCore.Mvc;
using ProjetoCrud.Data;
using ProjetoCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetoCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class EspecialidadeController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public EspecialidadeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        // Endpoint POST api/Especialidade: cadastra uma nova especialidade.
        [HttpPost]
        public async Task<IActionResult> PostActionResultAsync(MED_TAB_ESPECIALIDADE especialidade)
        {
            _appDbContext.MED_TAB_ESPECIALIDADE.Add(especialidade);
            await _appDbContext.SaveChangesAsync();

            return Ok(especialidade);
        }


        // Endpoint GET api/Especialidade: retorna todos os registros de especialidade.
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var especialidade = await _appDbContext.MED_TAB_ESPECIALIDADE.ToListAsync();

            return Ok(especialidade);
        }


        // Endpoint PUT api/Especialidade/{id}: atualiza um registro de especialidade existente.
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, MED_TAB_ESPECIALIDADE especialidade)
        {
            // Busca a especialidade pelo ID; retorna 404 se não existir.
            var especialidadeExistente = await _appDbContext.MED_TAB_ESPECIALIDADE.FindAsync(id);

            if (especialidadeExistente == null)
            {
                return NotFound();
            }

            // Sobrescreve os campos da especialidade existente com os valores recebidos.
            especialidadeExistente.ID_MED_TAB_ESPECIALIDADE = especialidade.ID_MED_TAB_ESPECIALIDADE;
            especialidadeExistente.MED_TAB_ESPECIALIDADE_DESCRICAO = especialidade.MED_TAB_ESPECIALIDADE_DESCRICAO;
            especialidadeExistente.MED_TAB_ESPECIALIDADE_OCULTA = especialidade.MED_TAB_ESPECIALIDADE_OCULTA;

            await _appDbContext.SaveChangesAsync();

            return Ok(especialidadeExistente);
        }


        // Endpoint DELETE api/Especialidade/{id}: remove um registro de especialidade pelo ID.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var especialidade = await _appDbContext.MED_TAB_ESPECIALIDADE.FindAsync(id);

            if (especialidade == null)
            {
                return NotFound();
            }

            _appDbContext.MED_TAB_ESPECIALIDADE.Remove(especialidade);
            await _appDbContext.SaveChangesAsync();

            return Ok(especialidade);
        }
    }
}