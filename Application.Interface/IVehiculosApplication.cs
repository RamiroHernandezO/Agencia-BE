using Data.AgenciaDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transversal.Common;

namespace Application.Interface
{
    public interface IVehiculosApplication
    {
        Task<Response<int>> Insert(VehiculoDTO vehiculoDTO);
        Task<Response<int>> Update(VehiculoDTO vehiculoDTO);
        Task<Response<bool>> Delete(int id);
        Task<Response<VehiculoDTO>> Get(int id);
        Task<Response<List<VehiculoDTO>>> GetAll();
    }
}
