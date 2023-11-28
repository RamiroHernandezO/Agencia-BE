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
    public class VehiculosApplication : IVehiculosApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<VehiculosApplication> _logger;
        public VehiculosApplication(IUnitOfWork unitOfWork, IMapper mapper, IAppLogger<VehiculosApplication> logger)
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
        public async Task<Response<List<VehiculoDTO>>> GetAll()
        {
            return await Execute(async () =>
            {
                var model = await _unitOfWork.Vehiculos.GetAll();
                return _mapper.Map<List<VehiculoDTO>>(model.ToList());
            });
        }

        public async Task<Response<VehiculoDTO>> Get(int id)
        {
            return await Execute(async () =>
            {
                var model = await _unitOfWork.Vehiculos.Get(id);
                return _mapper.Map<VehiculoDTO>(model);
            });
        }

        public async Task<Response<int>> Insert(VehiculoDTO vehiculoDTO)
        {
            return await Execute(async () =>
            {
                var entity = _mapper.Map<Vehiculo>(vehiculoDTO);
                var result = await _unitOfWork.Vehiculos.Insert(entity);
                await _unitOfWork.save();
                return result.Id;
            });
        }

        public async Task<Response<int>> Update(VehiculoDTO vehiculoDTO)
        {
            return await Execute(async () =>
            {
                var entity = _mapper.Map<Vehiculo>(vehiculoDTO);
                _unitOfWork.Vehiculos.Update(entity);
                await _unitOfWork.save();
                return entity.Id;
            });
        }

        public async Task<Response<bool>> Delete(int id)
        {
            return await Execute(async () =>
            {
                return await _unitOfWork.Vehiculos.Delete(id);
            });
        }
    }
}