using Domain.Models;

namespace Domain.Interfaces
{
    public interface IEntregadorService : IDisposable
    {
        Task Adicionar(Entregador entregador);
        Task Atualizar(Entregador entregador);
        Task Remover(Guid id);
    }
}
