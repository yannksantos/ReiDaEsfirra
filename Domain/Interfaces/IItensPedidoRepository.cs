using Domain.Models;

namespace Domain.Interfaces
{
    public interface IItensPedidoRepository  : IRepository<ItensPedido>
    {
        Task<IEnumerable<ItensPedido>> ObterTodosItensPedido();
        Task<ItensPedido> ObterItensPedidoPorPedidoId(Guid pedidoId);
    }
}
