using Conta.Domain.Enums;

namespace Conta.Domain.Models.RegrasMulta
{
    public class Superior5DiasAtraso : RegraCalculoMulta
    {
        protected override decimal PorcentagemMulta => 5;

        protected override decimal JurosPorDia => 0.3m;

        public override TipoRegra Tipo => TipoRegra.Superior5DiasAtraso;
    }
}
