using MediatR;
using System.Collections.Generic;

namespace Application.Handlers.Queries.NewsQueryies
{
    public class GetTopTenFrequentWordsQuery : IRequest<List<string>>
    {
    }
}
