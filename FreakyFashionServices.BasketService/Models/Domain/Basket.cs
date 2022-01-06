using FreakyFashionServices.BasketService.Models.DTO;

namespace FreakyFashionServices.BasketService.Models.Domain
{
    public class Basket
    {
        public string Id { get; set; }
        public ICollection<UpdateItemsDto> Items { get; set; }
    }
}
