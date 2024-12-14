using Microsoft.AspNetCore.Identity;

namespace TaskManagementAPI.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string AssignedUserId { get; set; }
        public User AssignedUser { get; set; }
    }

}
