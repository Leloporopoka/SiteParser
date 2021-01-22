using Application.Dtos;
using Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Queries.NewsQueryies
{
    public class GetNewsBySearchWordHandler : IRequestHandler<GetNewsBySearchWord, List<NewsDto>>
    {
        readonly INewsQueryRepository _repository;
        public GetNewsBySearchWordHandler(INewsQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<NewsDto>> Handle(GetNewsBySearchWord request, CancellationToken cancellationToken)
        {
            var newsDtos = new List<NewsDto>();
            var news = _repository.GetNewsBySearchWord(request.SearchWord);
            foreach (var item in news)
            {
                newsDtos.Add(new NewsDto { Title = item.Title, Text = item.Text, Date = item.Date });
            }
            return newsDtos;
        }
    }
}
