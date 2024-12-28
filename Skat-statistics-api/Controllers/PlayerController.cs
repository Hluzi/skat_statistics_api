using Skat_statistics_api.Services;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayer(int id)
        {
            var player = await _playerService.GetPlayerByIdAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }
        [HttpGet]
        public async Task<IActionResult> GetPlayers()
        {
            var players = await _playerService.GetPlayersAsync();
            if (players == null)
            {
                return NotFound();
            }
            return Ok(players);
        }

        [HttpPost("Add")]
        public IActionResult Addplayers([FromBody] List<Player> players)
        {
            _playerService.AddPlayersAsync(players);
            return Ok(new { message = "Players imported successfully!" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            await _playerService.DeletePlayerAsync(id);
            return NoContent();
        }

    }
}
