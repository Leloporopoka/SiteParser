using Application.Dtos;
using Application.Interfaces;
using MediatR;
using System;
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
            try
            {
                var newsDtos = new List<NewsDto>();
                var news = _repository.GetNewsBySearchWord(request.SearchWord);
                news.ForEach(item => newsDtos.Add(new NewsDto { Title = item.Title, Text = item.Text, Date = item.Date }));
                return newsDtos;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.Message);
                return new List<NewsDto>();
            }
        }
    }
}
