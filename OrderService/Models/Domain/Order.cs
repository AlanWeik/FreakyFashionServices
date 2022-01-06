namespace FreakyFashionService.OrderService.Models.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Customer { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }
    }
}
