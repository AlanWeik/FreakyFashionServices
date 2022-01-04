using FreakyFashionServices.CatalogService.Models.Domain;
using FreakyFashionServices.CatalogService.Models.DTO;
using FreakyFashionServices.CatalogService.Data;
using Microsoft.AspNetCore.Mvc;

namespace FreakyFashionServices.CatalogService.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private ApplicationContext Context { get; set; }

        public CatalogController(ApplicationContext context)
        {
            Context = context;
        }

        // POST api/products
        [HttpPost]
        public IActionResult RegisterProduct(ProductDto productDto)
        {

            var name = productDto.Name;
            name = name.Replace("-", "");
            name = name.Replace(" ", "-");


            var product = new Product(
                id: productDto.Id,
                name: productDto.Name,
                description: productDto.Description,
                imageUrl: productDto.ImageUrl,
                price: productDto.Price,
                articleNumber: productDto.ArticleNumber,
                urlSlug: name.ToLower()
                );

            Context.Product.Add(product);
            Context.SaveChanges(); 

            return Created("", productDto); // 201 Created
        }
    }
}
