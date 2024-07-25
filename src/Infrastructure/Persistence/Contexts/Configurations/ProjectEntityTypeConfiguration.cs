using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.Configurations
{
    public class ProjectEntityConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(s => s.Id).HasColumnType("int");
            builder.Property(p => p.Title).HasColumnType("nvarchar").IsRequired().HasMaxLength(200);
            builder.Property(p => p.ImagePath).HasColumnType("nvarchar").IsRequired().HasMaxLength(200);
            builder.Property(p => p.Url).HasColumnType("nvarchar").IsRequired().HasMaxLength(300);
            builder.Property(p => p.CreatedBy).HasColumnType("int").IsRequired();
            builder.Property(p => p.CreatedAt).HasColumnType("datetime").IsRequired();
            builder.Property(p => p.LastModifiedBy).HasColumnType("int");
            builder.Property(p => p.LastModifiedAt).HasColumnType("datetime");
            builder.Property(p => p.DeletedBy).HasColumnType("int");
            builder.Property(p => p.DeletedAt).HasColumnType("datetime");

            builder.ToTable("Projects");
            builder.HasKey(p => p.Id);

            builder.HasMany(p => p.ProjectCategories)
                   .WithOne(pc => pc.Project)
                   .HasForeignKey(pc => pc.ProjectId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
