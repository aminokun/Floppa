using Leapy.DTO.DataModels;
using Leapy.Interfaces;
using Leapy.Models;

namespace Leapy.Factory
{
    public class PhoneFactory : ISmartphoneFactory
    {
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
