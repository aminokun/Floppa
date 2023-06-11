﻿using Leapy.DTO.DataModels;
using Leapy.Factory;
using Leapy.Interfaces;
using Leapy.Models;

namespace Leapy.Logic.Services
{
    public class PhoneService
    {
        private readonly IPhone _phoneDataAccess;

        public PhoneService()
        {
            PhoneFactory phoneFactory = new PhoneFactory();
            _phoneDataAccess = phoneFactory.UsePhoneDAL("Phone");
        }

        public List<Phone> GetPhones()
        {
            List<PhoneDTO> phoneDTOs = _phoneDataAccess.GetPhones();

            var phones = phoneDTOs.Select(phoneDTO => CreatePhone(phoneDTO)).ToList();

            return phones;
        }

        public Phone GetPhoneByArtNr(int ArtNr)
        {
            PhoneDTO phoneDTO = _phoneDataAccess.GetPhoneByArtNr(ArtNr);

            return CreatePhone(phoneDTO);
        }

        public List<Phone> GetFavoritePhones(int userId)
        {
            var favoritePhonesDTO = _phoneDataAccess.GetFavoritePhones(userId);

            var favoritePhones = favoritePhonesDTO.Select(phoneDTO => CreatePhone(phoneDTO)).ToList();

            return favoritePhones;
        }


        public Phone CreatePhone(PhoneDTO phoneDTO)
        {
            return new Phone
            {
                ArtNr = phoneDTO.ArtNr,
                ImageUrl = phoneDTO.ImageUrl,
                Title = phoneDTO.Title,
                Price = phoneDTO.Price,
                IsFavorite = phoneDTO.IsFavorite
            };
        }
    }
}
