using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Services
{
    public class UserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async System.Threading.Tasks.Task CreateUserAsync(User user)
        {
            await _userManager.CreateAsync(user, user.PasswordHash);
        }

        public async System.Threading.Tasks.Task UpdateUserAsync(User user)
        {
            await _userManager.UpdateAsync(user);
        }

        public async System.Threading.Tasks.Task DeleteUserAsync(User user)
        {
            await _userManager.DeleteAsync(user);
        }
    }

}
