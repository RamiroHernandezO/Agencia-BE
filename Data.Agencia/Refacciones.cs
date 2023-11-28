using Data.Agencia;

public partial class Refaccion : EntityUtilites<int>
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public decimal Precio { get; set; }
    public virtual ICollection<ServicioRefaccion> ServicioRefacciones { get; set; }

    public Refaccion()
    {
        ServicioRefacciones = new HashSet<ServicioRefaccion>();
    }
}