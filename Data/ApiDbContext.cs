using ClienteApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ClienteApi.Data
{
    public class ApiDbContext : DbContext
    {
      
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

    }
}