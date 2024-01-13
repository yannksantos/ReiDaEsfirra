using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Esfirra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : BaseController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteRepository clienteRepository, IClienteService clienteService) 
        {
            _clienteRepository = clienteRepository;
            _clienteService = clienteService;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<object> ListarClientes()
        {
            var cliente = await _clienteRepository.ObterTodos();
            return Ok(cliente);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterCliente(Guid id)
        {
            var cliente = await _clienteRepository.ObterPorId(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarCliente(Clientes cliente)
        {
            try
            {
                await _clienteService.Adicionar(cliente);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarCliente(Guid id, Clientes cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }
            await _clienteService.Atualizar(cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarCliente(Guid id)
        {
            await _clienteService.Remover(id);
            return NoContent();
        }
    }
}
