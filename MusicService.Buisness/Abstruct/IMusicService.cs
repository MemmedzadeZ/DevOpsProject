using MusicService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicService.Buisness.Abstruct
{
    public interface IMusicService
    {
        Task AddAsync(Music music);
        Task UpdateAsync(Music music);
        Task DeleteAsync(Music music);
        Task<List<Music>> GetAllAsync();
        Task<Music> GetByIdAsync(int id);

    }
}
