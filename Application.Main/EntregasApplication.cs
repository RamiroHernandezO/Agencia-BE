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
    public class EntregaApplication : IEntregaApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<EntregaApplication> _logger;
        public EntregaApplication(IUnitOfWork unitOfWork, IMapper mapper, IAppLogger<EntregaApplication> logger)
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
        public async Task<Response<List<EntregaDTO>>> GetAll()
        {
            return await Execute(async () =>
            {
                var model = await _unitOfWork.Entregas.GetAll();
                return _mapper.Map<List<EntregaDTO>>(model.ToList());
            });
        }

        public async Task<Response<EntregaDTO>> Get(int id)
        {
            return await Execute(async () =>
            {
                var model = await _unitOfWork.Entregas.Get(id);
                return _mapper.Map<EntregaDTO>(model);
            });
        }

        public async Task<Response<int>> Insert(EntregaDTO entregaDTO)
        {
            return await Execute(async () =>
            {
                var entity = _mapper.Map<Entrega>(entregaDTO);
                var result = await _unitOfWork.Entregas.Insert(entity);
                await _unitOfWork.save();
                return result.Id;
            });
        }

        public async Task<Response<int>> Update(EntregaDTO entregaDTO)
        {
            return await Execute(async () =>
            {
                var entity = _mapper.Map<Entrega>(entregaDTO);
                _unitOfWork.Entregas.Update(entity);
                await _unitOfWork.save();
                return entity.Id;
            });
        }

        public async Task<Response<bool>> Delete(int id)
        {
            return await Execute(async () =>
            {
                return await _unitOfWork.Entregas.Delete(id);
            });
        }
    }
}