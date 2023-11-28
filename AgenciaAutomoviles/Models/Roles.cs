namespace AgenciaAutomoviles.Models
{
    public partial class Roles
    {
        public int RolId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; } = new HashSet<Usuario>();
    }

}
