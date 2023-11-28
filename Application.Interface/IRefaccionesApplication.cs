using Data.AgenciaDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transversal.Common;

namespace Application.Interface
{
    public interface IRefaccionApplication
    {
        Task<Response<int>> Insert(RefaccionDTO refaccionDTO);
        Task<Response<int>> Update(RefaccionDTO refaccionDTO);
        Task<Response<bool>> Delete(int id);
        Task<Response<RefaccionDTO>> Get(int id);
        Task<Response<List<RefaccionDTO>>> GetAll();
    }
}
