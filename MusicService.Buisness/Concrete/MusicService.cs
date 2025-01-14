using MusicService.Buisness.Abstruct;
using MusicService.DataAccess.Repository;
using MusicService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicService.Buisness.Concrete
{
    public class MusicService : IMusicService
    {
        private readonly IMusicDal _musicDal;
        public MusicService(IMusicDal musicDal)
        {
            _musicDal = musicDal;
        }
        public async Task AddAsync(Music music)
        {
            await _musicDal.AddAsync(music);
        }
        public async Task DeleteAsync(Music music)
        {
            await _musicDal.DeleteAsync(music);
        }
        public async Task<List<Music>> GetAllAsync()
        {
            return await _musicDal.GetAllAsync();
        }
        public async Task<Music> GetByIdAsync(int id)
        {
            return await _musicDal.GetByIdAsync(id);
        }
        public async Task UpdateAsync(Music music)
        {
            await _musicDal.UpdateAsync(music);
        }
    }
}
