using BookStore.Model;
using BookStore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromForm] SignupModel signUpModel)

        {
            var result = await _accountRepository.SignUpAsync(signUpModel);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] SignInModel signInModel)

        {
            var result = await _accountRepository.LoginAsync(signInModel);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }

    }
}
