using Application.Handlers.Commands.PersonCommands;
using Application.Handlers.Queries.PersonQueryies;
using Client.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class PersonController : Controller
    {
        private readonly IMediator _mediator;
        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedId = await _mediator.Send(new DeletePersonCommand
            {
                PersonId = id
            });
            return Ok(deletedId);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] PersonModel model)
        {
            var id = await _mediator.Send(new AddPersonCommand
            {
               Name = model.Name,
               Surname = model.Surname,
               Age = model.Age
            });
            return Ok(id);
        }
        [HttpGet("Take")]
        public async Task<IActionResult> Take()
        {
            var persons = await _mediator.Send(new GetPersonsQuery());
            return Ok(persons);
        }
    }
}
