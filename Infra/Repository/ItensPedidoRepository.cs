using Domain.Interfaces;
using Domain.Models;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public class ItensPedidoRepository : Repository<ItensPedido> , IItensPedidoRepository
    {
        public ItensPedidoRepository(ContextBase context) : base(context) { }
             
        public async Task<IEnumerable<ItensPedido>> ObterTodosItensPedido()
        {
            return await _context.ItensPedido
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ItensPedido> ObterItensPedidoPorPedidoId(Guid pedidoId)
        {
            return await _context.ItensPedido
                .Include(i => i.Pedido)
                .ThenInclude(i => i.PedidosId)
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.Id == pedidoId);
        }
    }
}
