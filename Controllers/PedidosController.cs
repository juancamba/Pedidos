using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pedidos.Models;
using Pedidos.Services;

namespace Pedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidosService _pedidosService;

        public PedidosController(IPedidosService pedidosService)
        {
            _pedidosService = pedidosService;

        }
        [HttpGet]
        public async Task<IEnumerable<Pedido>> GetPedidos()
        {
            return await _pedidosService.GetPedidos();
        }
        [HttpGet("{id}")]
        public async Task<Pedido> GetPedido(int id)
        {
            return await _pedidosService.GetPedido(id);
        }
        [HttpPost]
        public async Task<ActionResult<Pedido>> AddPedido(Pedido pedido)
        {
            var result = await _pedidosService.AddPedido(pedido);

            return Ok(result);

        }
    }
}
