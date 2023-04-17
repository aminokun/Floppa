using MySql.Data.MySqlClient;
using Leapy.Data.DataModels;

namespace Leapy.Data.Repositories
{
    public class PhoneRepository
    {
        public List<Phone> GetPhones()
        {
            string connectionString = "Server=192.168.178.27,3306;Database=Phones;Uid=Scraper;Pwd=123Scraper21!;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string query = "SELECT * FROM phones";
            MySqlCommand command = new MySqlCommand(query, connection);

            MySqlDataReader reader = command.ExecuteReader();

            var phones = new List<Phone>();
            while (reader.Read())
            {
                Phone phone = new Phone();
                phone.ImageUrl = reader["ImageUrl"].ToString();
                phone.Title = reader["title"].ToString();
                phone.Price = Convert.ToDouble(reader["price"]);

                phones.Add(phone);
            }

            reader.Close();
            connection.Close();

            return phones;
        }
    }
}
