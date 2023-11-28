using Data.Agencia;
using Pattern.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> save();

        IRepositoryWrite<Rol,int> Roles { get; }
        IRepositoryWrite<Entrega, int> Entregas { get; }
        IRepositoryWrite<Usuario, int> Usuarios { get; }
        IRepositoryWrite<Vehiculo, int> Vehiculos { get; }
        IRepositoryWrite<Refaccion, int> Refacciones { get; }
        IRepositoryWrite<Servicio, int> Servicios { get; }
        IRepositoryWrite<ServicioRefaccion, int> ServicioRefacciones { get; }






    }
}
