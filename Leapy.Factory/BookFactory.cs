using Leapy.Data.Repositories;
using Leapy.Interfaces;

namespace Leapy.Factory
{
    public class BookFactory
    {
        public IBook UseBookDAL(string dataType)
        {
            switch (dataType)
            {
                case "Book":
                    return new BookDataAccess();
                default:
                    throw new Exception("Invalid DataType");
            }
        }
    }
}
