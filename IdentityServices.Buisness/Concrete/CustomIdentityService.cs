using IdentityService.Buisness.Abstruct;
using IdentityService.DataAccess.Repository;
using IdentityService.Entitiess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Buisness.Concrete
{
    public class CustomIdentityService : ICustomIdentityService
    {
        private readonly ICustomIdentityDal _customIdentityDal;
        public CustomIdentityService(ICustomIdentityDal customIdentityDal)
        {
            _customIdentityDal = customIdentityDal;
        }
        public async Task AddAsync(CustomIdentityUser user)
        {
            await _customIdentityDal.AddAsync(user);
        }
        public async Task DeleteAsync(CustomIdentityUser user)
        {
            await _customIdentityDal.DeleteAsync(user);
        }
        public async Task<List<CustomIdentityUser>> GetAllAsync()
        {
            return await _customIdentityDal.GetAllAsync();
        }
        //public async Task<CustomIdentityUser> GetByIdAsync(string id)
        //{
        //    return await _customIdentityDal.GetByIdAsync(id);
        //}
        //public async Task<CustomIdentityUser> GetByUserNameAsync(string name)
        //{
        //    return await _customIdentityDal.GetByUserNameAsync(name);
        //}
        public async Task UpdateAsync(CustomIdentityUser user)
        {
            await _customIdentityDal.UpdateAsync(user);
        }
    }
}
