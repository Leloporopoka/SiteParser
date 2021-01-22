
using Application.Dtos;
using MediatR;
using System.Collections.Generic;


namespace Application.Handlers.Queries.NewsQueryies
{
    public class GetNewsBySearchWord : IRequest<List<NewsDto>>
    {
        public string SearchWord { get; set; }
    }
}
