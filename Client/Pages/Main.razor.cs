using Application.Dtos;
using Client.Models;
using Client.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Pages
{
    public class MainBase : ComponentBase
    {
        [Inject]
        public NewsService NewsService { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<NewsDto> News { get; set; } = new List<NewsDto>();
        public List<string> FrequentWords { get; set; } = new List<string>();
        public string SearchWord { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }
        public void StartDateChanged(DateTime date)
        {
            StartDate = date;
        }
        public void EndDateChanged(DateTime date)
        {
            EndDate = date;
        }

        public void GetSiteInfoAndSave()
        {
            NewsService.GetNewsAndSave();
        }
        public async Task GetNewsByDateRangeAsync()
        {
            News = await NewsService.GetNewsByDateRange(new DateRangeModel { StartDate = StartDate, EndDate = EndDate });
        }
        public async Task GetNewsBySearchWordAsync()
        {
            News = await NewsService.GetNewsBySearchWord(SearchWord);
        }
        public async Task GetTopTenFrequentWords()
        {
            FrequentWords = await NewsService.GetTopTenFrequentWords();
        }
    }
}
