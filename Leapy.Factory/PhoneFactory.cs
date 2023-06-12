using Leapy.Data.Repositories;
using Leapy.Data.Tests;
using Leapy.Interfaces;

namespace Leapy.Factory
{
    public class PhoneFactory
    {
        public IPhone UsePhoneDAL(string dataType)
        {
            switch (dataType)
            {
                case "Phone":
                    return new PhoneDataAccess();
                case "TestPhone":
                    return new TestPhoneDataAccess();
                default:
                    throw new Exception("Invalid data type");
            }
        }
    }
}
