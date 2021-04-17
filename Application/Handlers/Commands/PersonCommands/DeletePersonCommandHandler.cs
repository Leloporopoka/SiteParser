using Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Commands.PersonCommands
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, Guid>
    {
        private readonly IPersonCommandRepository _repository;
        public DeletePersonCommandHandler(IPersonCommandRepository repository)
        {
            _repository = repository;
        }
        public async Task<Guid> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            _repository.Delete(request.PersonId);
            return request.PersonId;
        }
    }
}
