using Microsoft.Extensions.Logging;
using Pedidos.Models;

namespace Pedidos.Services
{
    public class PagoService : IPagoService
    {
        private ILogger<PagoService> _logger;

        public PagoService(ILogger<PagoService> logger)
        {
            _logger = logger;
        }
        public bool Pagar(Pedido pedido)
        {

            _logger.LogInformation($"Pago de {pedido.Total} realizado", pedido);
            return true;
        }
    }
}
