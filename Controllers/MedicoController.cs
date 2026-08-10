using System;
using Microsoft.AspNetCore.Mvc;
using ProjetoCrud.Data;
using ProjetoCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetoCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicoController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public MedicoController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarMedico(MED_MEDICO_DADOS medico)
        {
            _appDbContext.MED_MEDICO_DADOS.Add(medico);
            await _appDbContext.SaveChangesAsync();

            return Ok(medico);
        }
        // Endpoint GET api/Medico: retorna a lista de todos os médicos cadastrados.
        [HttpGet]
        public async Task<IActionResult> ObterMedicos()
        {
            // Faz um JOIN entre médicos e especialidades para trazer a descrição
            // da especialidade (e não apenas o ID) junto com os dados do médico.
            var medicos = await (
                from med in _appDbContext.MED_MEDICO_DADOS
                join esp in _appDbContext.MED_TAB_ESPECIALIDADE on med.ID_MED_TAB_ESPECIALIDADE equals esp.ID_MED_TAB_ESPECIALIDADE
                // Projeta apenas os campos necessários em um objeto anônimo,
                // evitando retornar a entidade completa (e possíveis dados sensíveis/desnecessários).
                select new
                {
                    MedicoId = med.ID_MED_CRM,
                    Nome = med.MED_NOME_COMPLETO,
                    Especialidade = esp.MED_TAB_ESPECIALIDADE_DESCRICAO,
                    Sexo = med.MED_SEXO,
                    Telefone = med.MED_TELEFONE,
                    Endereco = med.MED_ENDERECO,
                    Cep = med.MED_CEP,
                }
            ).ToListAsync(); // Executa a consulta de forma assíncrona e materializa o resultado em uma lista.
            return Ok(medicos); // Retorna 200 OK com a lista de médicos.
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarMedico(int id, MED_MEDICO_DADOS medico)
        {
            var medicoExistente = await _appDbContext.MED_MEDICO_DADOS.FindAsync(id);
            if (medicoExistente == null)
            {
                return NotFound();
            }
            medicoExistente.ID_MED_CRM = medico.ID_MED_CRM;
            medicoExistente.MED_NOME_COMPLETO  = medico.MED_NOME_COMPLETO;
            medicoExistente.MED_SEXO = medico.MED_SEXO;
            medicoExistente.MED_TELEFONE = medico.MED_TELEFONE;
            medicoExistente.MED_ENDERECO = medico.MED_ENDERECO;
            medicoExistente.MED_CEP = medico.MED_CEP;
            medicoExistente.MED_NUMERO = medico.MED_NUMERO;
            medicoExistente.MED_BAIRRO = medico.MED_BAIRRO;
            medicoExistente.MED_CIDADE = medico.MED_CIDADE;
            medicoExistente.MED_UF = medico.MED_UF;
            medicoExistente.MED_COMPLEMENTO = medico.MED_COMPLEMENTO;
            medicoExistente.ID_MED_TAB_ESPECIALIDADE = medico.ID_MED_TAB_ESPECIALIDADE;
            medicoExistente.ID_MED_TAB_STATUS = medico.ID_MED_TAB_STATUS;

            await _appDbContext.SaveChangesAsync();
            return Ok(medicoExistente);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarMedico(int id)
        {
            var medicoExistente = await _appDbContext.MED_MEDICO_DADOS.FindAsync(id);
            if (medicoExistente == null)
            {
                return NotFound();
            }

            _appDbContext.MED_MEDICO_DADOS.Remove(medicoExistente);
            await _appDbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}