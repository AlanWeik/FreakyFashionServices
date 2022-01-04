namespace FreakyFashionServices.BasketService.Models.Domain
{
    public class Basket
    {
        public Basket(
            int id,
            int items)
        {
            Id = id;
            Items = items;
        }
        public int Id { get; protected set; }
        public int Items { get; protected set; }  
    }
}
