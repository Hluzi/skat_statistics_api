using Microsoft.EntityFrameworkCore;
using Skat_statistics_api.Models;   
namespace Skat_statistics_api.Services
{
    public class PlayerService
    {
        private readonly SkatStatisticsContext _context;

        public PlayerService(SkatStatisticsContext context)
        {
            _context = context;
        }

        public async Task<List<Player>> AddPlayersAsync(List<Player> players)
        {
            _context.Players.AddRange(players);
            await _context.SaveChangesAsync();
            return players;
        }

        public async Task<Player> GetPlayerByIdAsync(int id)
        {
            return await _context.Players.FindAsync(id);
        }

        public async Task<List<Player>> GetPlayersAsync()
        {
            return await _context.Players.ToListAsync();
        }

        public async Task<Player> DeletePlayerAsync(int id)
        { 
            var player = await GetPlayerByIdAsync(id);
            if (player != null)
            {
                _context.Players.Remove(player);
                await _context.SaveChangesAsync();
            }
            return player;
        }
    }
}
