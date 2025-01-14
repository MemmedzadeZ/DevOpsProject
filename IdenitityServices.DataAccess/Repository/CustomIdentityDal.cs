using IdentityService.DataAccess.Data;
using IdentityService.Entitiess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.DataAccess.Repository
{
    public class CustomIdentityDal : ICustomIdentityDal
    {

        private readonly MusicAppDbContext _context;
        public CustomIdentityDal(MusicAppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CustomIdentityUser user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(CustomIdentityUser user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CustomIdentityUser>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task UpdateAsync(CustomIdentityUser user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
