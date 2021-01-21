using Application.Dtos;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Server.Services
{
    public class SiteParserService
    {
        private HttpClient _httpCLient { get; set; }

        public SiteParserService(HttpClient httpClient)
        {
            _httpCLient = httpClient;
        }

        public async Task<List<NewsDto>> GetNewsFromSite()
        {
            try
            {
                var news = new List<NewsDto>();
                var url = "http://today.kz/";
                var html = await _httpCLient.GetStringAsync(url);
                var htmlCodument = new HtmlDocument();
                htmlCodument.LoadHtml(html);

                foreach (HtmlNode node in htmlCodument.DocumentNode.SelectNodes("//div[@class='" + "news_section-item" + "']"))
                {
                    var date = node.SelectNodes("//time[@class='" + "news_date" + "']").First().InnerText;
                    date = date.Replace(",", string.Empty);

                    news.Add(new NewsDto
                    {
                        Title = node.SelectNodes("//a[@class='" + "news_section_title" + "']").First().InnerText,
                        Text = node.SelectNodes("//p[@class='" + "post_text" + "']").First().InnerText,
                        Date = DateTime.Parse(date, CultureInfo.CreateSpecificCulture("fr-FR"))
                    });
                }
                return news;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return new List<NewsDto>();
            }
        }
    }
}
