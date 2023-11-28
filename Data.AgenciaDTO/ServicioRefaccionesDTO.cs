using Data.Agencia;
namespace Data.AgenciaDTO
{
    public partial class ServicioRefaccionDTO : EntityUtilites<int>
    {
        public int RefaccionID { get; set; }
        public int Cantidad { get; set; }
    }
}
