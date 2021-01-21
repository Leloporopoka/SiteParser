using Application.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Application.Handlers.Commands.News
{
    public class SaveNewsCommand : IRequest<bool>
    {
        public List<NewsDto> News { get; set; }
    }
}
