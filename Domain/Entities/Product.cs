using Microsoft.EntityFrameworkCore;

namespace AviaBackend.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        [Precision(18, 2)]
        public required decimal Price { get; set; }

        // Foreign key
        public required Guid CategoryId { get; set; }

        // Navigation property
        public Category? Category { get; set; }
    }
}
