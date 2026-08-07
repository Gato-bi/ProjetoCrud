using Microsoft.AspNetCore.Mvc;
using ProjetoCrud.Data;
using ProjetoCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetoCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;


        public PacienteController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarPaciente(MED_PACIENTE paciente)
        {
            _appDbContext.Add(paciente);
            await _appDbContext.SaveChangesAsync();

            return Ok(paciente);
        }
        [HttpGet]
        public async Task<IActionResult> ObterPacientes()
        {
            var pacientes = await _appDbContext.MED_PACIENTE.ToListAsync();
            return Ok(pacientes);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarPaciente(int id, MED_PACIENTE paciente)
        {
            var pacienteExistente = await _appDbContext.MED_PACIENTE.FindAsync(id);
            if (pacienteExistente == null)
            {
                return NotFound();
            }
            pacienteExistente.ID_PAC_RG_CIN = paciente.ID_PAC_RG_CIN;
            pacienteExistente.PAC_CPF = paciente.PAC_CPF;
            pacienteExistente.PAC_NOME_COMPLETO = paciente.PAC_NOME_COMPLETO;
            pacienteExistente.PAC_SEXO = paciente.PAC_SEXO;
            pacienteExistente.PAC_TELEFONE = paciente.PAC_TELEFONE;
            pacienteExistente.PAC_ENDERECO = paciente.PAC_ENDERECO;
            pacienteExistente.PAC_CEP = paciente.PAC_CEP;
            pacienteExistente.PAC_NUMERO = paciente.PAC_NUMERO;
            pacienteExistente.PAC_BAIRRO = paciente.PAC_BAIRRO;
            pacienteExistente.PAC_CIDADE = paciente.PAC_CIDADE;
            pacienteExistente.PAC_UF = paciente.PAC_UF;
            pacienteExistente.PAC_COMPLEMENTO = paciente.PAC_COMPLEMENTO;
            pacienteExistente.ID_PAC_TAB_CONVENIO = paciente.ID_PAC_TAB_CONVENIO;

            await _appDbContext.SaveChangesAsync();
            return Ok(pacienteExistente);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarPaciente(int id)
        {
            var pacienteExistente = await _appDbContext.MED_PACIENTE.FindAsync(id);
            if (pacienteExistente == null)
            {
                return NotFound();
            }

            _appDbContext.MED_PACIENTE.Remove(pacienteExistente);
            await _appDbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}