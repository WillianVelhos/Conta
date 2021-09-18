using Conta.Domain.Enums;

namespace Conta.Domain.Models.RegrasMulta
{
    public class RegraCalculoMulta
    {
        protected virtual decimal PorcentagemMulta { get; }

        protected virtual decimal JurosPorDia { get; }

        public virtual TipoRegra Tipo { get; private set; }

        public decimal Calcular(decimal valorOriginal, int diasAtraso)
        {
            var valorMulta = (valorOriginal * PorcentagemMulta) / 100;
            var valorJurosDiario = (valorOriginal * JurosPorDia) / 100;

            return valorOriginal + valorMulta + (valorJurosDiario * diasAtraso);
        }
    }
}
