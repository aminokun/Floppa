using MySql.Data.MySqlClient;
using Leapy.DTO.DataModels;
using Leapy.Interfaces;

namespace Leapy.Data.Repositories
{
    public class PhoneDataAccess : IPhone
    {
        string connectionString = "Server=192.168.178.27,3306;Database=Leapy;Uid=Scraper;Pwd=123Scraper21!;";
            
        public List<PhoneDTO> GetPhones()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string query = "SELECT * FROM phones";
            MySqlCommand command = new MySqlCommand(query, connection);

            MySqlDataReader reader = command.ExecuteReader();

            var phones = new List<PhoneDTO>();
            while (reader.Read())
            {
                PhoneDTO phone = new PhoneDTO();
                phone.ImageUrl = reader["ImageUrl"].ToString();
                phone.Title = reader["title"].ToString();
                phone.Price = Convert.ToDecimal(reader["price"]);
                phone.ArtNr = Convert.ToInt32(reader["ArtNr"]);

                phones.Add(phone);
            }

            reader.Close();
            connection.Close();

            return phones;
        }

        public PhoneDTO GetPhoneByArtNr(int ArtNr)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string query = "SELECT * FROM phones WHERE ArtNr = @ArtNr";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@ArtNr", ArtNr);

            MySqlDataReader reader = command.ExecuteReader();

            PhoneDTO phone = null;

            if (reader.Read())
            {
                phone = new PhoneDTO();
                phone.ImageUrl = reader["ImageUrl"].ToString();
                phone.Title = reader["title"].ToString();
                phone.Price = Convert.ToDecimal(reader["price"]);
                phone.ArtNr = Convert.ToInt32(reader["ArtNr"]);
            }

            reader.Close();
            connection.Close();

            return phone;
        }


        public List<PhoneDTO> GetFavoritePhones(int userId)
        {
            List<PhoneDTO> favoritePhones = new List<PhoneDTO>();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new MySqlCommand("SELECT * FROM favorite_phones WHERE UserID = @userId", connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int artNr = Convert.ToInt32(reader["ArtNr"]);

                            PhoneDTO phone = GetPhoneByArtNr(artNr);
                            if (phone != null)
                            {
                                favoritePhones.Add(phone);
                            }
                        }
                    }
                }
                connection.Close();
                return favoritePhones;
            }
        }
    }
}
