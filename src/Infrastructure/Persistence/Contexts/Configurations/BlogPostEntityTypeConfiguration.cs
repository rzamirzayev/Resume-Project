using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.Configurations
{
    public class BlogPostEntityConfiguration : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.Property(b => b.Id).HasColumnType("int");
            builder.Property(b => b.Title).HasColumnType("nvarchar").HasMaxLength(200);
            builder.Property(b => b.Body).HasColumnType("nvarchar").HasMaxLength(500);
            builder.Property(b => b.ImagePath).HasColumnType("nvarchar").HasMaxLength(100);
            builder.Property(b => b.CreatedBy).HasColumnType("int").IsRequired();
            builder.Property(b => b.CreatedAt).HasColumnType("datetime").IsRequired();
            builder.Property(b => b.PublishedBy).HasColumnType("int");
            builder.Property(b => b.PublishedAt).HasColumnType("datetime");
            builder.Property(b => b.LastModifiedBy).HasColumnType("int");
            builder.Property(b => b.LastModifiedAt).HasColumnType("datetime");
            builder.Property(b => b.DeletedBy).HasColumnType("int");
            builder.Property(b => b.DeletedAt).HasColumnType("datetime");

            builder.ToTable("BlogPosts");
            builder.HasKey(b => b.Id);
        }
    }
}
