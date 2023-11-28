using Data.AgenciaDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transversal.Common;

namespace Application.Interface
{
    public interface IRolesApplication
    {
        Task<Response<int>> Insert(RolesDTO rolesDTO);
        Task<Response<int>> Update(RolesDTO rolesDTO);
        Task<Response<bool>> Delete(int id);
        Task<Response<RolesDTO>> Get(int id);
        Task<Response<List<RolesDTO>>> GetAll();
    }
}
