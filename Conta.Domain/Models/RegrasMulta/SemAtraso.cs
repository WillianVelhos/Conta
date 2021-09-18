using Conta.Domain.Enums;

namespace Conta.Domain.Models.RegrasMulta
{
    public class SemAtraso : RegraCalculoMulta
    {
        protected override decimal PorcentagemMulta => 0;

        protected override decimal JurosPorDia => 0;

        public override TipoRegra Tipo => TipoRegra.SemAtraso;
    }
}
