using Application.Dtos;
using Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services
{
    public class HttpService
    {
        private HttpClient _httpCLient { get; set; }

        public HttpService(HttpClient httpClient)
        {
            _httpCLient = httpClient;
        }

        public async Task<Guid> Add(PersonModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var httpContent = stringContent;
            var response = await _httpCLient.PostAsync("api/Person/Add", httpContent);
            var responseMessage = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Guid>(responseMessage);
            return result;
        }
        public async Task<Guid> Delete(Guid id)
        {
            var response = await _httpCLient.DeleteAsync($"api/Person/{id}");
            var responseMessage = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Guid>(responseMessage);
            return result;
        }

        public async Task<List<PersonDto>> Take()
        {
            var response = await _httpCLient.GetAsync("api/Person/Take");
            var responseMessage = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<PersonDto>>(responseMessage);
            return result;
        }
    }
}
