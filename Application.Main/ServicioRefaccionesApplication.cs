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
    public class ServicioRefaccionApplication : IServicioRefaccionApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<ServicioRefaccionApplication> _logger;
        public ServicioRefaccionApplication(IUnitOfWork unitOfWork, IMapper mapper, IAppLogger<ServicioRefaccionApplication> logger)
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
        public async Task<Response<List<ServicioRefaccionDTO>>> GetAll()
        {
            return await Execute(async () =>
            {
                var model = await _unitOfWork.ServicioRefacciones.GetAll();
                return _mapper.Map<List<ServicioRefaccionDTO>>(model.ToList());
            });
        }

        public async Task<Response<ServicioRefaccionDTO>> Get(int id)
        {
            return await Execute(async () =>
            {
                var model = await _unitOfWork.ServicioRefacciones.Get(id);
                return _mapper.Map<ServicioRefaccionDTO>(model);
            });
        }

        public async Task<Response<int>> Insert(ServicioRefaccionDTO servicioRefaccionDTO)
        {
            return await Execute(async () =>
            {
                var entity = _mapper.Map<ServicioRefaccion>(servicioRefaccionDTO);
                var result = await _unitOfWork.ServicioRefacciones.Insert(entity);
                await _unitOfWork.save();
                return result.Id;
            });
        }

        public async Task<Response<int>> Update(ServicioRefaccionDTO servicioRefaccionDTO)
        {
            return await Execute(async () =>
            {
                var entity = _mapper.Map<ServicioRefaccion>(servicioRefaccionDTO);
                _unitOfWork.ServicioRefacciones.Update(entity);
                await _unitOfWork.save();
                return entity.Id;
            });
        }

        public async Task<Response<bool>> Delete(int id)
        {
            return await Execute(async () =>
            {
                return await _unitOfWork.ServicioRefacciones.Delete(id);
            });
        }
    }
}