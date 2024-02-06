using Microsoft.EntityFrameworkCore;

namespace ShowroomManagementAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions option) :base(option) { 
        
        
        }
        public DbSet<Department> Departments { get; set; }
    }
}
