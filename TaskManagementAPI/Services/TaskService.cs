using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;
namespace TaskManagementAPI.Services
{
    public class TaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TaskManagementAPI.Models.Task>> GetTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<TaskManagementAPI.Models.Task> GetTaskByIdAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task CreateTaskAsync(TaskManagementAPI.Models.Task task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTaskAsync(TaskManagementAPI.Models.Task task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(TaskManagementAPI.Models.Task task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
    }

}
