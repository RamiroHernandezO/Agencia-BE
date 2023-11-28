using Data.AgenciaDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transversal.Common;

namespace Application.Interface
{
    public interface IUsuariosApplication
    {
        Task<Response<int>> Insert(UsuarioDTO usuarioDTO);
        Task<Response<int>> Update(UsuarioDTO usuarioDTO);
        Task<Response<bool>> Delete(int id);
        Task<Response<UsuarioDTO>> Get(int id);
        Task<Response<List<UsuarioDTO>>> GetAll();
    }
}
