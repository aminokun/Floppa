using Leapy.DTO.DataModels;

namespace Leapy.Interfaces
{
    public interface IBook
    {
        List<BookDTO> GetBooks();
        BookDTO GetBookByUPC(string UPC);
        List<BookDTO> GetFavoriteBooks(int userId);

    }
}
