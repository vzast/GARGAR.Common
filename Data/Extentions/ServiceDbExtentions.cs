using Data.Repositories;
using Data.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Extentions
{
    public static class ServiceDbExtentions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}