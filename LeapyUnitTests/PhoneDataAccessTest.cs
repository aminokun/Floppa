using Leapy.Data.Repositories;
using Leapy.DTO.DataModels;

namespace Leapy.Tests
{
    [TestFixture]
    public class PhoneDataAccessTests
    {
        private PhoneDataAccess _phoneDataAccess;

        [SetUp]
        public void SetUp()
        {
            _phoneDataAccess = new PhoneDataAccess();
        }

        [Test]
        public void GetPhones_ReturnsListOfPhones()
        {
            // Act
            List<PhoneDTO> phones = _phoneDataAccess.GetPhones();

            // Assert
            Assert.NotNull(phones);
            Assert.IsInstanceOf<List<PhoneDTO>>(phones);
            Assert.Greater(phones.Count, 0);
        }

        [Test]
        public void GetPhoneByArtNr_ExistingArtNr_ReturnsPhone()
        {
            // Arrange
            int existingArtNr = 1734083;

            // Act
            PhoneDTO phone = _phoneDataAccess.GetPhoneByArtNr(existingArtNr);

            // Assert
            Assert.NotNull(phone);
            Assert.AreEqual(existingArtNr, phone.ArtNr);
        }

        [Test]
        public void GetPhoneByArtNr_NonExistingArtNr_ReturnsNull()
        {
            // Arrange
            int nonExistingArtNr = 9999;

            // Act
            PhoneDTO phone = _phoneDataAccess.GetPhoneByArtNr(nonExistingArtNr);

            // Assert
            Assert.Null(phone);
        }

        [Test]
        public void GetFavoritePhones_ValidUserId_ReturnsListOfFavoritePhones()
        {
            // Arrange
            int userId = 1;

            // Act
            List<PhoneDTO> favoritePhones = _phoneDataAccess.GetFavoritePhones(userId);

            // Assert
            Assert.NotNull(favoritePhones);
            Assert.IsInstanceOf<List<PhoneDTO>>(favoritePhones);
        }
    }
}
