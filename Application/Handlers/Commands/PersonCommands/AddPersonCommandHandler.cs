using Application.Dtos;
using Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands.PersonCommands
{
    public class AddPersonCommandHandler : IRequestHandler<AddPersonCommand, Guid>
    {
        private readonly IPersonCommandRepository _repository;
        public AddPersonCommandHandler(IPersonCommandRepository repository)
        {
            _repository = repository;
        }
        public async Task<Guid> Handle(AddPersonCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            var dto = new PersonDto { Id = id, Name = request.Name, Surname = request.Surname, Age = request.Age };
            _repository.Add(dto);
            return id;
        }
    }
}
