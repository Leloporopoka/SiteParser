using Application.Dtos;
using Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Queries.PersonQueryies
{
    public class GetPersonsQueryHandler : IRequestHandler<GetPersonsQuery, List<PersonDto>>
    {
        private readonly IPersonQueryRepository _repository;
        public GetPersonsQueryHandler(IPersonQueryRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<PersonDto>> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetList();
        }
    }
}
