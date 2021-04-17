using MediatR;
using System;

namespace Application.Handlers.Commands.PersonCommands
{
    public class DeletePersonCommand : IRequest<Guid>
    {
        public Guid PersonId { get; set; }
    }
}
