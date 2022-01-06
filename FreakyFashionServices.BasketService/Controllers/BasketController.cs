using FreakyFashionServices.BasketService.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FreakyFashionServices.BasketService.Controllers
{
    [Route("api/basket")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        public BasketController(IDistributedCache cache)
        {
            Cache = cache;
        }

        public IDistributedCache Cache { get; }

        [HttpPost]
        public IActionResult RegisterBasket(Models.DTO.UpdateItemsDto basketDto)
        {
            var serializedBasket = JsonSerializer.Serialize(basketDto);

            Cache.SetString(basketDto.Id, serializedBasket);

            return Created("", null); // 201 created
        }

        [HttpGet("{id}")]
        public ActionResult<Models.DTO.UpdateItemsDto> GetBasket(string id)
        {
            var serializedRegistation = Cache.GetString(id);

            if (serializedRegistation == null)
                return NotFound(); // 404 Not Found

            var basketDto = JsonSerializer.Deserialize<BasketDto>(serializedRegistation);

            return Ok(basketDto);
        }

        [HttpPut]
        public IActionResult UpdateItems(BasketDto basketDto)
        {
            var updateItemRegistration = JsonSerializer.Serialize(basketDto);

            Cache.SetString(basketDto.Id, updateItemRegistration);

            return Ok(updateItemRegistration);
        }
        public class BasketDto
        {
            public ICollection<Models.DTO.UpdateItemsDto> Items { get; set; }
            public string Id { get; set; }
        }

    }
}
