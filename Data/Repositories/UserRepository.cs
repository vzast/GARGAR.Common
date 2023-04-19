
using Data.Repositories.Interfaces;
using Data.Models.Public;
using Microsoft.AspNetCore.Identity;
using Shared.DTO;

namespace Data.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly UserManager<User> userManager;

        public UserRepository(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        

        public async Task SignUp(UserRegistrationDTO request)
        {
            var user = new User()
            {
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                Email = request.Email,
            };
            await userManager.CreateAsync(user, request.Password);
        }
    }
}
