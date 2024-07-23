using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ResumeBackendFinal.Models.Entities;

namespace ResumeBackendFinal.Models.Contexts.Configurations
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasColumnType("varchar").IsRequired().HasMaxLength(200);
            builder.Property(c => c.CreatedBy).HasColumnType("int").IsRequired();
            builder.Property(c => c.CreatedAt).HasColumnType("datetime").IsRequired();
            builder.Property(c => c.LastModifiedBy).HasColumnType("int");
            builder.Property(c => c.LastModifiedAt).HasColumnType("datetime");
            builder.Property(c => c.DeletedBy).HasColumnType("int");
            builder.Property(c => c.DeletedAt).HasColumnType("datetime");
        }
    }
}
