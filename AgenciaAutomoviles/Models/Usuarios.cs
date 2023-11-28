namespace AgenciaAutomoviles.Models
{
    public partial class Usuario
    {
        public int UsuarioID { get; set; }
        public string Users { get; set; }
        public string Contraseña { get; set; }
        public string Email { get; set; }
        public int RolID { get; set; }
        public virtual Roles Rol { get; set; }

        public virtual ICollection<Entregas> EntregasAdmin { get; set; } = new HashSet<Entregas>();
    }

}
