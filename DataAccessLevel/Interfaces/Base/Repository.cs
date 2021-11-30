using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccessLevel.Interfaces.Base
{
    public interface Repository<T,E>
    {
        public Task<T> FindByIdAsync(E id);
        public Task<IEnumerable<T>> FindAllAsync();
        public Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);
        public Task<T> CreateAsync(T entity);

        public bool Update(T entity);
        public bool Delete(E id);
    }
}
