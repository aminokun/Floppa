using System.Threading.Tasks;
using Leapy.DTO.DataModels;
using Leapy.Interfaces;
using Leapy.Logic.Services;
using Moq;

namespace Leapy.UnitTests
{
    [TestFixture]
    public class UserServiceTests
    {
        private Mock<IUser> _userDataAccessMock;
        private UserService _userService;

        [SetUp]
        public void SetUp()
        {
            _userDataAccessMock = new Mock<IUser>();
            _userService = new UserService();
        }

        [Test]
        public async Task GetUserByEmailAsync_ValidEmail_ReturnsUser()
        {
            // Arrange
            string email = "test@example.com";
            UserDTO user = new UserDTO { Email = email };
            _userDataAccessMock.Setup(x => x.GetUserByEmailAsync(email)).ReturnsAsync(user);

            // Act
            UserDTO result = await _userService.GetUserByEmailAsync(email);

            // Assert
            Assert.AreEqual(user, result);
        }

        [Test]
        public async Task Authenticate_ValidCredentials_ReturnsTrue()
        {
            // Arrange
            string email = "test@example.com";
            string password = "password";
            UserDTO user = new UserDTO { Email = email, Password = BCrypt.Net.BCrypt.HashPassword(password) };
            _userDataAccessMock.Setup(x => x.GetUserByEmailAsync(email)).ReturnsAsync(user);

            // Act
            bool result = _userService.Authenticate(email, password);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task Authenticate_InvalidCredentials_ReturnsFalse()
        {
            // Arrange
            string email = "test@example.com";
            string password = "passwordsdad";
            UserDTO user = new UserDTO { Email = email, Password = BCrypt.Net.BCrypt.HashPassword("wrongpassword") };
            _userDataAccessMock.Setup(x => x.GetUserByEmailAsync(email)).ReturnsAsync(user);

            // Act
            bool result = _userService.Authenticate(email, password);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Register_NewUser_SuccessfullyRegistersUser()
        {
            // Arrange
            string username = "testuser";
            string email = "test@example.com";
            string password = "passwowrd";
            UserDTO newUser = new UserDTO { Username = username, Email = email, Password = BCrypt.Net.BCrypt.HashPassword(password) };
            _userDataAccessMock.Setup(x => x.GetUserByEmailAsync(email)).ReturnsAsync((UserDTO)null);
            _userDataAccessMock.Setup(x => x.GetUserByUsernameAsync(username)).ReturnsAsync((UserDTO)null);
            _userDataAccessMock.Setup(x => x.AddUserAsync(It.IsAny<UserDTO>())).Returns(Task.CompletedTask);

            // Act & Assert
            Assert.DoesNotThrowAsync(() => _userService.Register(username, email, password));
        }

        [Test]
        public void Register_UserWithEmailAlreadyExists_ThrowsArgumentException()
        {
            // Arrange
            string username = "testuser";
            string email = "test@example.com";
            string password = "password";
            UserDTO existingUser = new UserDTO { Username = "existinguser", Email = email };
            _userDataAccessMock.Setup(x => x.GetUserByEmailAsync(email)).ReturnsAsync(existingUser);

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(() => _userService.Register(username, email, password));
        }

        [Test]
        public void Register_UserWithUsernameAlreadyExists_ThrowsArgumentException()
        {
            // Arrange
            string username = "testuser";
            string email = "test@example.com";
            string password = "password";
            UserDTO existingUser = new UserDTO { Username = username, Email = "existing@example.com" };
            _userDataAccessMock.Setup(x => x.GetUserByEmailAsync(email)).ReturnsAsync((UserDTO)null);
            _userDataAccessMock.Setup(x => x.GetUserByUsernameAsync(username)).ReturnsAsync(existingUser);

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(() => _userService.Register(username, email, password));
        }
    }
}
