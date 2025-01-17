using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicService.Entities;
using MusicService.Web_API.Services.Abstruct;

namespace MusicService.Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {

        private readonly IRedisService _redisService;
        private readonly IRabbitMQService _rabbitmqService;

        public MusicController(IRedisService redisService, IRabbitMQService rabbitmqService)
        {
            _redisService = redisService;
            _rabbitmqService = rabbitmqService;
        }

        [HttpPost("addMusic")]

        public async Task<IActionResult> AddMusic(string id, Music music)
        {
            if(music != null)
            {
                await _redisService.AddFavoriteAsync(id, music);
                return Ok("Music added to favorites.");
            }
            else
            {
                return BadRequest("Music is null.");
            }

        }

        [HttpPost("removeMusic")]
        public async Task<IActionResult> RemoveMusic(string id, Music music)
        {

            if( music != null)
            {
                await _redisService.RemoveFavoriteAsync(id, music);
                return Ok("Music removed from favorites.");

            //_redisService.ChengeFavorite(id, musicId);
            //return Task.FromResult<IActionResult>(Ok("Music removed from favorites."));

            }
            else
            {
                return BadRequest("Music is null.");
            }
        }

        [HttpGet("allMusic")]

        public async Task<IActionResult> GetAllMusic(string id)
        {
            var musicList = await _redisService.GetFavouriteAsync(id);
            return Ok(musicList);
        }

        [HttpPost("addMessage")]
        public async Task<IActionResult> AddMessage(string musicId, string message)
        {
            await _rabbitmqService.AddMusicMessage(musicId, message);
            return Ok("Message added to queue.");
        }

        [HttpGet("getMessage")]
        public async void GetMessage(string musicId)
        {
            var messageList = await _rabbitmqService.GetMusicMessage(musicId);
            foreach (var message in messageList)
            {
                Console.WriteLine(message);
            }
        }
    }
}
