using Application.Interfaces;
using Database.Repositories;
using Database.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Database
{
    public static  class DependencyInjection
    {
        public static void AddDatabase(this IServiceCollection services)
        {
            services.AddScoped<IPersonCommandRepository, PersonCommandRepository>();
            services.AddScoped<IPersonQueryRepository, PersonQueryRepository>();
            services.AddSingleton<DatabaseService>();
        }
    }

}
