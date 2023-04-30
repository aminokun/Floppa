using MySql.Data.MySqlClient;
using Leapy.Data.DataModels;

namespace Leapy.Data.Repositories
{
    public class UserDataAccess
    {

        string connectionString = "Server=192.168.178.27,3306;Database=Books;Uid=Scraper;Pwd=123Scraper21!;";

        public async Task CreateUserAsync(User user)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Users (Username, Password, Email) VALUES (@Username, @Password, @Email)";
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Email", user.Email);
                await command.ExecuteNonQueryAsync();
            }
        }

        public User? GetUserByUsername(string username)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Users WHERE Username = @Username";
                command.Parameters.AddWithValue("@Username", username);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new User
                    {
                        Id = reader.GetInt32("Id"),
                        Username = reader.GetString("Username"),
                        Password = reader.GetString("Password"),
                        Email = reader.GetString("Email")
                    };
                }
                return null;
            }
        }
    }
}
