using Conta.Application.Inclusao;
using Conta.Application.Listagem;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Conta.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IContaService _contaService;

        public ContaController(IMediator mediator, IContaService contaService)
        {
            _mediator = mediator;
            _contaService = contaService;
        }

        [HttpPost("incluir")]
        public async Task<ActionResult> Incluir(InclusaoCommand command)
        {
            var restaurante = await _mediator.Send(command);

            return Ok(restaurante);
        }

        [HttpGet("listar")]
        public async Task<ActionResult> Listar()
        {
            return Ok(await _contaService.Listar());
        }
    }
}
