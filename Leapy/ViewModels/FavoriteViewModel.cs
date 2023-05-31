using Leapy.Models;
using System.ComponentModel.DataAnnotations;

namespace Leapy.ViewModels
{
    public class FavoriteViewModel : Phone
    {
        public List<Phone>? FavoritePhones { get; set; }
    }
}