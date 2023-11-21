using Microsoft.EntityFrameworkCore;

namespace AccountService.Model
{
    public class ApplicationDbcontext:DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }
    }
}
