using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Queries.NewsQueryies
{
    public class GetTopTenFrequentWordsQueryHandler : IRequestHandler<GetTopTenFrequentWordsQuery, List<string>>
    {
        readonly INewsQueryRepository _repository;
        public GetTopTenFrequentWordsQueryHandler(INewsQueryRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<string>> Handle(GetTopTenFrequentWordsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return _repository.GetTopTenFrequentWords();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.Message);
                return new List<string>();
            }
        }
    }
}
