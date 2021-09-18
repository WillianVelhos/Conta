using Conta.Domain.Repositories;
using Conta.Domain.Services;
using Mapster;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using domainModels = Conta.Domain.Models;

namespace Conta.Application.Inclusao
{
    public class InclusaoCommandHandler : IRequestHandler<InclusaoCommand, InclusaoCommandResult>
    {
        private readonly ContaDomainService _contaDomainService;
        private readonly IContaRepository _contaRepository;

        public InclusaoCommandHandler(ContaDomainService contaDomainService, IContaRepository contaRepository)
        {
            _contaDomainService = contaDomainService;
            _contaRepository = contaRepository;
        }

        public async Task<InclusaoCommandResult> Handle(InclusaoCommand request, CancellationToken cancellationToken)
        {
            var conta = request.Adapt<domainModels.Conta>();

            _contaDomainService.CalcularValorCorrigido(conta);

            _contaRepository.Add(conta);

            return new InclusaoCommandResult() { };
        }
    }
}
