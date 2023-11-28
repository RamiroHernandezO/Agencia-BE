using Application.Interface;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.AgenciaDTO;
using Data.Agencia;
using Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transversal.Common;

namespace Application.Main
{
    public class RefaccionApplication : IRefaccionApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<RefaccionApplication> _logger;
        public RefaccionApplication(IUnitOfWork unitOfWork, IMapper mapper, IAppLogger<RefaccionApplication> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        private async Task<Response<T>> Execute<T>(Func<Task<T>> action)
        {
            var response = new Response<T>();
            try
            {
                var result = await action();
                response.Success = true;
                response.Data = result;
                response.Message = "Consulta Exitosa";
                _logger.LogInformation("Consulta Exitosa");
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(message: e.StackTrace);
                _logger.LogError(e.Message);
                _logger.LogError(message: e.InnerException.ToString());
            }

            return response;
        }
        public async Task<Response<List<RefaccionDTO>>> GetAll()
        {
            return await Execute(async () =>
            {
                var model = await _unitOfWork.Refacciones.GetAll();
                return _mapper.Map<List<RefaccionDTO>>(model.ToList());
            });
        }

        public async Task<Response<RefaccionDTO>> Get(int id)
        {
            return await Execute(async () =>
            {
                var model = await _unitOfWork.Refacciones.Get(id);
                return _mapper.Map<RefaccionDTO>(model);
            });
        }

        public async Task<Response<int>> Insert(RefaccionDTO refaccionDTO)
        {
            return await Execute(async () =>
            {
                var entity = _mapper.Map<Refaccion>(refaccionDTO);
                var result = await _unitOfWork.Refacciones.Insert(entity);
                await _unitOfWork.save();
                return result.Id;
            });
        }

        public async Task<Response<int>> Update(RefaccionDTO refaccionDTO)
        {
            return await Execute(async () =>
            {
                var entity = _mapper.Map<Refaccion>(refaccionDTO);
                _unitOfWork.Refacciones.Update(entity);
                await _unitOfWork.save();
                return entity.Id;
            });
        }

        public async Task<Response<bool>> Delete(int id)
        {
            return await Execute(async () =>
            {
                return await _unitOfWork.Refacciones.Delete(id);
            });
        }
    }
}