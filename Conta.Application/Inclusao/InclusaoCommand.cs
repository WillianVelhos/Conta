using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Conta.Application.Inclusao
{
    public class InclusaoCommand : IRequest<InclusaoCommandResult>
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Valor Original é obrigatório")]
        public decimal ValorOriginal { get; set; }

        [Required(ErrorMessage = "DataVencimento é obrigatório")]
        public DateTime DataVencimento { get; set; }

        [Required(ErrorMessage = "DataPagamento é obrigatório")]
        public DateTime DataPagamento { get; set; }
    }
}
