using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace ProjetoCrud.Models
{
    public class MED_TAB_AGENDA_PERIODO
    {
        [Key]
        public int ID_MED_TAB_AGENDA_PERIODO { get; set; }
        public string MED_TAB_AGENDA_PERIODO_DESCRICAO { get; set; }
        public bool MED_TAB_AGENDA_PERIODO_OCULTA { get; set; }
    }
}