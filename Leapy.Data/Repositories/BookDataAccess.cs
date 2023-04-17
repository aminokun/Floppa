using MySql.Data.MySqlClient;
using Leapy.Data.DataModels;

namespace Leapy.Data.Repositories
{
    public class BookRepository
    {
        public List<Book> GetBooks()
        {
            string connectionString = "Server=192.168.178.27,3306;Database=Books;Uid=Scraper;Pwd=123Scraper21!;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string query = "SELECT * FROM books";
            MySqlCommand command = new MySqlCommand(query, connection);

            MySqlDataReader reader = command.ExecuteReader();

            var books = new List<Book>();
            while (reader.Read())
            {
                Book book = new Book();
                book.ImageUrl = reader["ImageUrl"].ToString();
                book.Title = reader["title"].ToString();
                book.Price = Convert.ToDecimal(reader["price"]);
                book.UPC = reader["upc"].ToString();

                books.Add(book);
            }

            reader.Close();
            connection.Close();

            return books;
        }
    }
}
