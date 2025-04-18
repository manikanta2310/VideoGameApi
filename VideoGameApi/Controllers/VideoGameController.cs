using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGameApi.Models;

namespace VideoGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        // creating static list of video games for testing purposes 
        static private List<VideoGame> videoGames = new List<VideoGame>
        {
            new VideoGame { Id = 1, Title = "The Legend of Zelda: Breath of the Wild", Platform = "Nintendo Switch", Developer = "Nintendo", Publisher = "Nintendo", Genre = "Action-adventure" },
            new VideoGame { Id = 2, Title = "The Witcher 3: Wild Hunt", Platform = "PC, PS4, Xbox One, Nintendo Switch", Developer = "CD Projekt Red", Publisher = "CD Projekt", Genre = "Action role-playing" },
            new VideoGame { Id = 3, Title = "Minecraft", Platform = "PC, PS4, Xbox One, Nintendo Switch, Mobile", Developer = "Mojang Studios", Publisher = "Mojang Studios", Genre = "Sandbox" }
        };
        [HttpGet]
        public ActionResult<List<VideoGame>> GetVideoGames()
        {
            return Ok(videoGames);
        }
        [HttpGet("{id}")]
        public ActionResult<VideoGame> GetVideoGameById(int id)
        {
            var videogame = videoGames.FirstOrDefault(v => v.Id == id);
            if(videogame is null)
            {
                return NotFound();
            }
            return Ok(videogame);
        }

        [HttpPost]
        public ActionResult<VideoGame> AddVideoGame(VideoGame newGame)
        {
            if(newGame is null)
            
                return BadRequest();
                
                    newGame.Id = videoGames.Max(v => v.Id) + 1;
                videoGames.Add(newGame);
            return CreatedAtAction(nameof(GetVideoGameById), new { id = newGame.Id }, newGame);
        }
        [HttpPut("{id}")]
        public ActionResult<VideoGame> UpdateVideoGame(int id, VideoGame updatedGame)
        {
            var videogame = videoGames.FirstOrDefault(v => v.Id == id);
            if (videogame is null)
            {
                return NotFound();
            }
            videogame.Title = updatedGame.Title;
            videogame.Platform = updatedGame.Platform;
            videogame.Developer = updatedGame.Developer;
            videogame.Publisher = updatedGame.Publisher;
            videogame.Genre = updatedGame.Genre;
            return  NoContent();
        }
        [HttpDelete("{id}")]
        public  IActionResult DeleteVideoGame(int id)
        {
            var videogame = videoGames.FirstOrDefault(v => v.Id == id);
            if (videogame is null)
            {
                return NotFound();
            }
            videoGames.Remove(videogame);
            return NoContent();
        }

    }
}
