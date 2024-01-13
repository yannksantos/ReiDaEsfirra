using Domain.Models;

namespace Domain.Interfaces
{
    public interface IItensPedidoService : IDisposable
    {
        Task Adicionar(ItensPedido itensPedido);
        Task Atualizar(ItensPedido itensPedido);
        Task Remover(Guid id);
    }
}
