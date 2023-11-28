using AutoMapper;
using Data.Agencia;
using Data.AgenciaDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transversal.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Entrega, EntregaDTO>().ReverseMap();
            CreateMap<Refaccion, RefaccionDTO>().ReverseMap();
            CreateMap<Rol, RolesDTO>().ReverseMap();
            CreateMap<ServicioRefaccion, ServicioRefaccionDTO>().ReverseMap();
            CreateMap<Servicio, ServicioDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Vehiculo, VehiculoDTO>().ReverseMap();
        }
    }
}
