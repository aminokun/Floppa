namespace Leapy.Data.DataModels
{
    public class BookDTO
    {
        public string? ImageUrl { get; set; }
        public string? Title { get; set; }
        public decimal Price { get; set; }
        public string? UPC { get; set; }
        public bool IsFavorite { get; set; }
    }
}