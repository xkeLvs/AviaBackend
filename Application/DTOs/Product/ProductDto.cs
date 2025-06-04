using Microsoft.EntityFrameworkCore;
using AviaBackend.Application.DTOs.Product;
using AviaBackend.Application.DTOs.Category;

namespace AviaBackend.Application.DTOs.Product
{
    public class ProductDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        // Foreign key
        public Guid CategoryId { get; set; }

        public CategoryDto? Category { get; set; }


    }
}
