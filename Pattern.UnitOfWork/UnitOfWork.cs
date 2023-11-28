using Data.Agencia;
using Pattern.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AgenciaContext _context;
        public IRepositoryWrite<Rol, int> _rol;
        public IRepositoryWrite<Entrega, int> _entrega;
        public IRepositoryWrite<Usuario, int> _usuario;
        public IRepositoryWrite<Vehiculo, int> _vehiculo;
        public IRepositoryWrite<Refaccion, int> _refaccion;
        public IRepositoryWrite<Servicio, int> _servicio;
        public IRepositoryWrite<ServicioRefaccion, int> _serviciorefacciones; 


        public UnitOfWork(AgenciaContext context)
        {
            _context = context;
        }

        public IRepositoryWrite<Rol , int> Roles => _rol ?? (_rol = new Repository<Rol, int>(_context));
        public IRepositoryWrite<Entrega, int> Entregas => _entrega ?? (_entrega = new Repository<Entrega, int>(_context));
        public IRepositoryWrite<Usuario, int> Usuarios => _usuario ?? (_usuario = new Repository<Usuario, int>(_context));
        public IRepositoryWrite<Vehiculo, int> Vehiculos => _vehiculo ?? (_vehiculo = new Repository<Vehiculo, int>(_context));
        public IRepositoryWrite<Refaccion, int> Refacciones => _refaccion ?? (_refaccion = new Repository<Refaccion, int>(_context));
        public IRepositoryWrite<Servicio, int> Servicios => _servicio ?? (_servicio = new Repository<Servicio, int>(_context));
        public IRepositoryWrite<ServicioRefaccion, int> ServicioRefacciones => _serviciorefacciones ?? (_serviciorefacciones = new Repository<ServicioRefaccion, int>(_context));
        public void Dispose() 
        {
            _context.Dispose();
        }
        public async Task<int> save() => await _context.SaveChangesAsync();
    }
}
