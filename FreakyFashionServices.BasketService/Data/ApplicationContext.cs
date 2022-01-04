using FreakyFashionServices.BasketService.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FreakyFashionServices.BasketService.Data

{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

        }
        public DbSet<Basket> Basket { get; set; }
    }
}
