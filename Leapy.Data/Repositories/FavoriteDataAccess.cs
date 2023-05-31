using MySql.Data.MySqlClient;
using Leapy.DTO.DataModels;
using Leapy.Interfaces;

namespace Leapy.Data.Repositories
{
    public class FavoriteDataAccess : IFavorite
    {
        string connectionString = "Server=192.168.178.27,3306;Database=Leapy;Uid=Scraper;Pwd=123Scraper21!;";

        public void AddFavoritePhone(UserDTO user, PhoneDTO phone)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                using (var command = new MySqlCommand("INSERT INTO favorite_phones (UserID, ArtNr) VALUES (@userId, @artNr)", connection))
                {
                    command.Parameters.AddWithValue("@userId", user.UserID);
                    command.Parameters.AddWithValue("@artNr", phone.ArtNr);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void RemoveFavoritePhone(UserDTO user, PhoneDTO phone)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                using (var command = new MySqlCommand("DELETE FROM favorite_phones WHERE UserID = @userId AND ArtNr = @artNr", connection))
                {
                    command.Parameters.AddWithValue("@userId", user.UserID);
                    command.Parameters.AddWithValue("@artNr", phone.ArtNr);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
