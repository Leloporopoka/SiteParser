using Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;

namespace Application.Handlers.Queries.NewsQueryies
{
   public class GetNewsByDateRangeQuery : IRequest<List<NewsDto>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
