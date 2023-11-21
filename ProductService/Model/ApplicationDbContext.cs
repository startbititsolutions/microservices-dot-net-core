using Microsoft.EntityFrameworkCore;

namespace ProductService.Model
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Product> products { get; set; }
    }
}
