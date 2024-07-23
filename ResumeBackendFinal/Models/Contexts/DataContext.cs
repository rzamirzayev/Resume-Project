using Microsoft.EntityFrameworkCore;
using ResumeBackendFinal.Models.Entities;

namespace ResumeBackendFinal.Models.Contexts
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
        public DbSet<ContactPost> ContactPosts { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<SkillGroup> SkillGroups { get; set; }  

        public DbSet<SkillType> SkillTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
