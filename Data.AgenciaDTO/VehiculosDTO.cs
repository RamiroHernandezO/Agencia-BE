using Data.Agencia;
namespace Data.AgenciaDTO
{
    public partial class VehiculoDTO : EntityUtilites<int>
    {
        public string Marca { get; set; }
        public int Año { get; set; }
        public string Dueño { get; set; }
        public DateTime? ProximoServicio { get; set; }

    }
}