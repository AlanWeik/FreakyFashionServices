namespace FreakyFashionService.OrderService.Models.Domain
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Order Order { get; set; }
    }
}