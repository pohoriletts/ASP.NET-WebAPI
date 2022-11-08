using BusinessLogic.DTOs;
using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using BusinessLogic.Resources;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountServices(UserManager<IdentityUser> user,
                                SignInManager<IdentityUser> signInManager)
        {
            this.userManager = user;
            this.signInManager = signInManager;
        }
        public async Task SignUp(SignUpDTO data)
        {
            var user = new IdentityUser()
            {
                Email = data.Email,
                UserName=data.Email,
                PhoneNumber = data.Phone,
            };

            var result = await userManager.CreateAsync(user, data.Password);

            if (!result.Succeeded)
            {
                string errors = string.Join(", ",result.Errors.Select(e => e.Description).ToList());
                throw new HttpException(errors, System.Net.HttpStatusCode.BadRequest);
            }
        }
        public async Task SignIn(string email, string password)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null || !await userManager.CheckPasswordAsync(user, password))
            {
                throw new HttpException(ErrorMessages.InvalidCredentials, System.Net.HttpStatusCode.BadRequest);
            }
            await signInManager.SignInAsync(user, true);
        }
        public async Task SignOut()
        {
            await signInManager.SignOutAsync();
        }
    }
}
