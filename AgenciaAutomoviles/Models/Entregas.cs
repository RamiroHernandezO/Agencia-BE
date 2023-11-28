namespace AgenciaAutomoviles.Models
{
    public partial class Entregas
    {
        public int ServicioID { get; set; }
        public virtual Servicios Servicio { get; set; }

        public int AdminID { get; set; }
        public virtual Usuario Admin { get; set; }

        public DateTime FechaEntrega { get; set; }
    }


}
