using Domain.Models;

namespace Domain.Interfaces
{
    public interface IPedidosRepository : IRepository<Pedidos>
    {
        Task<Pedidos> ObterPedidoEmRota(Guid id);
        Task<IEnumerable<Pedidos>> ObterTodosPedidos();
        Task<IEnumerable<Pedidos>> ObterPedidosPorClienteId(Guid clienteId);
    }
}
