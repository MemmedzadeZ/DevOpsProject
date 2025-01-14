using IdentityService.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using MusicService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicService.DataAccess.Repository
{
    public class MusicDal:IMusicDal
    {

        private readonly MusicAppDbContext _musicDbContext;
        public MusicDal(MusicAppDbContext musicDbContext)
        {
            
            _musicDbContext = musicDbContext;
        }
        public async Task AddAsync(Music music)
        {
            await _musicDbContext.Musics.AddAsync(music);
            await _musicDbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Music music)
        {
            _musicDbContext.Musics.Remove(music);
            await _musicDbContext.SaveChangesAsync();
        }
        public async Task<List<Music>> GetAllAsync()
        {
            return await _musicDbContext.Musics.ToListAsync();
        }
        public async Task<Music> GetByIdAsync(int id)
        {
            return await _musicDbContext.Musics.FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task UpdateAsync(Music music)
        {
            _musicDbContext.Musics.Update(music);
            await _musicDbContext.SaveChangesAsync();
        }
    }
}
