using IdentityService.Entitiess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.DataAccess.Repository
{
    public interface ICustomIdentityDal
    {

        Task AddAsync(CustomIdentityUser user);
        Task UpdateAsync(CustomIdentityUser user);
        Task DeleteAsync(CustomIdentityUser user);

        Task<List<CustomIdentityUser>> GetAllAsync();
    }
}
