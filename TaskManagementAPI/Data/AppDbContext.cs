using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Models;

using Microsoft.AspNetCore.Identity;


namespace TaskManagementAPI.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<TaskManagementAPI.Models.Task> Tasks { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder); // Add your customizations here

        //    builder.Entity<IdentityUserLogin<string>>(entity => { entity.HasKey(x => new { x.LoginProvider, x.ProviderKey }); }); 
        //    builder.Entity<IdentityUserRole<string>>(entity => { entity.HasKey(x => new { x.UserId, x.RoleId }); }); 
        //    builder.Entity<IdentityUserToken<string>>(entity => { entity.HasKey(x => new { x.UserId, x.LoginProvider, x.Name }); });
        //}

     }
}
