using Domain.Enums;
using Domain.Interfaces;
using Domain.Models;
using Domain.Services;

namespace Application.Services
{
    public class PedidoService : BaseService , IPedidosService
    {
        private readonly IPedidosRepository _pedidosRepository;
        public PedidoService(IPedidosRepository pedidosRepository)
        {
            _pedidosRepository = pedidosRepository;
        }

        public async Task Adicionar(Pedidos pedidos)
        {
            pedidos.Status = PedidoEnum.Iniciado;
            await _pedidosRepository.Adicionar(pedidos);
        }

        public async Task Atualizar(Pedidos pedidos)
        {
            await _pedidosRepository.Atualizar(pedidos);
        }

        public async Task Remover(Guid id)
        {
            await _pedidosRepository.Remover(id);
        }

        public async Task ColocarEmRota(Pedidos pedidos)
        {
            if (pedidos.Status != PedidoEnum.Iniciado)
            pedidos.Status = PedidoEnum.EmRota;
            await _pedidosRepository.Atualizar(pedidos);
        }

        public void Dispose()
        {
            _pedidosRepository.Dispose();
        }
    }
}
