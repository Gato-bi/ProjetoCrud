using System;
using Microsoft.AspNetCore.Mvc;
using ProjetoCrud.Data;
using ProjetoCrud.Models;
using Microsoft.EntityFrameworkCore;


namespace ProjetoCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentoController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        
        
        
        public AgendamentoController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        [HttpPost]
        public async Task<IActionResult> CriarAgendamento(MED_AGENDAMENTO agendamento)
        {
            _appDbContext.Add(agendamento);
            await _appDbContext.SaveChangesAsync();

            return Ok(agendamento);
        }
        [HttpGet]
        public async Task<IActionResult> ConsultarAgendamento()
        {
            var agendamentos = await (
                from ag in _appDbContext.MED_AGENDAMENTO
                join pac in _appDbContext.MED_PACIENTE on ag.ID_PAC_RG_CIN equals pac.ID_PAC_RG_CIN
                join med in _appDbContext.MED_MEDICO_DADOS on ag.ID_MED_CRM equals med.ID_MED_CRM
                join esp in _appDbContext.MED_TAB_ESPECIALIDADE on med.ID_MED_TAB_ESPECIALIDADE equals esp.ID_MED_TAB_ESPECIALIDADE
                select new
                {   
                    AgendamentoId = ag.ID_MED_AGENDAMENTO,
                    Data = ag.MED_AGENDAMENTO_DATA,
                    Horario = ag.MED_AGENDAMENTO_HORARIO,
                    Paciente = pac.PAC_NOME_COMPLETO,
                    Medico = med.MED_NOME_COMPLETO,
                    Especialidade = esp.MED_TAB_ESPECIALIDADE_DESCRICAO,
                }
                    ).ToListAsync();
                return Ok(agendamentos);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarAgendamento(int id, MED_AGENDAMENTO agendamento)
        {
            var agendamentoExistente = await _appDbContext.MED_AGENDAMENTO.FindAsync(id);
            if (agendamentoExistente == null)
            {
                return NotFound();
            }
            agendamentoExistente.ID_MED_CRM = agendamento.ID_MED_CRM;
            agendamentoExistente.ID_PAC_RG_CIN = agendamento.ID_PAC_RG_CIN;
            agendamentoExistente.ID_MED_TAB_AGENDA_PERIODO = agendamento.ID_MED_TAB_AGENDA_PERIODO;
            agendamentoExistente.ID_MED_AGENDAMENTO_STATUS = agendamento.ID_MED_AGENDAMENTO_STATUS;
            agendamentoExistente.MED_AGENDAMENTO_HORARIO = agendamento.MED_AGENDAMENTO_HORARIO;
            agendamentoExistente.MED_AGENDAMENTO_DATA = agendamento.MED_AGENDAMENTO_DATA;

            await _appDbContext.SaveChangesAsync();
            return Ok(agendamentoExistente);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarAgendamento(int id)
        {
            var agendamentoExistente = await _appDbContext.MED_AGENDAMENTO.FindAsync(id);
            if (agendamentoExistente == null)
            {
                return NotFound();
            }
            _appDbContext.MED_AGENDAMENTO.Remove(agendamentoExistente);
            await _appDbContext.SaveChangesAsync();
            return Ok(agendamentoExistente);
        }
    }
}
