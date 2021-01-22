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

                var nodes = htmlCodument.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals("news_block")).FirstOrDefault();
                var items = nodes.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals("news_section_item-left")).ToList();
                items.RemoveAt(items.Count - 1);

                foreach (var item in items)
                {
                    var title = item.Descendants("a").Where(i => i.GetAttributeValue("class", "").Equals("news_section_title")).FirstOrDefault().InnerText;
                    var date = item.Descendants("time").Where(i => i.GetAttributeValue("class", "").Equals("news_date")).FirstOrDefault().InnerText;
                    date = date.Replace(",", string.Empty);
                    var text = item.Descendants("p").Where(i => i.GetAttributeValue("class", "").Equals("post_text")).FirstOrDefault().InnerText;
                    news.Add(new NewsDto
                    {
                        Title = title,
                        Text = text,
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
