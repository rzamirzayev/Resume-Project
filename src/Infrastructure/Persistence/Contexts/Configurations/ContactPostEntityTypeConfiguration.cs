using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.Configurations
{

    class ContactPostEntityTypeConfiguration : IEntityTypeConfiguration<ContactPost>
    {
        public void Configure(EntityTypeBuilder<ContactPost> builder)
        {
            builder.Property(c => c.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(c => c.FullName).HasColumnType("nvarchar").HasMaxLength(150).IsRequired();
            builder.Property(c => c.Email).HasColumnType("varchar").IsRequired().HasMaxLength(100);
            builder.Property(c => c.Subject).HasColumnType("varchar").IsRequired().HasMaxLength(100);
            builder.Property(c => c.Content).HasColumnType("nvarchar").IsRequired().HasMaxLength(500);
            builder.Property(c => c.CreatedAt).HasColumnType("datetime").IsRequired();
            builder.Property(c => c.AnsweredBy).HasColumnType("int").IsRequired(false);
            builder.Property(c => c.AnsweredAt).HasColumnType("datetime").IsRequired(false);
            builder.Property(c => c.Answer).HasColumnType("nvarchar").HasMaxLength(500).IsRequired(false);

            builder.HasKey(c => c.Id);
            builder.ToTable("ContactPosts");

        }
    }

}
