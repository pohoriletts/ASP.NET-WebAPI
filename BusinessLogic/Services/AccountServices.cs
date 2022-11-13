using Core.DTOs;
using Core.Exceptions;
using Core.Interfaces;
using Core.Resources;
using Microsoft.AspNetCore.Identity;

namespace Core.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountServices(UserManager<IdentityUser> user,
                                SignInManager<IdentityUser> signInManager)
        {
            userManager = user;
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
