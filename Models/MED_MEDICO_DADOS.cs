using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace ProjetoCrud.Models
{
    public class MED_MEDICO_DADOS
    {
        [Key]
        public int ID_MED_CRM { get; set; }
        public string MED_NOME_COMPLETO { get; set; }
        public string MED_SEXO { get; set; }
        public string MED_CPF { get; set; }
        public string MED_TELEFONE { get; set; }
        public string MED_ENDERECO { get; set; }
        public string MED_CEP { get; set; }
        public string MED_NUMERO { get; set; }
        public string MED_BAIRRO { get; set; }
        public string MED_CIDADE { get; set; }
        public string MED_UF { get; set; }
        public string MED_COMPLEMENTO { get; set; }
        public int ID_MED_TAB_ESPECIALIDADE { get; set; } //Foreign Key
        public int ID_MED_TAB_STATUS { get; set; } // Foreign key
    }
}