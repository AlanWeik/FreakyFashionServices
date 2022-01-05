using FreakyFashionServices.CatalogService.Models.Domain;
using FreakyFashionServices.CatalogService.Models.DTO;
using FreakyFashionServices.CatalogService.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        // Post a new product and save it to the DB. 
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

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return Created("", productDto); // 201 Created
            }
        }
        // GET api/products
        // Fetch all products and list them. 
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var products = Context.Product.ToList();
            return products;
        }
    }
}
