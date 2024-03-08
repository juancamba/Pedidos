using Pedidos.Database;
using Pedidos.Models;

namespace Pedidos
{
    public class Preparedb
    {
        public static void Population(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }
        public static void SeedData(AppDbContext context)
        {
            context.Database.EnsureCreated();
            if (!context.Clientes.Any())
            {
                Cliente cliente = new Cliente()
                {
                    Nombre = "Juan Perez",
                    Email = "juan@juan.com",

                };
                context.Clientes.Add(cliente);
                context.SaveChanges();

            }
            if (!context.Productos.Any())
            {
                Producto producto = new Producto()
                {
                    Nombre = "Producto 1",
                    Precio = 100,
                    Stock = 10

                };
                context.Productos.Add(producto);

                Producto producto1 = new Producto()
                {
                    Nombre = "Producto 2",
                    Precio = 200,
                    Stock = 20
                };
                context.Productos.Add(producto1);
                context.SaveChanges();

            }
            if (!context.Pedidos.Any())
            {

                DetallePedido detallePedido = new DetallePedido()
                {
                    Producto = context.Productos.FirstOrDefault(),
                    Cantidad = 2,
                    Subtotal = 200
                };

                Pedido p1 = new Pedido()
                {
                    Cliente = context.Clientes.FirstOrDefault(),
                    Fecha = DateTime.Now,
                    Detalles = new List<DetallePedido> { detallePedido }
                };

                context.Pedidos.Add(p1);
                context.SaveChanges();
            }
        }
    }
}