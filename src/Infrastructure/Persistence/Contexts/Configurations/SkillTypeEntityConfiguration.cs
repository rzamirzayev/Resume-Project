using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.Configurations
{
    public class SkillTypeEntityConfiguration : IEntityTypeConfiguration<SkillType>
    {
        public void Configure(EntityTypeBuilder<SkillType> builder)
        {

            builder.Property(b => b.Id).HasColumnType("int");
            builder.Property(st => st.Name).HasColumnType("varchar").IsRequired().HasMaxLength(100);
            builder.Property(st => st.CreatedBy).HasColumnType("int").IsRequired();
            builder.Property(st => st.CreatedAt).HasColumnType("datetime").IsRequired();
            builder.Property(st => st.LastModifiedBy).HasColumnType("int");
            builder.Property(st => st.LastModifiedAt).HasColumnType("datetime");
            builder.Property(st => st.DeletedBy).HasColumnType("int");
            builder.Property(st => st.DeletedAt).HasColumnType("datetime");


            builder.ToTable("SkillTypes");
            builder.HasKey(st => st.Id);
        }
    }
}
