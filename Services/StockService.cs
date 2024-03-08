using Microsoft.EntityFrameworkCore;
using Pedidos.Database;
using Pedidos.Models;
using System;

namespace Pedidos.Services
{
    public class StockService : IStockService
    {
        private readonly AppDbContext _appDbContext;
        public StockService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void QuitarStock(Pedido pedido)
        {

            pedido.Detalles.ForEach(async d =>
            {
                var producto = _appDbContext.Productos.Find(d.Producto.Id);
                if (producto.Stock < d.Cantidad)
                {
                    throw new Exception("No hay stock suficiente");
                }
                else
                {
                    producto.Stock -= d.Cantidad;

                }
            });
            _appDbContext.SaveChanges();

        }
    }
}
