using Data.Agencia;
namespace Data.AgenciaDTO
{
    public partial class UsuarioDTO : EntityUtilites<int>
    {
        public string Users { get; set; }
        public string Contraseña { get; set; }
        public string Email { get; set; }
        public int RolID { get; set; }
    }
}