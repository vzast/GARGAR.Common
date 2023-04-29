
using Data.Repositories.Interfaces;
using Data.Models.Public;
using Microsoft.AspNetCore.Identity;
using Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;


        public UserRepository(UserManager<User> userManager , SignInManager<User> signInManager )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        #region Auth

        public async Task<IdentityResult> SignUp(SignUpDTO request)
        {
            var user = new User()
            {
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                Email = request.Email,
                UserName = request.UserName
            };
            return await _userManager.CreateAsync(user, request.Password);
        }

        public async Task<SignInResult> LogIn(LoginDTO request)
        {
            var user = await GetUserByEmailOrUsername(request.EmailOrUsername);
            var resonse = await _signInManager.PasswordSignInAsync(user, request.Password,request.isPersist,false);
            return resonse;
        }


        #endregion

        #region Get

        public async Task<User> GetUserByEmailOrUsername(string EmailOrUsername)
        {
            var user = await _userManager.Users.
                Where(u => u.NormalizedUserName.Contains(EmailOrUsername.ToLower()) || u.NormalizedEmail.Contains(EmailOrUsername.ToLower()))
                .FirstOrDefaultAsync();
            if (user is null)
            {
                throw new ArgumentNullException($"User With {EmailOrUsername} was not found");
            }
            return user;
        }
        #endregion
    }
}
