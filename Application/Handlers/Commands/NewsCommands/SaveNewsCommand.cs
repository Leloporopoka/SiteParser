using Application.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Application.Handlers.Commands.NewsCommands
{
    public class SaveNewsCommand : IRequest<bool>
    {
        public List<NewsDto> News { get; set; }
    }
}
