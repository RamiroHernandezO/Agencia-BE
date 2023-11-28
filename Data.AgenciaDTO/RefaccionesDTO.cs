using Data.Agencia;
namespace Data.AgenciaDTO
{
    public partial class RefaccionDTO : EntityUtilites<int>
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public decimal Precio { get; set; }
    }
}