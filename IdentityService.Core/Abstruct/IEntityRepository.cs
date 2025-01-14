using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Core.Abstruct
{
    public interface IEntityRepository<T> where T :class ,IEntitiy,new()
    {
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>>? filter = null);
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
