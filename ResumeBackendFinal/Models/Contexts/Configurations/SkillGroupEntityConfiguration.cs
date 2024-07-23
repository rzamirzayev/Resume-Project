﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ResumeBackendFinal.Models.Entities;

namespace ResumeBackendFinal.Models.Contexts.Configurations
{
    public class SkillGroupEntityConfiguration : IEntityTypeConfiguration<SkillGroup>
    {
        public void Configure(EntityTypeBuilder<SkillGroup> builder)
        {
            builder.Property(sg=>sg.Id).HasColumnType("int");
            builder.Property(sg => sg.Name).HasColumnType("varchar").IsRequired().HasMaxLength(100);
            builder.Property(sg => sg.TypeId).HasColumnType("int").IsRequired();
            builder.Property(sg => sg.CreatedBy).HasColumnType("int").IsRequired();
            builder.Property(sg => sg.CreatedAt).HasColumnType("datetime").IsRequired();
            builder.Property(sg => sg.LastModifiedBy).HasColumnType("int");
            builder.Property(sg => sg.LastModifiedAt).HasColumnType("datetime");
            builder.Property(sg => sg.DeletedBy).HasColumnType("int");
            builder.Property(sg => sg.DeletedAt).HasColumnType("datetime");

            builder.ToTable("SkillGroup");
            builder.HasKey(sg => sg.Id);

            builder.HasOne(sg => sg.Type)
                   .WithMany(st => st.SkillGroups)
                   .HasForeignKey(sg => sg.TypeId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}