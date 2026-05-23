using System.ComponentModel;

namespace Domain.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string? Discription { get; private set; }    

       // public Category category { get; private set; }
        public Guid CategoryId { get; private set; }
        private Product() { } // EF Core / serialization
        public Product(string name, string? discription, Guid categoryId)
        {
           
            Name = name.Trim();
            Discription = discription?.Trim();
            CategoryId = categoryId;
        }
    }
}