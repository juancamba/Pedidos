using Pedidos.Models;

namespace Pedidos.Services
{
    public interface IStockService
    {

        void QuitarStock(Pedido pedido);

    }
}
