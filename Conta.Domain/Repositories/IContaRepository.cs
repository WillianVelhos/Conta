using System.Collections.Generic;
using System.Threading.Tasks;
using domainModels = Conta.Domain.Models;

namespace Conta.Domain.Repositories
{
    public interface IContaRepository
    {
        Task<IEnumerable<domainModels.Conta>> GetAll();

        void Add(domainModels.Conta conta);
    }
}
