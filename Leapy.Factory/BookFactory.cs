﻿using Leapy.Data.Repositories;
using Leapy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
