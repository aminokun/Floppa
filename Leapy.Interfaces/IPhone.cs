using Leapy.DTO.DataModels;

namespace Leapy.Interfaces
{
    public interface IPhone
    {
        List<PhoneDTO> GetPhones();
        PhoneDTO GetPhoneByArtNr(int ArtNr);
        List<PhoneDTO> GetFavoritePhones(int userId);
    }
}
