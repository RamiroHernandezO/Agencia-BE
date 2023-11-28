using Data.AgenciaDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transversal.Common;

namespace Application.Interface
{
    public interface IServicioRefaccionApplication
    {
        Task<Response<int>> Insert(ServicioRefaccionDTO servicioRefaccionDTO);
        Task<Response<int>> Update(ServicioRefaccionDTO servicioRefaccionDTO);
        Task<Response<bool>> Delete(int id);
        Task<Response<ServicioRefaccionDTO>> Get(int id);
        Task<Response<List<ServicioRefaccionDTO>>> GetAll();
    }
}
