using Domain.Models;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface INewsCommandRepository
    {
        public void AddNews(List<News> news);
    }
}
