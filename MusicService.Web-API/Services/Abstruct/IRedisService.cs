using MusicService.Entities;

namespace MusicService.Web_API.Services.Abstruct
{
    public interface IRedisService
    {
        Task AddFavoriteAsync(string userId, Music music);
        void ChengeFavorite(string userId, int musicId);
        Task<List<Music>> GetFavouriteAsync(string userId);
        Task RemoveFavoriteAsync(string id, Music music);
    }
}
