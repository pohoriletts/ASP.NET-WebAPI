using Core.DTOs;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApiMono.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountServices _services;
        public AccountController(IAccountServices accountServices)
        {
            _services = accountServices;
        }
        [HttpPost("/SignUp")] public async Task<IActionResult> SignUp([FromBody]SignUpDTO data)
        {
            await _services.SignUp(data);
            return Ok();
        }

        [HttpPost("/SignIn")] public async Task<IActionResult> SignIn([FromBody] SignInDTO data)
        {
            var response = await _services.SignIn(data.Email, data.Password);
            return Ok(response);
        }

        [HttpPost("/SignOut")] public async Task<IActionResult> SignOut()
        {
            await _services.SignOut();
            return Ok();
        }
    }
}
