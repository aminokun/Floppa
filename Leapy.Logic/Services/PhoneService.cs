using Leapy.Data.Repositories;
using Leapy.Data.DataModels;

namespace Leapy.Logic.Services
{
    public class PhoneService
    {
        private readonly PhoneDataAccess _phoneDataAccess;

        public PhoneService()
        {
            _phoneDataAccess = new PhoneDataAccess();
        }

        public List<PhoneDTO> GetPhones()
        {
            List<PhoneDTO> phones = _phoneDataAccess.GetPhones();

            return phones;
        }
        public PhoneDTO GetPhoneByArtNr(int ArtNr)
        {
            return _phoneDataAccess.GetPhoneByArtNr(ArtNr);
        }
    }
}
