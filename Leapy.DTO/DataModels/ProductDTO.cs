namespace Leapy.DTO.DataModels
{
    public class ProductDTO
    {
        public string? ImageUrl { get; set; }
        public string? Title { get; set; }
        public decimal Price { get; set; }
        public bool IsFavorite { get; set; }
    }
}
