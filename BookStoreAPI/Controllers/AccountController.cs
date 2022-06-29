using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStoreAPI.Repository;
using System.Threading.Tasks;
using BookStoreAPI.Data.Models;

namespace BookStoreAPI.Controllers
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
        public async Task<IActionResult> SignUp([FromBody] SignUp signUpModel)
        {
            var result = await _accountRepository.SignUpAsync(signUpModel);

            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogIn([FromBody] SignIn signInModel)
        {
            var result = await _accountRepository.LoginAsync(signInModel);

            return result == null ? Unauthorized(result) : Ok(result);
        }
    }
}
