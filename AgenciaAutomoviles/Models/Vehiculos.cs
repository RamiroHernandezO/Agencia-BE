namespace AgenciaAutomoviles.Models
{
    public partial class Vehiculos
    {
        public int VehiculoID { get; set; }
        public string Marca { get; set; }
        public int Año { get; set; }
        public string Dueño { get; set; }
        public DateTime ProximoServicio { get; set; }

        public virtual ICollection<Servicios> Servicios { get; set; } = new HashSet<Servicios>();
    }

}
