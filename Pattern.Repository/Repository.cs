using Data.Agencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Pattern.Repository
{
    public class Repository<T, TId> : IRepositoryWrite<T, TId>
        where T : EntityUtilites<TId>
        where TId : IEquatable<TId>
    {
        private readonly AgenciaContext _context;
        protected DbSet<T> Entities => _context.Set<T>();
        public Repository(AgenciaContext context)
        {
            _context = context;
        }

        public async Task<T> Insert(T entity)
        {
            EntityEntry<T> entities = await Entities.AddAsync(entity);
            return entities.Entity;
        }

        public void Update(T entity)
        {
            Entities.Update(entity);
        }

        public async Task<bool> Delete(TId id)
        {
            var entity = await Entities.FindAsync(id);
            if (entity == null)
                return false;

            Entities.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<T> Get(TId id)
        {
            return await Entities.FirstOrDefaultAsync(r => r.Id.Equals(id));
        }
        public async Task<IQueryable<T>> GetAll(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Entities;

            if (includes != null)
            {
                
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }

            return query;
        }
      


    }
}