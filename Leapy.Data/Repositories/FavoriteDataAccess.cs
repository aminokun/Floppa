using MySql.Data.MySqlClient;
using Leapy.Data.DataModels;

namespace Leapy.Data.Repositories
{
    public class FavoriteDataAccess
    {
        string connectionString = "Server=192.168.178.27,3306;Database=Leapy;Uid=Scraper;Pwd=123Scraper21!;";

        public void AddFavoriteBook(int userId, string upc)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                using (var command = new MySqlCommand("INSERT INTO favorite_books (UserID, UPC) VALUES (@userId, @upc)", connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@upc", upc);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

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
                }
            }
        }

        public void RemoveFavoriteBook(int userId, string upc)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                using (var command = new MySqlCommand("DELETE FROM favorite_books WHERE UserID = @userId AND UPC = @upc", connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@upc", upc);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void RemoveFavoritePhone(int userId, int artNr)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                using (var command = new MySqlCommand("DELETE FROM favorite_phones WHERE UserID = @userId AND ArtNr = @artNr", connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@artNr", artNr);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }




    }
}
