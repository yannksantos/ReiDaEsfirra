using Domain.Models;

namespace Domain.Interfaces
{
    public interface IClienteService : IDisposable
    {
        Task Adicionar(Clientes cliente);
        Task Atualizar(Clientes cliente);
        Task Remover(Guid id);
        Task AtualizarEndereco(Endereco endereco);
    }
}
