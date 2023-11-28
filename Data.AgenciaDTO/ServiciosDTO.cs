using Data.Agencia;
namespace Data.AgenciaDTO
{
    public partial class ServicioDTO : EntityUtilites<int>
    {
        public int VehiculoID { get; set; }
        public DateTime Fecha { get; set; }
        public string Estatus { get; set; }
        public string Folio { get; set; }
    }
}