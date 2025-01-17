namespace MusicService.Web_API.Services.Abstruct
{
    public interface IRabbitMQService
    {

        Task AddMusicMessage(string musicId, string message);
        Task<List<string>> GetMusicMessage(string musicId);
    }
}
