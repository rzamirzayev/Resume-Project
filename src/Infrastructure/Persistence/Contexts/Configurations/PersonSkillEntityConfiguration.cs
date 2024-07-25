using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.Configurations
{
    public class PersonSkillEntityConfiguration : IEntityTypeConfiguration<PersonSkill>
    {
        public void Configure(EntityTypeBuilder<PersonSkill> builder)
        {
            builder.ToTable("PersonSkills");
            builder.HasKey(ps => new { ps.PersonId, ps.SkillId });

            builder.HasOne(ps => ps.Person)
                   .WithMany(p => p.Skills)
                   .HasForeignKey(ps => ps.PersonId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ps => ps.Skill)
                   .WithMany()
                   .HasForeignKey(ps => ps.SkillId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(ps => ps.Mode).IsRequired();
            builder.Property(ps => ps.Percentage).HasColumnType("int").IsRequired();
            builder.Property(ps => ps.CreatedBy).HasColumnType("int").IsRequired();
            builder.Property(ps => ps.CreatedAt).HasColumnType("datetime").IsRequired();
            builder.Property(ps => ps.LastModifiedBy).HasColumnType("int");
            builder.Property(ps => ps.LastModifiedAt).HasColumnType("datetime");
            builder.Property(ps => ps.DeletedBy).HasColumnType("int");
            builder.Property(ps => ps.DeletedAt).HasColumnType("datetime");
        }
    }
}
