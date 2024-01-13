using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Esfirra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItensPedidoController : BaseController
    {
        private readonly IItensPedidoRepository _itensPedidoRepository;
        private readonly IItensPedidoService _itensPedidoService;
        public ItensPedidoController(IItensPedidoRepository itensPedidoRepository, IItensPedidoService itensPedidoService) 
        {
            _itensPedidoRepository = itensPedidoRepository;
            _itensPedidoService = itensPedidoService;
        }


        [HttpGet]
        [Produces("application/json")]
        public async Task<object> ListarItensPedidos()
        {
            var itensPedido = await _itensPedidoRepository.ObterTodos();
            return Ok(itensPedido);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterItensPedido(Guid id)
        {
            var itensPedido = await _itensPedidoRepository.ObterPorId(id);
            if (itensPedido == null)
            {
                return NotFound();
            }
            return Ok(itensPedido);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarItensPedido(ItensPedido itensPedido)
        {
            try
            {
                await _itensPedidoService.Adicionar(itensPedido);
                return Ok(itensPedido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarItensPedido(Guid id, ItensPedido itensPedido)
        {
            if (id != itensPedido.Id)
            {
                return BadRequest();
            }
            await _itensPedidoService.Atualizar(itensPedido);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarItensPedido(Guid id)
        {
            await _itensPedidoService.Remover(id);
            return NoContent();
        }
    }
}
