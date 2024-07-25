using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Service> Services { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<SkillGroup> SkillGroups { get; set; }

        public DbSet<SkillType> SkillTypes { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<PersonSkill> PersonSkills { get; set; }

        public DbSet<Person> People { get; set; }

        public DbSet<ContactPost> ContactPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
