using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Record> Records => Set<Record>();
        public DbSet<Teacher> Teachers => Set<Teacher>();
    }
}