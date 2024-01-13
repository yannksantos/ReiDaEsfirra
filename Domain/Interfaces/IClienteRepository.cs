using Domain.Models;

namespace Domain.Interfaces
{
    public interface IClienteRepository : IRepository<Clientes>
    {
        Task<Clientes> ObterClientePorId(Guid id);
    }
}
