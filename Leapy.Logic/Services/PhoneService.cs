using Leapy.Data.Repositories;
using Leapy.Data.DataModels;
using Leapy.Logic.Models;

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

        public List<Phone> GetFavoritePhones(int userId)
        {
            var favoritePhonesDTO = _phoneDataAccess.GetFavoritePhones(userId);

            var favoritePhones = favoritePhonesDTO.Select(phoneDTO => new Phone
            {
                ArtNr = phoneDTO.ArtNr,
                ImageUrl = phoneDTO.ImageUrl,
                Title = phoneDTO.Title,
                Price = phoneDTO.Price,
                IsFavorite = phoneDTO.IsFavorite
    }).ToList();

            return favoritePhones;
        }


    }
}
