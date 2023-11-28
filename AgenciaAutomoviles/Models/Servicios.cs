namespace AgenciaAutomoviles.Models
{
    public partial class Servicios
    {
        public int ServicioID { get; set; }
        public int VehiculoID { get; set; }
        public virtual Vehiculos Vehiculo { get; set; }

        public DateTime Fecha { get; set; }
        public string Estatus { get; set; }
        public string Folio { get; set; }

        public virtual ICollection<ServicioRefacciones> ServicioRefacciones { get; set; } = new HashSet<ServicioRefacciones>();
        public virtual ICollection<Entregas> Entregas { get; set; } = new HashSet<Entregas>();
    }

}
