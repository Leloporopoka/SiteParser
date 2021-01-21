
using System;
using System.Net.Http;


namespace Client.Services
{
    public class NewsService
    {
        private HttpClient _httpCLient { get; set; }

        public NewsService(HttpClient httpClient)
        {
            _httpCLient = httpClient;
        }

        public async void GetNewsAndSave()
        {
            Console.WriteLine("Save");
            await _httpCLient.GetAsync("api/SiteParser/GetNewsAndSave");
        }
    }
}
