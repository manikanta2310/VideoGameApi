﻿using Microsoft.AspNetCore.Http;
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
    }
}
