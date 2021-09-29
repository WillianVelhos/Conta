using Microsoft.EntityFrameworkCore;
using domainModels = Conta.Domain.Models;

namespace Conta.Data
{
    public class ContaContext : DbContext
    {
        public ContaContext(DbContextOptions<ContaContext> options)
            : base(options) { }

        public DbSet<domainModels.Conta> Conta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContaMapping());
        }
    }
}
