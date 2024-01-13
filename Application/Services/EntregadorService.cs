using Domain.Interfaces;
using Domain.Models;
using Domain.Services;

namespace Application.Services
{
    public class EntregadorService : BaseService , IEntregadorService

    {
        private readonly IEntregadorRepository _entregadorRepository;
        public EntregadorService(IEntregadorRepository entregadorRepository) 
        {
            _entregadorRepository = entregadorRepository;
        }

        public async Task Adicionar(Entregador entregador)
        {
            if (_entregadorRepository.Buscar(f => f.Telefone == entregador.Telefone).Result.Any())
            await _entregadorRepository.Adicionar(entregador);
        }

        public async Task Atualizar(Entregador entregador)
        {
            await _entregadorRepository.Atualizar(entregador);
        }

        public async Task Remover(Guid id)
        {
            await _entregadorRepository.Remover(id);
        }
        public void Dispose()
        {
            _entregadorRepository.Dispose();
        }
    }
}
