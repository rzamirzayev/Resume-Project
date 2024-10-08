﻿using Domain;
using Domain.Entities;
using Domain.Entities.Membership;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts
{
      class DataContext : IdentityDbContext<ResumeUser,ResumeRole,int,ResumeUserClaim,ResumeUserRole,ResumeUserLogin,ResumeRoleClaim,ResumeUserToken>
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
        public DbSet<PortfolioPost> PortfolioPosts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in this.ChangeTracker.Entries<ICreateEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.Now;
                }
                else
                {
                    entry.Property(m => m.CreatedAt).IsModified = false;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
