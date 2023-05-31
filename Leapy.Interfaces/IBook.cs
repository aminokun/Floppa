using Leapy.DTO.DataModels;

namespace Leapy.Interfaces
{
    public interface IBook
    {
        List<BookDTO> GetBooks();
        BookDTO GetBookByUPC(string upc);
        List<BookDTO> GetFavoriteBooks(int userId);

    }
}
