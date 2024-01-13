using System.Reflection.Metadata.Ecma335;
using Domain.Interfaces;
using Domain.Models;
using Domain.Services;

namespace Application.Services
{
    public class ClienteService : BaseService , IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task Adicionar(Clientes cliente)
        {
            if (_clienteRepository.Buscar(f => f.Telefone == cliente.Telefone).Result.Any());
            await _clienteRepository.Adicionar(cliente);
        }

        public async Task Atualizar(Clientes cliente)
        {
            await _clienteRepository.Atualizar(cliente);
        }

        public async Task Remover(Guid id)
        {
            await _clienteRepository.Remover(id);
        }

        public async Task AtualizarEndereco(Endereco endereco)
        {
             await _clienteRepository.Atualizar(endereco);

        }
        public void Dispose()
        {
            _clienteRepository.Dispose();
        }
    }
}
