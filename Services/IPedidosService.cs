using Pedidos.Models;

namespace Pedidos.Services
{
    public interface IPedidosService
    {
        Task<IEnumerable<Pedido>> GetPedidos();
        Task<Pedido> GetPedido(int id);

        Task<Pedido> AddPedido(Pedido pedido);

    }
}
