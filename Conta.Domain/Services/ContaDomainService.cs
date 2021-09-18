using Conta.Domain.Factories;

namespace Conta.Domain.Services
{
    public class ContaDomainService
    {
        public void CalcularValorCorrigido(Models.Conta conta)
        {
            var regra = RegraFactory.Criar(conta.DiasAtraso);

            conta.AtribuirRegra(regra);
        }
    }
}
