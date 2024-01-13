using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Esfirra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItensMenuController : BaseController
    {
        private readonly IItensMenuRepository _itensMenuRepository;
        private readonly IItensMenuService _itensMenuService;
        public ItensMenuController(IItensMenuRepository itensMenuRepository, IItensMenuService itensMenuService) 
        {
            _itensMenuRepository = itensMenuRepository;
            _itensMenuService = itensMenuService;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<object> ListarItensMenu()
        {
            var itensMenu = await _itensMenuRepository.ObterTodos();
            return Ok(itensMenu);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterItensMenu(Guid id)
        {
            var itensMenu = await _itensMenuRepository.ObterPorId(id);
            if (itensMenu == null)
            {
                return NotFound();
            }
            return Ok(itensMenu);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarItensMenu(ItensMenu itensMenu)
        {
            try
            {
                await _itensMenuService.Adicionar(itensMenu);
                return Ok(itensMenu);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarItensMenu(Guid id, ItensMenu itensMenu)
        {
            if (id != itensMenu.Id)
            {
                return BadRequest();
            }
            await _itensMenuService.Atualizar(itensMenu);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarItensMenu(Guid id)
        {
            await _itensMenuService.Remover(id);
            return NoContent();
        }
    }
}
