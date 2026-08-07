using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace ProjetoCrud.Models
{
    public class TAB_FERIADO_TIPOS
    {
        [Key]
        public int ID_TAB_FERIADO_TIPO { get; set; } //PRIMARY KEY
        public string TAB_FERIADO_TIPO_DESCRICAO { get; set; }
        public string TAB_FERIADO_TIPO_OCULTA { get; set; }
    }
}