using FreakyFashionServices.BasketService.Data;
using FreakyFashionServices.BasketService.Models.Domain;
using FreakyFashionServices.BasketService.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        [HttpGet("{Id}")]
        public ActionResult<UpdateBasketDto> GetBasket(int Id)
        {
            var basket = Context.Basket
                .Include(x => x.Items)
                .FirstOrDefault(x => x.Id == Id);

            if (basket == null)
                return NotFound();

            var basketDto = new UpdateBasketDto
            {
                Id = basket.Id,
                /*Items = basket.Items.Select(x => new UpdateBasketDto
                {
                    Id = x.Id,
                    Items = x.Items
                })*/

            };
            return Ok(basketDto);
        }

        // PUT api/<BasketController>/5
        [HttpPut]
        public IActionResult PutBasket(UpdateBasketDto basketDto)
        {
            var basket = new Basket(
                id: basketDto.Id,
                items: basketDto.Items
                );

            Context.Basket.Add(basket);
            Context.SaveChanges();
            return Created("", basketDto); // 201 Created

        }

        [HttpPost]
        public IActionResult PostBasket(UpdateBasketDto basketDto)
        {
            var basket = new Basket(
                id: basketDto.Id,
                items: basketDto.Items
                );

            Context.Basket.Add(basket);
            Context.SaveChanges();
            return Created("", basketDto); // 201 Created

        }
        public class BasketDto
        {
            public int Id { get; set; }
            public int Items { get; set; }
        }
    }
    
}
