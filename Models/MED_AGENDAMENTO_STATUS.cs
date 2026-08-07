using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace ProjetoCrud.Models
{
    public class MED_AGENDAMENTO_STATUS
    {
        [Key]
        public int ID_MED_AGENDAMENTO_STATUS { get; set; }
        public string MED_AGENDAMENTO_STATUS_DESCRICAO { get; set; }
        public string MED_AGENDAMENTO_STATUS_OCULTA { get; set; }
    }
}