using Leapy.Data.Repositories;
using Leapy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leapy.Factory
{
    public class UserFactory
    {
        public IUser UseUserDAL(string dataType)
        {
            switch (dataType)
            {
                case "User":
                    return new UserDataAccess();
                default:
                    throw new Exception("Not a valid Data type");
            }
        }
    }
}
