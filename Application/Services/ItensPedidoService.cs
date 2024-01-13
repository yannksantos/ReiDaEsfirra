using Domain.Interfaces;
using Domain.Models;
using Domain.Services;

namespace Application.Services
{
    public class ItensPedidoService : BaseService , IItensPedidoService
    {
        private readonly IItensPedidoRepository _itensPedidoRepository;
        public ItensPedidoService(IItensPedidoRepository itensPedidoRepository) 
        {
            _itensPedidoRepository = itensPedidoRepository;
        }

        public async Task Adicionar(ItensPedido itensPedido)
        {
            await _itensPedidoRepository.Adicionar(itensPedido);
        }

        public async Task Atualizar(ItensPedido itensPedido)
        {
            await _itensPedidoRepository.Atualizar(itensPedido);
        }

        public async Task Remover(Guid id)
        {
            await _itensPedidoRepository.Remover(id);
        }

        public void Dispose()
        {
            _itensPedidoRepository.Dispose();
        }
    }
}
