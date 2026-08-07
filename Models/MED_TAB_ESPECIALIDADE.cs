using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace ProjetoCrud.Models
{
    public class MED_TAB_ESPECIALIDADE
    {
        [Key]
        public int ID_MED_TAB_ESPECIALIDADE { get; set; } //PRIMARY KEY
        public string MED_TAB_ESPECIALIDADE_DESCRICAO { get; set; }
        public bool MED_TAB_ESPECIALIDADE_OCULTA { get; set; }
    }
}