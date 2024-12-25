//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Skat_statistics_api.Models;

namespace Skat_statistics_api.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public SqlConnection GetConnection()
        {
            Console.WriteLine(_connectionString);
            return new SqlConnection(_connectionString);
        }

        public void AddPlayers(IEnumerable<Player> players)
        {
            using var connection = GetConnection();
            connection.Open();
            foreach (var player in players)
            {
                string query = "INSERT INTO Players (ID, Name) VALUES (@ID, @Name)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", player.ID);
                    command.Parameters.AddWithValue("@Name", player.Name);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
