using Microsoft.EntityFrameworkCore;

namespace infra
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    
    }
}
