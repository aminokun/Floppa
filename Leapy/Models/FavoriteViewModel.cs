using Leapy.Logic.Models;
using System.ComponentModel.DataAnnotations;

namespace Leapy.Models
{
    public class FavoriteViewModel
    {
        public List<Book>? FavoriteBooks { get; set; }
        public List<Phone>? FavoritePhones { get; set; }
    }
}