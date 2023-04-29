using Microsoft.AspNetCore.Identity;
using Shared.DTO;

namespace Domain.User.Auth
{
    public interface IUserAuthenticationService
    {
        public Task<IdentityResult> SignUp(SignUpDTO request);

        public Task<(SignInResult SignInResult, Data.Models.Public.User User)> SignIn(LoginDTO request);
    }
}