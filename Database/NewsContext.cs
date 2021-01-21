using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class NewsContext : DbContext
    {
        public DbSet<News> News { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=Blogging;Integrated Security=True");
        }

    }
}
