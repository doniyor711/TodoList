using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.WebApi.Interfaces.Services;
using TodoList.WebApi.ViewModels.Users;

namespace TodoList.WebApi.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _service;
        public AccountsController(IAccountService service)
        {
            this._service = service;
        }

        [HttpPost("registr"), AllowAnonymous]
        public async Task<IActionResult> RegistrAsync([FromForm]UserCreateViewModel userCreateViewModel)
        {
            var result = await _service.RegistrAsync(userCreateViewModel);
            return StatusCode(result.statusCode, result.message);
        }

        [HttpPost("login"), AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromForm] UserLoginViewModel userLoginViewModel)
        {
            return Ok();
        }
    }
}
