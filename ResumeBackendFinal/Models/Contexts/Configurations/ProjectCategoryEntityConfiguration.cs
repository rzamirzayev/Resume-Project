using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ResumeBackendFinal.Models.Entities;

namespace ResumeBackendFinal.Models.Contexts.Configurations
{

        public class ProjectCategoryEntityConfiguration : IEntityTypeConfiguration<ProjectCategory>
        {
            public void Configure(EntityTypeBuilder<ProjectCategory> builder)
            {
                builder.ToTable("ProjectCategories");
                builder.HasKey(pc => new { pc.ProjectId, pc.CategoryId });

                builder.HasOne(pc => pc.Project)
                       .WithMany(p => p.ProjectCategories)
                       .HasForeignKey(pc => pc.ProjectId);

                builder.HasOne(pc => pc.Category)
                       .WithMany()
                       .HasForeignKey(pc => pc.CategoryId);
            }
        }
    
}
