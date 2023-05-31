using Leapy.DTO.DataModels;
using Leapy.Models;

namespace Leapy.Interfaces
{
    public interface ISmartphoneFactory
    {
        Phone CreatePhone(PhoneDTO phoneDTO);
    }
}
