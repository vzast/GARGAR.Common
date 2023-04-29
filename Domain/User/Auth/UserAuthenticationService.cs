using Data.Repositories.Interfaces;
using Email;
using Email.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Shared.DTO;
using Data.Models.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User.Auth
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        public readonly IUserRepository _user;
        private readonly IConfiguration _configuration;
        private readonly EmailService _email;
        public UserAuthenticationService(IUserRepository user, IConfiguration configuration, EmailService email)
        {
            _user = user;
            _configuration = configuration;
            _email = email;
        }

        /// <summary>
        /// Signs Up user 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IdentityResult> SignUp(SignUpDTO request)
        {
            return await _user.SignUp(request);
        }

        /// <summary>
        /// trying to Sign in Specific user,
        /// in case of Locking Out Sends email notification 
        /// to specidffic user who is found by his email ro username
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Returns SignInResult to continue validation in controller for creating token</returns>
        public async Task<(SignInResult, Data.Models.Public.User)> SignIn(LoginDTO request)
        {
            var DbResponse = await _user.LogIn(request);
            Data.Models.Public.User user = null;
            user = await _user.GetUserByEmailOrUsername(request.EmailOrUsername);
            if (DbResponse == SignInResult.LockedOut)
            {
                var model = new EmailModel
                {
                    Subject = "Locked Out",
                    Email = user.NormalizedEmail,
                    FirstName = user.Firstname,
                    LastName = user.Lastname,
                    Body = "unfortunately your account has been locked out,\nto unlock Account please contact Chat Support"
                };
                await _email.SendAsync(model);
            }
            return (DbResponse, user);
        }
    }
}
