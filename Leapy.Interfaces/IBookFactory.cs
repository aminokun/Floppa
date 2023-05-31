using Leapy.DTO.DataModels;
using Leapy.Models;

namespace Leapy.Interfaces
{
    public interface IBookFactory
    {
        Book CreateBook(BookDTO bookDTO);
    }
}
