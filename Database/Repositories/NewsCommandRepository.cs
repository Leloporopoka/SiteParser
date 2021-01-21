

using Application.Interfaces;
using Domain.Models;
using System.Collections.Generic;

namespace Database.Repositories
{
    public class NewsCommandRepository : INewsCommandRepository
    {
        readonly NewsContext _context;
        public NewsCommandRepository(NewsContext context)
        {
            _context = context;
        }
        public void AddNews(List<News>news)
        {
            foreach (var item in news)
            {
                _context.Add(item);
            }
            _context.SaveChanges();
        }
    }
}
