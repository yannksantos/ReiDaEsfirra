using Domain.Models;

namespace Domain.Interfaces
{
    public interface IItensMenuService : IDisposable
    {
        Task Adicionar(ItensMenu itemMenu);
        Task Atualizar(ItensMenu itemMenu);
        Task Remover(Guid id);
    }
}
