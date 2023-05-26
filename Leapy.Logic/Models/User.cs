namespace Leapy.Logic.Models;

public class User
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public List<Book>? favorite_books { get; set; }
    public List<Phone>? favorite_phones { get; set; }

}
