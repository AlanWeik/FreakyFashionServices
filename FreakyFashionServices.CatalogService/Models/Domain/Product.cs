using System.ComponentModel.DataAnnotations;

namespace FreakyFashionServices.CatalogService.Models.Domain
{
    public class Product
    {
        public Product(int id, 
            string name, 
            string description, 
            int price, 
            string imageUrl, 
            string articleNumber, 
            string urlSlug)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            ImageUrl = imageUrl;
            ArticleNumber = articleNumber;
            UrlSlug = urlSlug;
        }

        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public int Price { get; protected set; }
        public string ImageUrl { get; protected set; }
        public string ArticleNumber { get; protected set; }
        public string UrlSlug { get; protected set; }
    }
}
