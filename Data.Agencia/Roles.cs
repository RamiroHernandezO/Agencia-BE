using Data.Agencia;

public partial class Rol : EntityUtilites<int>
{
    public string Nombre { get; set; }
    public virtual ICollection<Usuario> Usuarios { get; set; }

    public Rol()
    {
        Usuarios = new HashSet<Usuario>();
    }
}