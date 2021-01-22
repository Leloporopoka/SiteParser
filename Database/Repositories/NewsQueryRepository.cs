using Application.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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

        public List<string> GetTopTenFrequentWords()
        {
            var texts = _context.News.Select(s => s.Text).ToList();
            string totalText = "";
            texts.ForEach(text => totalText += text + " ");
            var result = Regex.Split(totalText.ToLower(), @"\W+")
                 .Where(s => s.Length > 3)
                 .GroupBy(s => s)
                 .OrderByDescending(g => g.Count()).Take(10);
            return result.Select(r => r.Key).ToList();
        }
    }
}
