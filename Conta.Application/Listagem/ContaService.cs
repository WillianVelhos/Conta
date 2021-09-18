using Conta.Application.Listagem.Dtos;
using Conta.Domain.Repositories;
using Mapster;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conta.Application.Listagem
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _contaRepository;

        public ContaService(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }

        public async Task<IEnumerable<ContaDto>> Listar()
        {
            var contas = await _contaRepository.GetAll();

            return contas.Adapt<IEnumerable<ContaDto>>();
        }
    }
}
