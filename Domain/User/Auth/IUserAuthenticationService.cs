using Microsoft.AspNetCore.Identity;
using Shared.DTO;
using Data.Models.Public;

namespace Domain.User.Auth
{
    public interface IUserAuthenticationService
    {
        public Task<IdentityResult> SignUp(SignUpDTO request);
        public Task<(SignInResult SignInResult, Data.Models.Public.User User)> SignIn(LoginDTO request);
    }
}