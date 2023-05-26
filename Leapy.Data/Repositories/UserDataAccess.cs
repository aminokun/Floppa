using MySql.Data.MySqlClient;
using Leapy.Data.DataModels;
using System.Data;
using System.Threading.Tasks;

namespace Leapy.Data.Repositories
{
    public class UserDataAccess
    {
        string connectionString = "Server=192.168.178.27,3306;Database=Leapy;Uid=Scraper;Pwd=123Scraper21!;";

        public UserDTO? GetById(int id)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            var sql = "SELECT * FROM users WHERE UserID = @id";
            var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new UserDTO
                {
                    UserID = reader.GetInt32("UserID"),
                    Username = reader.GetString("username"),
                    Email = reader.GetString("email"),
                    Password = reader.GetString("password")
                };
            }

            return null;
        }

        public async Task<UserDTO?> GetUserByEmailAsync(string email)
        {
            using var connection = new MySqlConnection(connectionString);
            await connection.OpenAsync();

            var sql = "SELECT * FROM users WHERE email = @email";
            var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@email", email);

            using var reader = await cmd.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new UserDTO
                {
                    UserID = reader.GetInt32("UserID"),
                    Username = reader.GetString("username"),
                    Email = reader.GetString("email"),
                    Password = reader.GetString("password")
                };
            }

            return null;
        }

        public async Task<UserDTO?> GetUserByUsernameAsync(string username)
        {
            using var connection = new MySqlConnection(connectionString);
            await connection.OpenAsync();

            var sql = "SELECT * FROM users WHERE username = @username";
            var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@username", username);

            using var reader = await cmd.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new UserDTO
                {
                    UserID = reader.GetInt32("UserID"),
                    Username = reader.GetString("username"),
                    Email = reader.GetString("email"),
                    Password = reader.GetString("password")
                };
            }

            return null;
        }

        public async Task AddUserAsync(UserDTO user)
        {
            using var connection = new MySqlConnection(connectionString);
            await connection.OpenAsync();

            var sql = "INSERT INTO users (username, email, password) VALUES (@username, @email, @password)";
            var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@username", user.Username);
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@password", user.Password);

            await cmd.ExecuteNonQueryAsync();

            user.UserID = (int)cmd.LastInsertedId;
        }
    }
}
