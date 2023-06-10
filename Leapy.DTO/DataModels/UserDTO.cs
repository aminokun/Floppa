namespace Leapy.DTO.DataModels
{
    public class UserDTO
    {
        public UserDTO()
        {
            favorite_phones = new List<PhoneDTO>();
            favorite_books = new List<BookDTO>();
        }

        public int UserID { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public List<BookDTO>? favorite_books { get; set; }
        public List<PhoneDTO>? favorite_phones { get; set; }
    }


}


