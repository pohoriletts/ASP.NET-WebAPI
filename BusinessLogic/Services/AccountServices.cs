using Core.Helpers;
using Core.DTOs;
using Core.Exceptions;
using Core.Interfaces;
using Core.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Net;

namespace Core.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IConfiguration configuration;

        public AccountServices(UserManager<IdentityUser> user,
                                SignInManager<IdentityUser> signInManager,
                                IConfiguration configuration)
        {
            userManager = user;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }
        public async Task SignUp(SignUpDTO data)
        {
            var user = new IdentityUser()
            {
                Email = data.Email,
                UserName = data.Email,
                PhoneNumber = data.Phone
            };

            var result = await userManager.CreateAsync(user, data.Password);

            if (!result.Succeeded)
            {
                string errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new HttpException(errors, HttpStatusCode.BadRequest);
            }
        }
        public async Task<SignInResponseDTO> SignIn(string email, string password)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null || !await userManager.CheckPasswordAsync(user, password))
            {
                throw new HttpException(ErrorMessages.InvalidCredentials, HttpStatusCode.BadRequest);
            }
            await signInManager.SignInAsync(user, true);
            return new SignInResponseDTO()
            {
                Email = email,
                Token = await GenerateTokenAsync(user)
            };
        }
        public async Task SignOut()
        {
            await signInManager.SignOutAsync();
        }
        private async Task<string> GenerateTokenAsync(IdentityUser user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();
            var key = Encoding.ASCII.GetBytes(jwtOptions.Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = jwtOptions.Issuer,
                Expires = DateTime.UtcNow.AddHours(jwtOptions.Lifetime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
