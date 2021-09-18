using System;

namespace Conta.Application.Listagem.Dtos
{
    public class ContaDto
    {
        public string Nome { get; set; }

        public decimal ValorOriginal { get; set; }

        public decimal ValorCorrigido { get; set; }

        public int DiasAtraso { get; set; }

        public DateTime DataPagamento { get; set; }
    }
}
