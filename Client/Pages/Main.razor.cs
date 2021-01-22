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
        public List<NewsDto> News { get; set; }

        public string SearchWord { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            News = new List<NewsDto>();
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
    }
}
