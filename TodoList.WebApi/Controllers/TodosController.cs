using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.WebApi.Interfaces.Services;
using TodoList.WebApi.Utils;
using TodoList.WebApi.ViewModels.Todos;

namespace TodoList.WebApi.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoService _service;
        public TodosController(ITodoService service)
        {
            this._service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        {
            var result = await _service.GetAllAsync(@params);
            return Ok(result);
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<IActionResult> GetAsync(long id)
        {
            var result = await _service.GetAsync(id);
            return StatusCode(result.statusCode, result.todo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] TodoCreateViewModel todoCreareViewModel)
        {
            var result = await _service.CreateAsync(todoCreareViewModel);
            return StatusCode(result.statusCode, result.message);
        }

        [HttpPut("{id}"), AllowAnonymous]
        public async Task<IActionResult> UpdateAsync(long id, [FromForm] TodoCreateViewModel todoCreareViewModel)
        {
            var result = await _service.UpdateAsync(id, todoCreareViewModel);
            return StatusCode(result.statusCode, result.message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var result = await _service.DeleteAsync(id);
            return StatusCode(result.statusCode, result.message);
        }
    }
}
