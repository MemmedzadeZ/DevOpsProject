using MusicService.Entities;
using MusicService.Web_API.Services.Abstruct;
using StackExchange.Redis;
using System.Text.Json;

namespace MusicService.Web_API.Services.Concrete
{
    public class RedisService : IRedisService
    {
        private readonly IConnectionMultiplexer _redis;
        private readonly IDatabase _database;

        public RedisService(IConnectionMultiplexer redis)
        {
            _redis = redis;
            _database = _redis.GetDatabase();

        }
    
        public async Task AddFavoriteAsync(string userId, Music music)
        {
            try
            {
                var key = $"favourites:{userId}";
                var value = JsonSerializer.Serialize(music);

              
                await _database.ListRightPushAsync(key, value);
               
            }
            catch (Exception ex)
            {
           
                Console.WriteLine($"Error adding audio to favourites: {ex.Message}");
         
            }
        }

        public void ChengeFavorite(string userId, int musicId)
        {
            string redisKey = $"user:{userId}:favorites";

            if (_database.SetContains(redisKey, musicId))
            {
                _database.SetRemove(redisKey, musicId);
            }
            else
            {
                _database.SetAdd(redisKey, musicId
                    );
            }
        }

        public async Task<List<Music>> GetFavouriteAsync(string userId)
        {
            try
            {
                var key = $"favourites:{userId}";
                var length = await _database.ListLengthAsync(key);
                var favouriteAudios = await _database.ListRangeAsync(key, 0, length - 1);

                return favouriteAudios
                    .Select(fav => JsonSerializer.Deserialize<Music>(fav))
                    .Where(audio => audio != null)
                    .ToList();
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"Error retrieving favourite audios: {ex.Message}");
                return new List<Music>(); // Return an empty list if error occurs
            }
        }
    }
}
