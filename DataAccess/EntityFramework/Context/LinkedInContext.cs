using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework.Context
{
    public class LinkedInContext:DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Experience> Experiences { get; set; }

        public DbSet<Education> Educations { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\MSSQLLocalDB;Database=LinkedIn;Trusted_Connection=true");
        }
    }
}