using FreakyFashionService.OrderService.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FreakyFashionService.OrderService.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> Orderlines { get; set; }
    }
}

