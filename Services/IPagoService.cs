using Pedidos.Models;

namespace Pedidos.Services
{
    public interface IPagoService
    {
        public bool Pagar(Pedido pedido);
    }
}
