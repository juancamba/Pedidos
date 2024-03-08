using Microsoft.EntityFrameworkCore;
using Pedidos.Models;

namespace Pedidos.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite(connectionString: "Filename=Pedidos.db",
                  options =>
                  {
                      options.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
                      //options.GetExecutingAssembly().FullName;
                  }

                  );

            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<DetallePedido> Detalles { get; set; }
    }
}
