using Leapy.DTO.DataModels;
using Leapy.Interfaces;
using Leapy.Models;

namespace Leapy.Factory
{
    public class BookFactory : IBookFactory
    {
        public Book CreateBook(BookDTO bookDTO)
        {
            return new Book
            {
                UPC = bookDTO.UPC,
                ImageUrl = bookDTO.ImageUrl,
                Title = bookDTO.Title,
                Price = bookDTO.Price,
                IsFavorite = bookDTO.IsFavorite
            };
        }
    }
}
