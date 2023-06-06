using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SeniorCapstoneProject.Models;

namespace SeniorCapstoneProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //Add dbsets for each table in my database
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Level> Levels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Teacher>().HasData(
                new Teacher { Id = 1, FirstName = "Sarah", LastName = "Smith", Email = "sarahs@gmail.com", IsActive = true, Phone = "2534432213" });
            builder.Entity<Student>().HasData(
                new Student { Id = 1, FirstName = "Emily", LastName = "Falls", Enrolled = true, TeacherId = 1, LevelId=1 });
            builder.Entity<Level>().HasData(
                new Level { Id = 1, Score = 0 });
            base.OnModelCreating(builder);
        }

    }
}