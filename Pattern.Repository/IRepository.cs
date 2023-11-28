using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Repository
{
    public interface IRepositoryRead<T, TId>
    {
        Task<T> Get(TId id);
        Task<IQueryable<T>> GetAll(params Expression<Func<T, object>>[] include);
    }
    public interface IRepositoryWrite<T, TId> : IRepositoryRead<T, TId>
    {
        Task<T> Insert(T entity);
        void Update(T entity);
        Task<bool> Delete(TId id);
    }
}