using Data.Models.Public;
using Microsoft.AspNetCore.Identity;
using Shared.DTO;

namespace Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> GetUserByEmailOrUsername(string EmailOrUsername);

        public Task<SignInResult> LogIn(LoginDTO request);

        public Task<IdentityResult> SignUp(SignUpDTO request);
    }
}