using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ResumeBackendFinal.Models.Entities;

namespace ResumeBackendFinal.Models.Contexts.Configurations
{
    public class PersonEntityConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(p => p.Id).HasColumnType("int");
            builder.Property(p => p.FullName).HasColumnType("nvarchar").IsRequired().HasMaxLength(200);
            builder.Property(p => p.Experience).HasColumnType("int").IsRequired();
            builder.Property(p => p.DateOfBirth).HasColumnType("datetime");
            builder.Property(p => p.Location).HasColumnType("nvarchar").HasMaxLength(200);
            builder.Property(p => p.Degree).IsRequired();
            builder.Property(p => p.Bio).HasColumnType("nvarchar").HasMaxLength(400);
            builder.Property(p => p.Fax).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(p => p.Website).HasColumnType("nvarchar").HasMaxLength(200);
            builder.Property(p => p.AttachmentPath).HasColumnType("varchar").HasMaxLength(100);
            builder.Property(p => p.CareerLevel).IsRequired();
            builder.Property(p => p.CreatedAt).HasColumnType("datetime").IsRequired();

            builder.ToTable("Persons");
            builder.HasKey(p => p.Id);
        }
    }
}
