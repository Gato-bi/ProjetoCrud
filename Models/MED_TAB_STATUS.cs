using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;



namespace ProjetoCrud.Models
{
    public class MED_TAB_STATUS
    {
        [Key]
        public int ID_MED_TAB_STATUS { get; set; } // PRIMARY KEY
        public string MED_TAB_STATUS_DESCRICAO { get; set; }
        public bool MED_TAB_STATUS_OCULTA { get; set; }
    }
}