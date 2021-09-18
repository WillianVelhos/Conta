using Conta.Domain.Enums;

namespace Conta.Domain.Models.RegrasMulta
{
    public class Superior3DiasAtraso : RegraCalculoMulta
    {
        protected override decimal PorcentagemMulta => 3;

        protected override decimal JurosPorDia => 0.2m;

        public override TipoRegra Tipo => TipoRegra.Superior3DiasAtraso;

    }
}
