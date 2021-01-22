using Application.Handlers.Commands.NewsCommands;
using Application.Handlers.Queries.NewsQueryies;
using Client.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Services;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class NewsController : Controller
    {
        private SiteParserService _parserService;
        private readonly IMediator _mediator;
        public NewsController(SiteParserService parserService, IMediator mediator)
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

        [HttpPost("GetNewsByDateRange")]
        public async Task<IActionResult> GetNewsByDateRange([FromBody] DateRangeModel model)
        {
            var news = await _mediator.Send(new GetNewsByDateRangeQuery 
            { 
                StartDate = model.StartDate, 
                EndDate = model.EndDate 
            });
            return Ok(news);
        }
        [HttpPost("GetNewsBySearchWord")]
        public async Task<IActionResult> GetNewsBySearchWord([FromBody] string searchWord)
        {
            var news = await _mediator.Send(new GetNewsBySearchWord
            {
                SearchWord = searchWord
            });
            return Ok(news);
        }

        [HttpGet("GetTopTenFrequentWords")]
        public async Task<IActionResult> GetTopTenFrequentWords()
        {
            var words = await _mediator.Send(new GetTopTenFrequentWordsQuery());
            return Ok(words);
        }
    }
}
