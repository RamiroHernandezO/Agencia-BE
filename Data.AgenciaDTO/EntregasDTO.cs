using Data.Agencia;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.AgenciaDTO
{
    public partial class EntregaDTO: EntityUtilites<int>
    {
        public int AdminID { get; set; }
        public DateTime FechaEntrega { get; set; }
        [ForeignKey("AdminID")]
        public virtual Usuario Usuario { get; set; }
    }
}
