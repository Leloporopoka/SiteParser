using MediatR;
using System;

namespace Application.Handlers.Commands.PersonCommands
{
    public class AddPersonCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}
