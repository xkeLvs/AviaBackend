using Microsoft.EntityFrameworkCore;

namespace AviaBackend.Application.DTOs.Product
{
    public class CreateProductDto
    {
        public required string Name { get; set; }

        [Precision(18, 2)]
        public required decimal Price { get; set; }

        // Foreign key
        public required Guid CategoryId { get; set; }
    }
}
