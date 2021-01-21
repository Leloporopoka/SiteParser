using System;

namespace Domain.Models
{
    public class News
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public string Text { get; private set; }
        public DateTime Date { get; private set; }

        private News()
        {

        }
        public News(string title, string text, DateTime date)
        {
            Title = title;
            Text = text;
            Date = date;
        }
    }
}
