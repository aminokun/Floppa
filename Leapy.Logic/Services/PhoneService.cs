using Leapy.DTO.DataModels;
using Leapy.Interfaces;
using Leapy.Models;

namespace Leapy.Logic.Services
{
    public class PhoneService
    {
        private readonly ISmartphone _phoneDataAccess;
        private readonly ISmartphoneFactory _phoneFactory;

        public PhoneService(ISmartphone phoneDataAccess, ISmartphoneFactory phoneFactory)
        {
            _phoneDataAccess = phoneDataAccess;
            _phoneFactory = phoneFactory;
        }

        public List<Phone> GetPhones()
        {
            List<PhoneDTO> phoneDTOs = _phoneDataAccess.GetPhones();

            var phones = phoneDTOs.Select(phoneDTO => _phoneFactory.CreatePhone(phoneDTO)).ToList();

            return phones;
        }

        public Phone GetPhoneByArtNr(int ArtNr)
        {
            PhoneDTO phoneDTO = _phoneDataAccess.GetPhoneByArtNr(ArtNr);

            return _phoneFactory.CreatePhone(phoneDTO);
        }

        public List<Phone> GetFavoritePhones(int userId)
        {
            var favoritePhonesDTO = _phoneDataAccess.GetFavoritePhones(userId);

            var favoritePhones = favoritePhonesDTO.Select(phoneDTO => _phoneFactory.CreatePhone(phoneDTO)).ToList();

            return favoritePhones;
        }
    }
}
