using Data.Agencia;

public partial class ServicioRefaccion : EntityUtilites<int>
{
    public int RefaccionID { get; set; }
    public int Cantidad { get; set; }
    public virtual Servicio Servicio { get; set; }
    public virtual Refaccion Refaccion { get; set; }
}