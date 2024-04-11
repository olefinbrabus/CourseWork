using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    internal class Context : DbContext
    {
        public DbSet<CourseWork> courseWorks { get; set; } // Список курсових робіт

        public DbSet<GraduateWork> graduateWorks { get; set; }  // Список дипломних робіт

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)  // підключення до бази даних
        => optionsBuilder.UseSqlServer( @"Server=localhost\MSSQLSERVER01;Database=master;Trusted_Connection=True;TrustServerCertificate=True");
    }
}
