using FreakyFashionServices.BasketService.Data;
using FreakyFashionServices.BasketService.Models.Domain;
using FreakyFashionServices.BasketService.Models.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FreakyFashionServices.BasketService.Controllers
{
    [Route("api/basket")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private ApplicationContext Context { get; set; }
        public BasketController(ApplicationContext context)
        {
            Context = context;
        }

        [HttpPost]
        public IActionResult PostBasket(BasketDto basketDto)
        {
            var basket = new Basket(
                id: basketDto.Id,
                items: basketDto.Items
                );

            Context.Basket.Add(basket);
            Context.SaveChanges();
            return Created("", basketDto); // 201 Created

        }

        // PUT api/<BasketController>/5
        [HttpPut]
        public IActionResult PutBasket(BasketDto basketDto)
        {
            var basket = new Basket(
                id: basketDto.Id,
                items: basketDto.Items
                );

            Context.Basket.Add(basket);
            Context.SaveChanges();
            return Created("", basketDto); // 201 Created

        }

    }
}
