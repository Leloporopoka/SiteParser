using Application.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Application.Handlers.Queries.PersonQueryies
{
    public class GetPersonsQuery : IRequest<List<PersonDto>>
    {
    }
}
