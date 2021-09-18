using Conta.Domain.Enums;

namespace Conta.Domain.Models.RegrasMulta
{
    public class Ate3DiasAtraso : RegraCalculoMulta
    {
        protected override decimal PorcentagemMulta => 2;

        protected override decimal JurosPorDia => 0.1m;

        public override TipoRegra Tipo => TipoRegra.Ate3DiasAtraso;
    }
}
