using Application.Interfaces;
using Database.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Database
{
    public static  class DependencyInjection
    {
        public static void AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<NewsContext>();
            services.AddScoped<INewsCommandRepository, NewsCommandRepository>();

        }
    }

}
