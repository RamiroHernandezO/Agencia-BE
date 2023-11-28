namespace AgenciaAutomoviles.Models
{
    public partial class ServicioRefacciones
    {
        public int ServicioID { get; set; }
        public virtual Servicios Servicio { get; set; }

        public int RefaccionID { get; set; }
        public virtual Refacciones Refaccion { get; set; }

        public int Cantidad { get; set; }
    }

}
