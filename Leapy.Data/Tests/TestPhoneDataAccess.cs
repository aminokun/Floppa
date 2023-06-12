using Leapy.DTO.DataModels;
using Leapy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leapy.Data.Tests
{
    public class TestPhoneDataAccess : IPhone
    {
        private List<PhoneDTO> _phones;

        public TestPhoneDataAccess()
        {
            _phones = new List<PhoneDTO>
            {
                new PhoneDTO { ArtNr = 1, ImageUrl = "test.jpg", Price = 100, Title = "Phone1" },
                new PhoneDTO { ArtNr = 2, ImageUrl = "test.jpg", Price = 200, Title = "Phone2" },
                new PhoneDTO { ArtNr = 3, ImageUrl = "test.jpg", Price = 140, Title = "Phone3" },
                new PhoneDTO { ArtNr = 4, ImageUrl = "test.jpg", Price = 230, Title = "Phone4" },
                new PhoneDTO { ArtNr = 5, ImageUrl = "test.jpg", Price = 300, Title = "Phone5" },
                new PhoneDTO { ArtNr = 6, ImageUrl = "test.jpg", Price = 450, Title = "Phone6" },
            };
        }

        public List<PhoneDTO> GetPhones()
        {
            return _phones;
        }

        public PhoneDTO GetPhoneByArtNr(int ArtNr)
        {
            return _phones.FirstOrDefault(p => p.ArtNr == ArtNr);
        }

        public List<PhoneDTO> GetFavoritePhones(int userId)
        {
            return _phones;
        }
    }

}
