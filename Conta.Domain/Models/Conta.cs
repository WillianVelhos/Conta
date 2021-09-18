using Conta.Domain.Models.RegrasMulta;
using System;

namespace Conta.Domain.Models
{
    public class Conta
    {
        public int? _diasAtraso;

        protected Conta() { }

        public Conta(string nome, decimal valorOriginal, DateTime dataVencimento, DateTime dataPagamento)
        {
            Nome = nome;
            ValorOriginal = valorOriginal;
            DataVencimento = dataVencimento;
            DataPagamento = dataPagamento;
        }

        public long Id { get; }

        public string Nome { get; }

        public decimal ValorOriginal { get; }

        public DateTime DataVencimento { get; }

        public DateTime DataPagamento { get; }

        public decimal ValorCorrigido { get; private set; }

        public int DiasAtraso
        {
            get
            {
                if (_diasAtraso == null)
                    _diasAtraso = CalcularDiasAtraso();

                return _diasAtraso.Value;
            }
        }

        public RegraCalculoMulta Regra { get; private set; }

        public void AtribuirRegra(RegraCalculoMulta regra)
        {
            Regra = regra;

            ValorCorrigido = Regra.Calcular(ValorOriginal, DiasAtraso);
        }

        private int CalcularDiasAtraso()
        {
            return (DataPagamento - DataVencimento).Days;
        }
    }
}
