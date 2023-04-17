using Leapy.Data.Repositories;
using Leapy.Data.DataModels;

namespace Leapy.Logic.Services
{
    public class PhoneService
    {
        private readonly PhoneRepository _phoneRepository;

        public PhoneService()
        {
            _phoneRepository = new PhoneRepository();
        }

        public List<Phone> GetPhones()
        {
            List<Phone> phones = _phoneRepository.GetPhones();

            return phones;
        }
    }
}
