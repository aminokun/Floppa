﻿namespace Leapy.Logic.Models
{
    public class Book
    {
        public string? ImageUrl { get; set; }
        public string? Title { get; set; }
        public decimal Price { get; set; }
        public string? UPC { get; set; }
        public bool IsFavorite { get; set; }
    }
}
