namespace AviaBackend.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; set; } // Primary Key

        required
        public string Name
        { get; set; }

        // Navigation property (1-to-many)
        public ICollection<Product>? Products { get; set; }
    }
}
