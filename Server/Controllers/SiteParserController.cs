using Application.Handlers.Commands.News;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Services;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class SiteParserController : Controller
    {
        private SiteParserService _parserService;
        private readonly IMediator _mediator;
        public SiteParserController(SiteParserService parserService, IMediator mediator)
        {
            _parserService = parserService;
            _mediator = mediator;
        }
        [HttpGet("GetNewsAndSave")]
        public async Task<IActionResult> GetNewsAndSave()
        {
            var status = await _mediator.Send(new SaveNewsCommand
            {
                News = await _parserService.GetNewsFromSite()
            });
            return Ok(status);
        }
    }
}
