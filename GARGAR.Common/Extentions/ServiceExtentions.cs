using Data.Repositories;
using Data.Repositories.Interfaces;
using Domain.User.Auth;
using Email;
using Email.Settings;

namespace GARGAR.Common.Extentions
{
    public static class ServiceExtentions
    {
        //Why? 
        //Idk )
        /// <summary>
        /// adds EmailService as Singleton
        /// </summary>
        /// <param name="services"> IServiceCollection </param>
        public static void AddEmail(this IServiceCollection services)
        {
            services.AddSingleton<EmailService>();
        }
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserAuthenticationService, UserAuthenticationService>();
        }
        public static void AddRepositoryes(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository,UserRepository>();
        }

    }
}
