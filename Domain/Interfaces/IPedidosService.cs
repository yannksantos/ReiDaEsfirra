using Domain.Models;

namespace Domain.Interfaces
{
    public interface IPedidosService : IDisposable
    {
        Task Adicionar(Pedidos pedidos);
        Task Atualizar(Pedidos pedidos);
        Task Remover(Guid id);
        Task ColocarEmRota (Pedidos pedidos);
    }
}
