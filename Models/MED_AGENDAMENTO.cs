using System.ComponentModel.DataAnnotations; 
using System.Security.AccessControl;
using System;


namespace ProjetoCrud.Models
{
    public class MED_AGENDAMENTO
    {
        [Key]
        public int ID_MED_AGENDAMENTO { get; set; }
        public int ID_PAC_RG_CIN { get; set; }
        public int ID_MED_TAB_AGENDA_PERIODO { get; set; }
        public int  ID_MED_CRM { get; set; }
        public TimeSpan MED_AGENDAMENTO_HORARIO { get; set; }
        public DateTime MED_AGENDAMENTO_DATA { get; set; }
        public int ID_MED_AGENDAMENTO_STATUS { get; set; }
    }
}