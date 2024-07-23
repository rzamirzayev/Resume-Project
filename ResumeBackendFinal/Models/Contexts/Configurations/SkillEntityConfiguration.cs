using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ResumeBackendFinal.Models.Entities;

namespace ResumeBackendFinal.Models.Contexts.Configurations
{
    public class SkillEntityConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.Property(s => s.Id).HasColumnType("int");
            builder.Property(s => s.Name).HasColumnType("varchar").IsRequired().HasMaxLength(100);
            builder.Property(s => s.GroupId).HasColumnType("int").IsRequired();
            builder.Property(s => s.CreatedBy).HasColumnType("int").IsRequired();
            builder.Property(s => s.CreatedAt).HasColumnType("datetime").IsRequired();
            builder.Property(s => s.LastModifiedBy).HasColumnType("int");
            builder.Property(s => s.LastModifiedAt).HasColumnType("datetime");
            builder.Property(s => s.DeletedBy).HasColumnType("int");
            builder.Property(s => s.DeletedAt).HasColumnType("datetime");

            builder.ToTable("Skills");
            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.Group)
                   .WithMany(sg => sg.Skills)
                   .HasForeignKey(s => s.GroupId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
