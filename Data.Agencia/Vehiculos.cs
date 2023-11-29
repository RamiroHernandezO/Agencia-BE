using Data.Agencia;

public partial class Vehiculo : EntityUtilites<int>
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Año { get; set; }
    public string Dueño { get; set; }
    public DateTime? ProximoServicio { get; set; }

    public virtual ICollection<Servicio> Servicios { get; set; }

    public Vehiculo()
    {
        Servicios = new HashSet<Servicio>();
    }
}