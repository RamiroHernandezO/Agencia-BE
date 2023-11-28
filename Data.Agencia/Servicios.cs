using Data.Agencia;

public partial class Servicio : EntityUtilites<int>
{
    public int VehiculoID { get; set; }
    public DateTime Fecha { get; set; }
    public string Estatus { get; set; }
    public string Folio { get; set; }

   
    public virtual Vehiculo Vehiculo { get; set; }
    public virtual ICollection<ServicioRefaccion> ServicioRefacciones { get; set; }

    public Servicio()
    {
        ServicioRefacciones = new HashSet<ServicioRefaccion>();
    }
}