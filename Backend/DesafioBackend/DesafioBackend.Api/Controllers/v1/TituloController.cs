using DesafioBackend.Data.Query.Queries.v1.Titulo.Get;
using DesafioBackend.Domain.Commands.v1.Titulo.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Serilog;
using System.Threading.Tasks;

namespace DesafioBackend.Api.Controllers.v1
{
    [Route("api/v1/titulo")]
    public class TituloController : BaseController<TituloController>
    {
        public TituloController(ILogger logService, IMediator mediatorService, IConfiguration configuration)
            : base(logService, mediatorService, configuration)
        { }

        [HttpGet]
        public async Task<IActionResult> GetDividas(GetTituloQuery query)
        {
            return await GenerateResponseAsync(async () => await MediatorService.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTitulo(CreateTituloCommand command)
        {
            return await GenerateResponseAsync(async () => await MediatorService.Send(command));
        }
    }
}
