using Application.Dtos;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Queries.NewsQueryies
{
    public class GetNewsByDateRangeQueryHandler : IRequestHandler<GetNewsByDateRangeQuery, List<NewsDto>>
    {
        readonly INewsQueryRepository _repository;
        public GetNewsByDateRangeQueryHandler(INewsQueryRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<NewsDto>> Handle(GetNewsByDateRangeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var newsDtos = new List<NewsDto>();
                var news = _repository.GetNewsByDateRange(request.StartDate, request.EndDate);
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
