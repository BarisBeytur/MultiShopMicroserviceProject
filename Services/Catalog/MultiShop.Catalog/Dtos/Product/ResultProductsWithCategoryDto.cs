
namespace MultiShop.Catalog.Dtos.Product
{
    public class ResultProductsWithCategoryDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }

        public MultiShop.Catalog.Entities.Category Category { get; set; }
    }
}
