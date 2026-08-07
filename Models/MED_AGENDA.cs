using System.ComponentModel.DataAnnotations; 
using System.Security.AccessControl;

namespace ProjetoCrud.Models
{
    public class MED_AGENDA
    {
        [Key]
        public int ID_MED_AGENDASUPERKEY { get; set; }
        public int ID_MED_CRM { get; set; }
        public int ID_MED_TAB_AGENDA_PERIODO { get; set; }
        public string MED_AGENDA_DIA_SEMANA { get; set; }
        public TimeSpan MED_AGENDA_HORA_INICIAL { get; set; }
        public TimeSpan MED_AGENDA_HORA_FINAL { get; set; }
        public int MED_AGENDA_QTDE_MAXIMA { get; set; }
        public TimeSpan MED_AGENDA_TEMPO_CONSULTA { get; set; }
    }
}