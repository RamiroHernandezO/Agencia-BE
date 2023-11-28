using Data.Agencia;

public partial class Usuario : EntityUtilites<int>
{
    public string Users { get; set; }
    public string Contraseña { get; set; }
    public string Email { get; set; }
    public int RolID { get; set; }
    public virtual Rol Rol { get; set; }
    public virtual ICollection<Entrega> Entregas { get; set; }

    public Usuario()
    {
        Entregas = new HashSet<Entrega>();
    }
}