using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Esfirra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : BaseController
    {
        private readonly IPedidosService _pedidoService;
        private readonly IPedidosRepository _pedidoRepository;

        public PedidosController(IPedidosService pedidoService, IPedidosRepository pedidoRepository) 
        {
            _pedidoService = pedidoService;
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<object> ListarPedidos()
        {
            var pedidos = await _pedidoRepository.ObterTodos();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> ObterPedido(Guid id)
        {
            var pedido = await _pedidoRepository.ObterPorId(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return Ok(pedido);
        }

        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> AdicionarPedido(Pedidos pedido)
        {
            try
            {
                await _pedidoService.Adicionar(pedido);
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> AtualizarPedido(Guid id, Pedidos pedido)
        {
            if (id != pedido.Id)
            {
                return BadRequest();
            }
            await _pedidoService.Atualizar(pedido);
            return NoContent();
        }

        [HttpPut("{id}/em-rota")]
        public async Task<IActionResult> ColocarEmRota(Guid id , Pedidos pedido)
        {
            if (id != pedido.Id)
            {
                return BadRequest();
            }
            await _pedidoService.ColocarEmRota(pedido);
            return NoContent();
        }


        [HttpDelete("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> DeletarPedido(Guid id)
        {
            await _pedidoService.Remover(id);
            return NoContent();
        }


    }
}
