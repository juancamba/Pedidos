using Microsoft.EntityFrameworkCore;
using Pedidos.Database;
using Pedidos.Exceptions;
using Pedidos.Models;

namespace Pedidos.Services
{
    public class PedidosService : IPedidosService
    {
        IPagoService _pagoService;
        IStockService _stockService;
        private readonly AppDbContext _appDbContext;

        public PedidosService(IPagoService pagoService, IStockService stockService, AppDbContext appDbContext)
        {
            _pagoService = pagoService;
            _stockService = stockService;
            _appDbContext = appDbContext;
        }


        public async Task<Pedido> AddPedido(Pedido pedido)
        {
            if (pedido != null)
            {
                //suma de importes de detalles * cantidad
                pedido.Total = pedido.Detalles.Sum(d => d.Subtotal * d.Cantidad);


                if (_pagoService.Pagar(pedido))
                {
                    _stockService.QuitarStock(pedido);

                    _appDbContext.Pedidos.Add(pedido);
                    await _appDbContext.SaveChangesAsync();
                    return pedido;

                }
                else
                {
                    throw new Exception("No se pudo realizar el pago");
                }
            }
            else
            {
                throw new Exception("El pedido no puede ser nulo");
            }


        }
        public async Task<Pedido> GetPedido(int id)
        {
            var pedido = await _appDbContext.Pedidos.FindAsync(id);
            if (pedido != null)
            {
                return pedido;
            }
            else
            {
                throw new NotFoundException(nameof(Pedido), id);
            }

        }

        public async Task<IEnumerable<Pedido>> GetPedidos()
        {
            var pedidos = await _appDbContext.Pedidos.ToListAsync();

            return pedidos;
        }
    }
}