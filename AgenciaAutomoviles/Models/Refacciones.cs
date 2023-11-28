namespace AgenciaAutomoviles.Models
{
    public partial class Refacciones
    {
        public int RefaccionID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }

        public virtual ICollection<ServicioRefacciones> ServicioRefacciones { get; set; } = new HashSet<ServicioRefacciones>();
    }

}
