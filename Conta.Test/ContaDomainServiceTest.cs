using Conta.Domain.Services;
using System;
using Xunit;

namespace Conta.Test
{
    public class ContaDomainServiceTest
    {
        private readonly ContaDomainService _contaDomainService;

        public ContaDomainServiceTest()
        {
            _contaDomainService = new();
        }

        [Fact]
        public void ContaComSemAtraso_DeveRetornarValorCorrigidoCorreto()
        {
            //arrage
            var conta = new Domain.Models.Conta("Luz", 100, new DateTime(2021, 09, 18), new DateTime(2021, 09, 18));

            //action
            _contaDomainService.CalcularValorCorrigido(conta);

            //assert

            Assert.Equal(100, conta.ValorCorrigido);
        }

        [Fact]
        public void ContaComUmDiaDeAtraso_DeveRetornarValorCorrigidoCorreto()
        {
            //arrage
            var conta = new Domain.Models.Conta("Luz", 100, new DateTime(2021, 09, 17), new DateTime(2021, 09, 18));

            //action
            _contaDomainService.CalcularValorCorrigido(conta);

            //assert

            Assert.Equal(102.1m, conta.ValorCorrigido);
        }

        [Fact]
        public void ContaComQuatroDiaDeAtraso_DeveRetornarValorCorrigidoCorreto()
        {
            //arrage
            var conta = new Domain.Models.Conta("Luz", 100, new DateTime(2021, 09, 14), new DateTime(2021, 09, 18));

            //action
            _contaDomainService.CalcularValorCorrigido(conta);

            //assert

            Assert.Equal(103.8m, conta.ValorCorrigido);
        }

        [Fact]
        public void ContaComSeisDiaDeAtraso_DeveRetornarValorCorrigidoCorreto()
        {
            //arrage
            var conta = new Domain.Models.Conta("Luz", 100, new DateTime(2021, 09, 12), new DateTime(2021, 09, 18));

            //action
            _contaDomainService.CalcularValorCorrigido(conta);

            //assert

            Assert.Equal(106.8m, conta.ValorCorrigido);
        }

    }
}
