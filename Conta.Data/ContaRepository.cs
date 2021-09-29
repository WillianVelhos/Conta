using Conta.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conta.Data
{
    public class ContaRepository : IContaRepository
    {
        private readonly ContaContext _context;

        public ContaRepository(ContaContext context)
        {
            _context = context;
        }

        public void Add(Domain.Models.Conta conta)
        {
            _context.Conta.Add(conta);

            _context.SaveChanges();
        }

        public async Task<IEnumerable<Domain.Models.Conta>> GetAll()
        {
            return await _context.Conta.AsNoTracking().ToListAsync();
        }
    }
}
