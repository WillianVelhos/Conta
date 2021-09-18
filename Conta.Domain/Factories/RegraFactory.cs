using Conta.Domain.Models.RegrasMulta;

namespace Conta.Domain.Factories
{
    public static class RegraFactory
    {
        public static RegraCalculoMulta Criar(int diasAtraso)
        {
            return diasAtraso switch
            {
                0 => new SemAtraso(),
                <= 3 => new Ate3DiasAtraso(),
                <= 5 => new Superior3DiasAtraso(),
                > 5 => new Superior5DiasAtraso(),
            };
        }
    }
}
