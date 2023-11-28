using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Agencia
{
    public partial class Entrega: EntityUtilites<int>
    {
        public int AdminID { get; set; }
        public DateTime FechaEntrega { get; set; }
        [ForeignKey("AdminID")]
        public virtual Usuario Usuario { get; set; }
    }
}
