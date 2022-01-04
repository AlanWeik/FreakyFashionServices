using FreakyFashionService.OrderService.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FreakyFashionService.OrderService.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        // POST api/<OrderController>
        [HttpPost]
        public IActionResult PostProduct(OrderDto orderDto)
        {
            /*Context.Order.Add(order);
            Context.SaveChanges();

            return Created("", productDto); // 201 Created*/

            return Ok();
        }

    }
}
