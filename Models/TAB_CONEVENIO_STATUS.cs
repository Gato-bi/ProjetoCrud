using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace ProjetoCrud.Models
{
    public class CONEVENIO_TAB_STATUS
    {
        [Key]
        public int ID_PAC_TAB_CONVENIO_STATUS { get; set; }
        public string  PAC_TAB_CONVENIO_STATUS_DESCRICAO { get; set; }
    }
}