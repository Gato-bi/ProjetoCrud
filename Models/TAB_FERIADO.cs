using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;


namespace ProjetoCrud.Models
{
    public class TAB_FERIADO
    {
        [Key]
        public int ID_TAB_FERIADO_DATANUMERO { get; set; } //PRIMARY KEY
        public string TAB_FERIADO_DATA { get; set; }
        public int ID_TAB_FERIADO_TIPO {get; set;}
        public string TAB_FERIADO_FIXO {get; set;}
        public string TAB_FERIADO_OCULTA {get; set;}    
    }
}