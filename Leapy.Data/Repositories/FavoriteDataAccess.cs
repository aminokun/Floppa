using MySql.Data.MySqlClient;
using Leapy.Data.DataModels;

namespace Leapy.Data.Repositories
{
    public class FavoriteDataAccess
    {
        string connectionString = "Server=192.168.178.27,3306;Database=Leapy;Uid=Scraper;Pwd=123Scraper21!;";


        public void AddFavoritePhone(int UserId, int ArtNr)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                using (var command = new MySqlCommand("INSERT INTO favorite_phones (UserID, ArtNr) VALUES (@userId, @artNr)", connection))
                {
                    command.Parameters.AddWithValue("@userId", UserId);
                    command.Parameters.AddWithValue("@artNr", ArtNr);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }


        public void RemoveFavoritePhone(int UserId, int ArtNr)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                using (var command = new MySqlCommand("DELETE FROM favorite_phones WHERE UserID = @userId AND ArtNr = @artNr", connection))
                {
                    command.Parameters.AddWithValue("@userId", UserId);
                    command.Parameters.AddWithValue("@artNr", ArtNr);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
