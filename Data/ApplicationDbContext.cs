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
        public DbSet<QnA> QnAs { get; set; }
        public DbSet<Score> Scores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            builder.Entity<Teacher>().HasData(
                new Teacher { Id = 1, FirstName = "Sarah", LastName = "Smith", Email = "sarahs@gmail.com", IsActive = true, Phone = "2534432213" });
            builder.Entity<Student>().HasData(
                new Student { Id = 1, FirstName = "Emily", LastName = "Falls", Enrolled = true, TeacherId = 1 });
            builder.Entity<Level>().HasData(
                new Level { Id = 1, IsUnlocked = true }); ;
            builder.Entity<QnA>().HasData(
                new QnA { Id = 1, MathEquation = $"{10}+{2}", Answer = $"{12}", LevelId = 1 }); 
            builder.Entity<Score>().HasData(
                new Score { Id = 1, LevelId = 1, StudentId=1, CurrentScore=10 }); ;
            base.OnModelCreating(builder);
        }

    }
}