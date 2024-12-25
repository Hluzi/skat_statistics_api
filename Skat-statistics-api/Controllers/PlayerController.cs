using Skat_statistics_api.Services;
using Microsoft.AspNetCore.Mvc;
using Skat_statistics_api.Models;

namespace Skat_statistics_api.Controllers
{
    [ApiController]
    [Route("scalar/v1/[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly PlayerService _playerService;

        public PlayersController(PlayerService playerService)
        {
            _playerService = playerService;
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetPlayer(int id)
        //{
        //    var player = await _playerService.GetPlayerByIdAsync(id);
        //    if (player == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(player);
        //}

        [HttpPost("import")]
        public IActionResult ImportPlayers([FromBody] List<Player> players)
        {
            _playerService.ImportPlayers(players);
            return Ok(new { message = "Players imported successfully!" });
        }

    }
}
