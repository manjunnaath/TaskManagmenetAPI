using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.Data;
using TaskManagementAPI.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace TaskManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TaskController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<TaskController> _logger;

        public TaskController(AppDbContext context, ILogger<TaskController> @object)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskManagementAPI.Models.Task task)
        {
            //_logger.LogInformation("CreateTask endpoint hit.");
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            //_logger.LogInformation("CreateTask endpoint completed.");
            return Ok(task);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RetrieveTask(int id)
        {
            //_logger.LogInformation("Retrieve endpoint hit.");
            var task = await _context.Tasks.FindAsync(id);
            if (task == null || (User.IsInRole("User") && task.AssignedUserId != User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return Forbid();
            }
            //_logger.LogInformation("Retrieve endpoint completed.");
            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskDetails(int id, [FromBody] TaskManagementAPI.Models.Task updatedTask)
        {
            //_logger.LogInformation("UpdateTaskDetails endpoint hit.");
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            if (User.IsInRole("Admin"))
            {
                task.Title = updatedTask.Title;
                task.Description = updatedTask.Description;
                task.Status = updatedTask.Status;
            }
            else if (User.IsInRole("User") && task.AssignedUserId == User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                task.Status = updatedTask.Status;
            }
            else
            {
                return Forbid();
            }

            await _context.SaveChangesAsync();
            //_logger.LogInformation("UpdateTaskDetails endpoint hit.");
            return Ok(task);
        }

       // [Authorize(Policy = "AdminPolicy")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            //_logger.LogInformation("DeleteTasks endpoint hit.");
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            //_logger.LogInformation("DeleteTasks endpoint completed.");
            return Ok();
        }

        //[Authorize(Roles = "Admin") ]
        [HttpGet("list")]
        public IActionResult ListAllTasks()
        {
            //_logger.LogInformation("ListAllTasks endpoint hit.");
            var tasks = _context.Tasks.ToList();
            //_logger.LogInformation($"Retrieved {tasks.Count} tasks.");
            return Ok(tasks);
        }
    }

}
