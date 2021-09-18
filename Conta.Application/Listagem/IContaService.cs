using Conta.Application.Listagem.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conta.Application.Listagem
{
    public interface IContaService
    {
        Task<IEnumerable<ContaDto>> Listar();
    }
}
