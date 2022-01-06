namespace FreakyFashionServices.OrderService.Models.DTO
{
    public class BasketDto
    {
        public string Id { get; set; }
        public ICollection<BasketItemsDto> Items { get; set; }
    }
}
