using Domain.Models;
using System;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface INewsQueryRepository
    {
        public List<News> GetNewsByDateRange(DateTime StardDate, DateTime EndDate);
        public List<News> GetNewsBySearchWord(string SearchWord);
        public List<string> GetTopTenFrequentWords();
    }
}
