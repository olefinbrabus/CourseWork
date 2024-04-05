using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    internal class Context : DbContext
    {
        public DbSet<CourseWork> courseWorks { get; set; }

        public DbSet<GraduateWork> graduateWorks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer( @"Server=localhost\MSSQLSERVER01;Database=master;Trusted_Connection=True;TrustServerCertificate=True");
    }
}
