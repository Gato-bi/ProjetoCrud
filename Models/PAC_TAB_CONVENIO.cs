using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace ProjetoCrud.Models
{
    public class PAC_TAB_CONVENIO
    {
        [Key]
        public int ID_PAC_TAB_CONVENIO { get; set; }
        public string PAC_TAB_CONVENIO_DESCRICAO { get; set; }
        public bool PAC_TAB_CONVENIO_OCULTA { get; set; }
        public int ID_PAC_TAB_CONVENIO_STATUS { get; set; }
    }
}