using Leapy.Logic.Models;
using System.ComponentModel.DataAnnotations;

namespace Leapy.Models
{
    public class FavoriteViewModel : Phone
    {
        public List<Phone>? FavoritePhones { get; set; }
    }
}