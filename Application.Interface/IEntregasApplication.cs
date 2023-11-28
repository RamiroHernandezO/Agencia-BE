using Data.Agencia;
using Data.AgenciaDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transversal.Common;

namespace Application.Interface
{
    public interface IEntregaApplication
    {
        Task<Response<int>> Insert(EntregaDTO rolesDTO);
        Task<Response<int>> Update(EntregaDTO rolesDTO);
        Task<Response<bool>> Delete(int id);
        Task<Response<EntregaDTO>> Get(int id);
        Task<Response<List<EntregaDTO>>> GetAll();
    }
}
