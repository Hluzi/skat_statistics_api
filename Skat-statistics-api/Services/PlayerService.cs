using Skat_statistics_api.Models;   
namespace Skat_statistics_api.Services
{
    public class PlayerService
    {
        private readonly DatabaseService _databaseService;

        public PlayerService(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public void ImportPlayers(IEnumerable<Player> players)
        {
            _databaseService.AddPlayers(players);
        }

        //public async Task<Player> GetPlayerByIdAsync(int id)
        //{
        //    return await _context.Players.FindAsync(id);
        //}
    }
}
