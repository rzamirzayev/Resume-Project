using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.Configurations
{
    public class ServiceEntityTypeConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.Property(s => s.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(s => s.CssClass).HasColumnType("varchar").HasMaxLength(100);
            builder.Property(s => s.Title).HasColumnType("nvarchar").IsRequired().HasMaxLength(200);
            builder.Property(s => s.Description).HasColumnType("nvarchar").HasMaxLength(500);
            builder.Property(s => s.CreatedBy).HasColumnType("varchar").IsRequired();
            builder.Property(s => s.CreatedAt).HasColumnType("datetime").IsRequired();
            builder.Property(s => s.LastModifiedBy).HasColumnType("varchar");
            builder.Property(s => s.LastModifiedAt).HasColumnType("datetime");
            builder.Property(s => s.DeletedBy).HasColumnType("varchar");
            builder.Property(s => s.DeletedAt).HasColumnType("datetime");


            builder.ToTable("Services");
            builder.HasKey(s => s.Id);
        }
    }
}
