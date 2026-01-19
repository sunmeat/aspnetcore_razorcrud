using Microsoft.EntityFrameworkCore;

namespace RazorPagesApp.Models
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public StudentContext(DbContextOptions<StudentContext> options)
           : base(options)
        {
            // Database.EnsureDeleted();
            if (Database.EnsureCreated())
            {
                Students!.Add(new Student { Name = "Олександр", Surname = "Іваненко", Age = 23, GPA = 10.5 });
                Students!.Add(new Student { Name = "Сергій", Surname = "Сергієнко", Age = 21, GPA = 11.5 });
                Students!.Add(new Student { Name = "Марія", Surname = "Петренко", Age = 25, GPA = 12 });
                SaveChanges();
            }
        }
    }
}