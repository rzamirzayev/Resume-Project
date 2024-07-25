using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.Configurations
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
