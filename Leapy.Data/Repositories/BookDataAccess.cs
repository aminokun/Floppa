using MySql.Data.MySqlClient;
using Leapy.DTO.DataModels;
using Leapy.Interfaces;

namespace Leapy.Data.Repositories
{
    public class BookDataAccess : IBook
    {
        string connectionString = "Server=192.168.178.27,3306;Database=Leapy ;Uid=Scraper;Pwd=123Scraper21!;";
        
        public List<BookDTO> GetBooks()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string query = "SELECT * FROM books";
            MySqlCommand command = new MySqlCommand(query, connection);

            MySqlDataReader reader = command.ExecuteReader();

            var books = new List<BookDTO>();
            while (reader.Read())
            {
                BookDTO book = new BookDTO();
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

        public BookDTO GetBookByUPC(string upc)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string query = "SELECT * FROM books WHERE upc = @upc";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@upc", upc);

            MySqlDataReader reader = command.ExecuteReader();

            var book = new BookDTO();
            if (reader.Read())
            {
                book = new BookDTO();
                book.ImageUrl = reader["ImageUrl"].ToString();
                book.Title = reader["title"].ToString();
                book.Price = Convert.ToDecimal(reader["price"]);
                book.UPC = reader["UPC"].ToString();
            }

            reader.Close();
            connection.Close();

            return book;
        }
        public List<BookDTO> GetFavoriteBooks(int userId)
        {
            List<BookDTO> favoriteBooks = new List<BookDTO>();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new MySqlCommand("SELECT * FROM favorite_books WHERE UserID = @userId", connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string upc = reader["UPC"].ToString();

                            BookDTO book = GetBookByUPC(upc);
                            if (book != null)
                            {
                                favoriteBooks.Add(book);
                            }
                        }
                    }
                }
                connection.Close();
                return favoriteBooks;
            }
        }
    }
}
