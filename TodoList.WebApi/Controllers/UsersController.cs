using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.WebApi.Utils;
using TodoList.WebApi.ViewModels.Users;

namespace TodoList.WebApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        {
            return Ok();
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<IActionResult> GetAsync(long id)
        {
            return Ok();
        }

        [HttpGet("{id}/todos")]
        public async Task<IActionResult> GetAllTodosAsync(long id)
        {
            return Ok();
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateAsync(long id, [FromForm] UserUpdateViewModel userUpdateViewModel)
        {
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            return Ok();
        }
    }
}
