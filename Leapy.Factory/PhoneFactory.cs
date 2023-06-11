using Leapy.Data.Repositories;
using Leapy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                default:
                    throw new Exception("Invalid data type");
            }
        }
    }
}
