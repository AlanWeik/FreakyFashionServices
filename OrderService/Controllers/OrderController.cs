using FreakyFashionService.OrderService.Data;
using FreakyFashionService.OrderService.Models.Domain;
using FreakyFashionService.OrderService.Models.DTO;
using FreakyFashionServices.OrderService.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FreakyFashionService.OrderService.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private ApplicationContext Context { get; set; }
        private IHttpClientFactory HttpClientFactory { get; set; }

        public OrderController(ApplicationContext context, IHttpClientFactory httpClientFactory)
        {
            Context = context;
            HttpClientFactory = httpClientFactory;
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task <IActionResult> MakeOrder(OrderDto orderDto)
        {
            var httpClient = HttpClientFactory.CreateClient();
            var httpResponse = await httpClient.GetAsync($"http://localhost:5000/api/basket/{orderDto.Identifier}"); 
            var responseContent = await httpResponse.Content.ReadAsStringAsync();
            var basket = JsonSerializer.Deserialize<BasketDto>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true } );

            // AutoMapper 
            var order = new Order
            {
                Identifier = orderDto.Identifier,
                Customer = orderDto.Customer,
                OrderLines = basket.Items.Select
                (item => new OrderLine { 
                    ProductId = Convert.ToInt32(item.Id), 
                    Quantity = Convert.ToInt32(item.Quantity) }).ToList()
            };

            Context.Orders.Add(order);
            Context.SaveChanges();

            if (order == null)
            {
                return NotFound();
            }
            else
            {
                return Created("", new { orderId = order.Id }); // 201 Created
            }
        }

        /*[HttpPost("{customerId}")]
        public IActionResult MakeOrder(string customerId, NewOrderEntryDto newOrderEntryDto)
        {
            var order = Context.Order.FirstOrDefault(x => x.CustomerId == customerId);

            if (order == null)
            {
                order = new Order(customerId);

                Context.Order.Add(order);
            }
            // Map
            var orderEntry = new OrderEntry(
               orderBy: newOrderEntryDto.OrderBy,
               orderDate: newOrderEntryDto.OrderDate,
               comment: newOrderEntryDto.Comment
            );

            order.Orders.Add(orderEntry);

            Context.SaveChanges();

            var orderEntryDto = new OrderEntryDto
            {
                Id = orderEntry.Id,
                OrderBy = orderEntry.OrderBy,
                OrderDate = orderEntry.OrderDate,
                Comment = orderEntry.Comment
            };

            return Created("", orderEntryDto); // 201 Created
        }*/
    }
}
