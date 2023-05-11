using MySql.Data.MySqlClient;
using Leapy.Data.DataModels;
using System.Data;

namespace Leapy.Data.Repositories
{
    public class UserDataAccess
    {
        string connectionString = "Server=192.168.178.27,3306;Database=Users;Uid=Scraper;Pwd=123Scraper21!;";

        public User? GetById(int id)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            var sql = "SELECT * FROM users WHERE id = @id";
            var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new User
                {
                    Id = reader.GetInt32("id"),
                    Username = reader.GetString("username"),
                    Email = reader.GetString("email"),
                    Password = reader.GetString("password")
                };
            }

            return null;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            using var connection = new MySqlConnection(connectionString);
            await connection.OpenAsync();

            var sql = "SELECT * FROM Users WHERE email = @email";
            var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@email", email);

            using var reader = await cmd.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new User
                {
                    Id = reader.GetInt32("id"),
                    Username = reader.GetString("username"),
                    Email = reader.GetString("email"),
                    Password = reader.GetString("password")
                };
            }

            return null;
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            using var connection = new MySqlConnection(connectionString);
            await connection.OpenAsync();

            var sql = "SELECT * FROM Users WHERE username = @username";
            var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@username", username);

            using var reader = await cmd.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new User
                {
                    Id = reader.GetInt32("id"),
                    Username = reader.GetString("username"),
                    Email = reader.GetString("email"),
                    Password = reader.GetString("password")
                };
            }

            return null;
        }

        public async Task AddUserAsync(User user)
        {
            using var connection = new MySqlConnection(connectionString);
            await connection.OpenAsync();

            var sql = "INSERT INTO Users (username, email, password) VALUES (@username, @email, @password)";
            var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@username", user.Username);
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@password", user.Password);

            await cmd.ExecuteNonQueryAsync();

            user.Id = (int)cmd.LastInsertedId;
        }
    }

}
