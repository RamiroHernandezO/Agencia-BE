using Data.AgenciaDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transversal.Common;

namespace Application.Interface
{
    public interface IServicioApplication
    {
        Task<Response<int>> Insert(ServicioDTO servicioDTO);
        Task<Response<int>> Update(ServicioDTO servicioDTO);
        Task<Response<bool>> Delete(int id);
        Task<Response<ServicioDTO>> Get(int id);
        Task<Response<List<ServicioDTO>>> GetAll();
    }
}
