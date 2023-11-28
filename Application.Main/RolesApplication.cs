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
    public class RolesApplication : IRolesApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<RolesApplication> _logger;
        public RolesApplication(IUnitOfWork unitOfWork, IMapper mapper, IAppLogger<RolesApplication> logger)
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
        public async Task<Response<List<RolesDTO>>> GetAll()
        {
            return await Execute(async () =>
            {
                var model = await _unitOfWork.Roles.GetAll();
                return _mapper.Map<List<RolesDTO>>(model.ToList());
            });
        }

        public async Task<Response<RolesDTO>> Get(int id)
        {
            return await Execute(async () =>
            {
                var model = await _unitOfWork.Roles.Get(id);
                return _mapper.Map<RolesDTO>(model);
            });
        }

        public async Task<Response<int>> Insert(RolesDTO rolDTO)
        {
            return await Execute(async () =>
            {
                var entity = _mapper.Map<Rol>(rolDTO);
                var result = await _unitOfWork.Roles.Insert(entity);
                await _unitOfWork.save();
                return result.Id;
            });
        }

        public async Task<Response<int>> Update(RolesDTO rolDTO)
        {
            return await Execute(async () =>
            {
                var entity = _mapper.Map<Rol>(rolDTO);
                _unitOfWork.Roles.Update(entity);
                await _unitOfWork.save();
                return entity.Id;
            });
        }

        public async Task<Response<bool>> Delete(int id)
        {
            return await Execute(async () =>
            {
                return await _unitOfWork.Roles.Delete(id);
            });
        }
    }
}