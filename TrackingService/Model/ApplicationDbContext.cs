using Microsoft.EntityFrameworkCore;


namespace TrackingService.Model
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ):base(options)
        {
            
        }
        public DbSet<Orders> orders { get; set; }
        public DbSet<OrderTracking> orderTrackings { get; set; }
        public DbSet<User> User { get; set; }  
    }
}
