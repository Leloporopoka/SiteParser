using Application.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Database.Repositories
{
    class NewsQueryRepository : INewsQueryRepository
    {
        readonly NewsContext _context;
        public NewsQueryRepository(NewsContext context)
        {
            _context = context;
        }

        public List<News> GetNewsByDateRange(DateTime StardDate, DateTime EndDate)
        {
            return _context.News.Where(n => n.Date >= StardDate && n.Date <= EndDate).ToList();
        }

        public List<News> GetNewsBySearchWord(string SearchWord)
        {
            var news = _context.News.ToList();
            return news.Where(n => n.Text.Contains(SearchWord, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<string> GetTop10FrequentWords()
        {
            var texts = _context.News.Select(s => s.Text).ToList();
            var result = texts.GroupBy(s => s).Where(g => g.Count() > 1).OrderByDescending(g => g.Count()).Select(g => g.Key);
        }
    }
}
