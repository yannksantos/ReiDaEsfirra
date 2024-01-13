using Domain.Interfaces;
using Domain.Models;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public class PedidoRepository : Repository<Pedidos> , IPedidosRepository
    {
        public PedidoRepository(ContextBase context) : base(context) { }

        public async Task<Pedidos> ObterPedidoEmRota(Guid id)
        {
            return await _context.Pedidos
                .Include(p => p.Entregador)
                .ThenInclude(p => p.Clientes)
                .ThenInclude(p => p.Endereco)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Pedidos>> ObterTodosPedidos()
        {
            return await _context.Pedidos
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Pedidos>> ObterPedidosPorClienteId(Guid clienteId)
        {
            return await _context.Pedidos
                .Include(p => p.Cliente)
                .ThenInclude(p => p.Endereco)
                .AsNoTracking()
                .Where(p => p.Cliente.Id == clienteId)
                .ToListAsync();
        }
    }
}
