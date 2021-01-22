using Application.Dtos;
using Client.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
            await _httpCLient.GetAsync("api/News/GetNewsAndSave");
        }
        public async Task<List<NewsDto>> GetNewsByDateRange(DateRangeModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var httpContent = stringContent;
            var response = await _httpCLient.PostAsync("api/News/GetNewsByDateRange", httpContent);
            var responseMessage = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<NewsDto>>(responseMessage);
            return result;
        }
        public async Task<List<NewsDto>> GetNewsBySearchWord(string searchWord)
        {
            var json = JsonConvert.SerializeObject(searchWord);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var httpContent = stringContent;
            var response = await _httpCLient.PostAsync("api/News/GetNewsBySearchWord", httpContent);
            var responseMessage = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<NewsDto>>(responseMessage);
            return result;
        }

        public async Task<List<string>> GetTopTenFrequentWords()
        {
            var response = await _httpCLient.GetAsync("api/News/GetTopTenFrequentWords");
            var responseMessage = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<string>>(responseMessage);
            return result;
        }
    }
}
