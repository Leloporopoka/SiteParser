using Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using Domain.Models;
using System.Threading.Tasks;

namespace Application.Handlers.Commands.NewsCommands
{
    public class SaveNewsCommandHandler : IRequestHandler<SaveNewsCommand, bool>
    {
        readonly INewsCommandRepository _repository;
        public SaveNewsCommandHandler(INewsCommandRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(SaveNewsCommand request, CancellationToken cancellationToken)
        {
            var news = new List<News>();
            request.News.ForEach(item => news.Add(new News(item.Title, item.Text, item.Date)));
            _repository.AddNews(news);
            return true;
        }
    }
}
